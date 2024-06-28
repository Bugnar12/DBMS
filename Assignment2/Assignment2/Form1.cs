using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Assignment2
{
    public partial class Form1 : Form
    {
        private SqlConnection dbConnection;
        private SqlDataAdapter dataAdapterParent, dataAdapterChild;
        private DataSet dataSet;
        private DataRelation drParentChild;
        private BindingSource bindingSourceParent, bindingSourceChild;

        public Form1()
        {
            Console.WriteLine(getDatabaseString());
            InitializeComponent();
        }

        string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
        }

        string getDatabaseString()
        {
            return ConfigurationManager.AppSettings["Database"].ToString();
        }

        private string getParentTableName()
        {
            return ConfigurationManager.AppSettings["ParentTableName"].ToString();
        }

        private string getChildTableName()
        {
            return ConfigurationManager.AppSettings["ChildTableName"].ToString();
        }

        private string getParentSelectQuery()
        {
            return ConfigurationManager.AppSettings["ParentTableQuery"].ToString();
        }

        private string getChildSelectQuery()
        {
            return ConfigurationManager.AppSettings["ChildTableQuery"].ToString();
        }

        private string getParentReferencedKey()
        {
            return ConfigurationManager.AppSettings["ParentTableForeignKey"].ToString();
        }

        private string getChildForeignKey()
        {
            return ConfigurationManager.AppSettings["ChildTableForeignKey"].ToString();
        }

        private string getParentSelectionQuery()
        {
            return ConfigurationManager.AppSettings["ParentSelectionQuery"].ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dbConnection = new SqlConnection(String.Format(getConnectionString(), getDatabaseString()));
            dbConnection.Open();

            dataSet = new DataSet();

            dataAdapterParent = new SqlDataAdapter(getParentSelectQuery(), dbConnection);
            dataAdapterParent.Fill(dataSet, getParentTableName());
            parentGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataAdapterChild = new SqlDataAdapter(getChildSelectQuery(), dbConnection);
            dataAdapterChild.Fill(dataSet, getChildTableName());
            childGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataColumn referencedID = dataSet.Tables[getParentTableName()].Columns[getParentReferencedKey()];
            Console.WriteLine("saluit");
            DataColumn foreignID = dataSet.Tables[getChildTableName()].Columns[getChildForeignKey()];
            drParentChild = new DataRelation("FK_Parent_Child", referencedID, foreignID);
            dataSet.Relations.Add(drParentChild);

            bindingSourceParent = new BindingSource();
            bindingSourceParent.DataSource = dataSet;
            bindingSourceParent.DataMember = getParentTableName();

            bindingSourceChild = new BindingSource();
            bindingSourceChild.DataSource = bindingSourceParent;
            bindingSourceChild.DataMember = "FK_Parent_Child";

            parentGridView.DataSource = bindingSourceParent;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapterChild);
            dataAdapterChild.UpdateCommand = commandBuilder.GetUpdateCommand();
            dataAdapterChild.InsertCommand = commandBuilder.GetInsertCommand();
            dataAdapterChild.DeleteCommand = commandBuilder.GetDeleteCommand();

            try
            {
                dataAdapterChild.Update(dataSet, getChildTableName());

            }
            catch(SqlException exception)
            {
                if (exception.Number == 2627)
                    MessageBox.Show("There is column data that should be unique in the table!");
                else if (exception.Number == 547)
                    MessageBox.Show("There's no parent with the given id!");
                else
                    MessageBox.Show(exception.Message);
            }

            ReloadChildTableView();
        }

        private void ReloadChildTableView()
        {
            if (dataSet.Tables[getChildTableName()] != null)
            {
                dataSet.Tables[getChildTableName()].Clear();
            }
            dataAdapterChild.Fill(dataSet, getChildTableName());
            childGridView.DataSource = bindingSourceChild;
        }

        private void parentGridView_SelectionChanged(object sender, EventArgs e)
        {
            if(parentGridView.SelectedRows.Count != 0)
            {
                DataGridViewRow selectedRow = parentGridView.SelectedRows[0];
                string selectCommandString = String.Format(getParentSelectionQuery(), selectedRow.Cells[0].Value);
                dataAdapterChild.SelectCommand = new SqlCommand(selectCommandString, dbConnection);
                ReloadChildTableView();
            }
        }
    }
}
