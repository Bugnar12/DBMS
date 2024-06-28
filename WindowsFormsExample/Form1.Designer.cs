namespace WindowsFormsExample
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Table1 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            addButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // Table1
            // 
            Table1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Table1.AutoSize = true;
            Table1.Font = new Font("Bahnschrift Condensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Table1.Location = new Point(398, 73);
            Table1.Name = "Table1";
            Table1.Size = new Size(117, 28);
            Table1.TabIndex = 0;
            Table1.Text = "Antivirus_soft";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift Condensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1340, 73);
            label2.Name = "label2";
            label2.Size = new Size(84, 28);
            label2.TabIndex = 1;
            label2.Text = "Customer";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.AccessibleRole = AccessibleRole.Cursor;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(58, 105);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(809, 338);
            dataGridView1.TabIndex = 2;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(984, 105);
            dataGridView2.Margin = new Padding(3, 4, 3, 4);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(754, 338);
            dataGridView2.TabIndex = 3;
            // 
            // addButton
            // 
            addButton.Font = new Font("Courier New", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addButton.Location = new Point(508, 494);
            addButton.Name = "addButton";
            addButton.Size = new Size(637, 118);
            addButton.TabIndex = 5;
            addButton.Text = "Update Changes";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += button2_Click;
            // 
            // Form1
            // 
            AccessibleRole = AccessibleRole.Cursor;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(1788, 713);
            Controls.Add(addButton);
            Controls.Add(dataGridView2);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(Table1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DB Button";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Table1;
        private Label label2;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button addButton;
    }
}
