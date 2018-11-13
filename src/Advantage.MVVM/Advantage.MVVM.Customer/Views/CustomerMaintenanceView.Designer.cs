namespace Advantage.MVVM.Customers.Views
{
    partial class CustomerMaintenanceView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboCustomers = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.pnlList = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlDetails.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboCustomers
            // 
            this.cboCustomers.FormattingEnabled = true;
            this.cboCustomers.Location = new System.Drawing.Point(11, 29);
            this.cboCustomers.Name = "cboCustomers";
            this.cboCustomers.Size = new System.Drawing.Size(262, 21);
            this.cboCustomers.TabIndex = 2;
            this.cboCustomers.SelectedIndexChanged += new System.EventHandler(this.cboCustomers_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(73, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 34);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Customers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Id";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(11, 19);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(262, 20);
            this.txtId.TabIndex = 6;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(12, 97);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(80, 20);
            this.txtAge.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Age";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(11, 58);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(262, 20);
            this.txtName.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Name";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(3, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 34);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(143, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(64, 34);
            this.btnCopy.TabIndex = 12;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(213, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 34);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(283, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 34);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlDetails.Controls.Add(this.txtAge);
            this.pnlDetails.Controls.Add(this.label2);
            this.pnlDetails.Controls.Add(this.txtId);
            this.pnlDetails.Controls.Add(this.label3);
            this.pnlDetails.Controls.Add(this.label4);
            this.pnlDetails.Controls.Add(this.txtName);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(0, 66);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(356, 130);
            this.pnlDetails.TabIndex = 15;
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.cboCustomers);
            this.pnlList.Controls.Add(this.label1);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlList.Location = new System.Drawing.Point(0, 0);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(356, 66);
            this.pnlList.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnCopy);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 196);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 58);
            this.panel3.TabIndex = 17;
            // 
            // CustomerMaintenanceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 254);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlList);
            this.Name = "CustomerMaintenanceView";
            this.Text = "Customer Maintenance View";
            this.Load += new System.EventHandler(this.CustomerMaintenanceView_Load);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cboCustomers;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Panel panel3;
    }
}