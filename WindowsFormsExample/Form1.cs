using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsExample
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapterAntivirus;
        private SqlDataAdapter adapterCustomer; 

        private DataSet dataSet;
        private BindingSource bindingAntivirus;
        private BindingSource bindingCustomer;

        private SqlCommandBuilder commandBuilder;
        private string queryAntivirus;
        private string queryCustomer;

        void FillData()
        {
            //connection to DBMS
            connection = new SqlConnection(getConnectionString());
            connection.Open();

            //fill the queries for the parent and the child tables
            queryAntivirus = getAntivirusQuery();
            queryCustomer = getCustomerQuery();

            //init the adapters
            adapterAntivirus = new SqlDataAdapter(queryAntivirus, connection);
            adapterCustomer = new SqlDataAdapter(queryCustomer, connection);

            dataSet = new DataSet();
            adapterAntivirus.Fill(dataSet, "Antivirus_soft"); //fill with data set + name of the table
            adapterCustomer.Fill(dataSet, "Customer"); //fill with data set + name of the table

            //this will include all IUD operations
            commandBuilder = new SqlCommandBuilder(adapterAntivirus);

            //create a new table => parent-child relationship between tables Antivirus_soft and Customer
            dataSet.Relations.Add("Antivirus_customer",
                dataSet.Tables["Antivirus_soft"].Columns["antivirus_id"],
                dataSet.Tables["Customer"].Columns["antivirus_id"]);


            this.dataGridView1.DataSource = dataSet.Tables["Antivirus_soft"];
            this.dataGridView2.DataSource = this.dataGridView1.DataSource;
            this.dataGridView2.DataMember = "Antivirus_customer"; 
                                                                  

        }
        string getConnectionString()
        {
            return "Data Source=DESKTOP-Q7V75A4;Initial Catalog=Labs;Integrated Security=true;";
        }

        string getAntivirusQuery()
        {
            return "SELECT * FROM Antivirus_soft";
        }

        string getCustomerQuery()
        {
            return "SELECT * FROM Customer";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adapterCustomer.Update(dataSet, "Customer");
        }

        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            FillData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable customerTable = dataSet.Tables["Customer"];
                DataTable changes = customerTable.GetChanges();
                //check if changes were performed on the child table
                if (changes != null)
                {
                    commandBuilder = new SqlCommandBuilder(adapterCustomer);
                    adapterCustomer.Update(dataSet, "Customer");
                    MessageBox.Show("Successful I/U/D operation!");
                }
                else
                {
                    MessageBox.Show("I/U/D operations must be performed only in the child table!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}