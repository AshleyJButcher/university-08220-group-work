namespace WindowsFormsApplication1
{
    partial class MainForm
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
            this.UserManagement = new System.Windows.Forms.Button();
            this.StockControl = new System.Windows.Forms.Button();
            this.AddPrescription = new System.Windows.Forms.Button();
            this.ProcessPrescription = new System.Windows.Forms.Button();
            this.btnManagementReport = new System.Windows.Forms.Button();
            this.LogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserManagement
            // 
            this.UserManagement.Enabled = false;
            this.UserManagement.Location = new System.Drawing.Point(28, 24);
            this.UserManagement.Name = "UserManagement";
            this.UserManagement.Size = new System.Drawing.Size(105, 57);
            this.UserManagement.TabIndex = 0;
            this.UserManagement.Text = "User Management";
            this.UserManagement.UseVisualStyleBackColor = true;
            this.UserManagement.Click += new System.EventHandler(this.UserManagement_Click);
            // 
            // StockControl
            // 
            this.StockControl.Enabled = false;
            this.StockControl.Location = new System.Drawing.Point(187, 24);
            this.StockControl.Name = "StockControl";
            this.StockControl.Size = new System.Drawing.Size(105, 57);
            this.StockControl.TabIndex = 1;
            this.StockControl.Text = "Stock Control";
            this.StockControl.UseVisualStyleBackColor = true;
            this.StockControl.Click += new System.EventHandler(this.StockControl_Click);
            // 
            // AddPrescription
            // 
            this.AddPrescription.Enabled = false;
            this.AddPrescription.Location = new System.Drawing.Point(185, 123);
            this.AddPrescription.Name = "AddPrescription";
            this.AddPrescription.Size = new System.Drawing.Size(107, 57);
            this.AddPrescription.TabIndex = 2;
            this.AddPrescription.Text = "Add Prescription";
            this.AddPrescription.UseVisualStyleBackColor = true;
            this.AddPrescription.Click += new System.EventHandler(this.AddPrescription_Click);
            // 
            // ProcessPrescription
            // 
            this.ProcessPrescription.Enabled = false;
            this.ProcessPrescription.Location = new System.Drawing.Point(28, 123);
            this.ProcessPrescription.Name = "ProcessPrescription";
            this.ProcessPrescription.Size = new System.Drawing.Size(107, 56);
            this.ProcessPrescription.TabIndex = 3;
            this.ProcessPrescription.Text = "Process Prescription";
            this.ProcessPrescription.UseVisualStyleBackColor = true;
            this.ProcessPrescription.Click += new System.EventHandler(this.ProcessPrescription_Click);
            // 
            // btnManagementReport
            // 
            this.btnManagementReport.Enabled = false;
            this.btnManagementReport.Location = new System.Drawing.Point(345, 82);
            this.btnManagementReport.Name = "btnManagementReport";
            this.btnManagementReport.Size = new System.Drawing.Size(105, 57);
            this.btnManagementReport.TabIndex = 4;
            this.btnManagementReport.Text = "Management Report";
            this.btnManagementReport.UseVisualStyleBackColor = true;
            this.btnManagementReport.Click += new System.EventHandler(this.ManagementReport_Click);
            // 
            // LogOut
            // 
            this.LogOut.Location = new System.Drawing.Point(168, 216);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(155, 52);
            this.LogOut.TabIndex = 5;
            this.LogOut.Text = "Log Out";
            this.LogOut.UseVisualStyleBackColor = true;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 288);
            this.ControlBox = false;
            this.Controls.Add(this.LogOut);
            this.Controls.Add(this.btnManagementReport);
            this.Controls.Add(this.ProcessPrescription);
            this.Controls.Add(this.AddPrescription);
            this.Controls.Add(this.StockControl);
            this.Controls.Add(this.UserManagement);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UserManagement;
        private System.Windows.Forms.Button StockControl;
        private System.Windows.Forms.Button AddPrescription;
        private System.Windows.Forms.Button ProcessPrescription;
        private System.Windows.Forms.Button btnManagementReport;
        private System.Windows.Forms.Button LogOut;
    }
}