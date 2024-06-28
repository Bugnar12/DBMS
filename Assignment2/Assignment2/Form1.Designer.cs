namespace Assignment2
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
            parentGridView = new DataGridView();
            childGridView = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)parentGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)childGridView).BeginInit();
            SuspendLayout();
            // 
            // parentGridView
            // 
            parentGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            parentGridView.Location = new Point(51, 105);
            parentGridView.Name = "parentGridView";
            parentGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            parentGridView.Size = new Size(612, 305);
            parentGridView.TabIndex = 0;
            parentGridView.SelectionChanged += parentGridView_SelectionChanged;
            // 
            // childGridView
            // 
            childGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            childGridView.Location = new Point(750, 103);
            childGridView.Name = "childGridView";
            childGridView.Size = new Size(590, 307);
            childGridView.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(290, 77);
            label1.Name = "label1";
            label1.Size = new Size(122, 25);
            label1.TabIndex = 2;
            label1.Text = "Parent Table";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(1017, 77);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 3;
            label2.Text = "Child Table";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(552, 448);
            button1.Name = "button1";
            button1.Size = new Size(270, 54);
            button1.TabIndex = 4;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            ClientSize = new Size(1388, 527);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(childGridView);
            Controls.Add(parentGridView);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)parentGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)childGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView parentGridView;
        private DataGridView childGridView;
        private Label label1;
        private Label label2;
        private Button button1;
    }
}
