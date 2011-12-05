namespace WindowsFormsApplication1
{
    partial class ManagementReport
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
            this.FirstDayOfTheWeek = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Generate = new System.Windows.Forms.Button();
            this.TotalWeeklySales = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DoctorSoldView = new System.Windows.Forms.ListView();
            this.Doctor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalSold = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemQuantitySold = new System.Windows.Forms.ListView();
            this.ItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QuantitySold = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.Closebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FirstDayOfTheWeek
            // 
            this.FirstDayOfTheWeek.Location = new System.Drawing.Point(51, 26);
            this.FirstDayOfTheWeek.Name = "FirstDayOfTheWeek";
            this.FirstDayOfTheWeek.Size = new System.Drawing.Size(131, 20);
            this.FirstDayOfTheWeek.TabIndex = 0;
            this.FirstDayOfTheWeek.ValueChanged += new System.EventHandler(this.FirstDayOfTheWeek_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please Choose the Start of the Week";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total Weekly Sales";
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(224, 15);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(71, 31);
            this.Generate.TabIndex = 5;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // TotalWeeklySales
            // 
            this.TotalWeeklySales.AutoSize = true;
            this.TotalWeeklySales.Location = new System.Drawing.Point(346, 32);
            this.TotalWeeklySales.Name = "TotalWeeklySales";
            this.TotalWeeklySales.Size = new System.Drawing.Size(46, 13);
            this.TotalWeeklySales.TabIndex = 6;
            this.TotalWeeklySales.Text = "£000.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Total Sold By Each Doctor";
            // 
            // DoctorSoldView
            // 
            this.DoctorSoldView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Doctor,
            this.TotalSold});
            this.DoctorSoldView.Location = new System.Drawing.Point(12, 122);
            this.DoctorSoldView.Name = "DoctorSoldView";
            this.DoctorSoldView.Size = new System.Drawing.Size(205, 168);
            this.DoctorSoldView.TabIndex = 9;
            this.DoctorSoldView.UseCompatibleStateImageBehavior = false;
            this.DoctorSoldView.View = System.Windows.Forms.View.Details;
            // 
            // Doctor
            // 
            this.Doctor.Text = "Doctor";
            this.Doctor.Width = 97;
            // 
            // TotalSold
            // 
            this.TotalSold.Text = "Total Sold";
            this.TotalSold.Width = 104;
            // 
            // ItemQuantitySold
            // 
            this.ItemQuantitySold.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemName,
            this.QuantitySold});
            this.ItemQuantitySold.Location = new System.Drawing.Point(234, 124);
            this.ItemQuantitySold.Name = "ItemQuantitySold";
            this.ItemQuantitySold.Size = new System.Drawing.Size(263, 166);
            this.ItemQuantitySold.TabIndex = 10;
            this.ItemQuantitySold.UseCompatibleStateImageBehavior = false;
            this.ItemQuantitySold.View = System.Windows.Forms.View.Details;
            // 
            // ItemName
            // 
            this.ItemName.Text = "Item Name";
            this.ItemName.Width = 125;
            // 
            // QuantitySold
            // 
            this.QuantitySold.Text = "Quantity Sold";
            this.QuantitySold.Width = 97;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Total of Each Item Sold";
            // 
            // Closebtn
            // 
            this.Closebtn.Location = new System.Drawing.Point(382, 72);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(105, 27);
            this.Closebtn.TabIndex = 0;
            this.Closebtn.Text = "Close";
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // ManagementReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 302);
            this.ControlBox = false;
            this.Controls.Add(this.Closebtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ItemQuantitySold);
            this.Controls.Add(this.DoctorSoldView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TotalWeeklySales);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FirstDayOfTheWeek);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManagementReport";
            this.Text = "ManagementReport";
            this.Load += new System.EventHandler(this.ManagementReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker FirstDayOfTheWeek;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.Label TotalWeeklySales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView DoctorSoldView;
        private System.Windows.Forms.ColumnHeader Doctor;
        private System.Windows.Forms.ColumnHeader TotalSold;
        private System.Windows.Forms.ListView ItemQuantitySold;
        private System.Windows.Forms.ColumnHeader ItemName;
        private System.Windows.Forms.ColumnHeader QuantitySold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Closebtn;
    }
}