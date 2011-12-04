namespace WindowsFormsApplication1
{
    partial class Pharmacist
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
            this.FixedPrice = new System.Windows.Forms.Button();
            this.Free = new System.Windows.Forms.Button();
            this.DateIssue = new System.Windows.Forms.DateTimePicker();
            this.DateExpiry = new System.Windows.Forms.DateTimePicker();
            this.PharmaCombo = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Complete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PrescriptionList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInstructions = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PrescriptionToCollect = new System.Windows.Forms.ListBox();
            this.Collected = new System.Windows.Forms.Button();
            this.Collecting = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.Itemname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pricev = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExpirationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FixedPrice
            // 
            this.FixedPrice.Location = new System.Drawing.Point(18, 28);
            this.FixedPrice.Name = "FixedPrice";
            this.FixedPrice.Size = new System.Drawing.Size(85, 32);
            this.FixedPrice.TabIndex = 0;
            this.FixedPrice.Text = "Fixed Price";
            this.FixedPrice.UseVisualStyleBackColor = true;
            this.FixedPrice.Click += new System.EventHandler(this.FixedPrice_Click);
            // 
            // Free
            // 
            this.Free.Location = new System.Drawing.Point(130, 26);
            this.Free.Name = "Free";
            this.Free.Size = new System.Drawing.Size(85, 34);
            this.Free.TabIndex = 1;
            this.Free.Text = "Free";
            this.Free.UseVisualStyleBackColor = true;
            this.Free.Click += new System.EventHandler(this.Free_Click);
            // 
            // DateIssue
            // 
            this.DateIssue.Location = new System.Drawing.Point(23, 21);
            this.DateIssue.Name = "DateIssue";
            this.DateIssue.Size = new System.Drawing.Size(192, 20);
            this.DateIssue.TabIndex = 2;
            this.DateIssue.ValueChanged += new System.EventHandler(this.DateIssue_ValueChanged);
            // 
            // DateExpiry
            // 
            this.DateExpiry.Enabled = false;
            this.DateExpiry.Location = new System.Drawing.Point(23, 71);
            this.DateExpiry.Name = "DateExpiry";
            this.DateExpiry.Size = new System.Drawing.Size(197, 20);
            this.DateExpiry.TabIndex = 3;
            // 
            // PharmaCombo
            // 
            this.PharmaCombo.FormattingEnabled = true;
            this.PharmaCombo.Location = new System.Drawing.Point(255, 152);
            this.PharmaCombo.Name = "PharmaCombo";
            this.PharmaCombo.Size = new System.Drawing.Size(168, 21);
            this.PharmaCombo.TabIndex = 4;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Itemname,
            this.Quantity,
            this.Pricev,
            this.ExpirationDate});
            this.listView1.Location = new System.Drawing.Point(395, 206);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(454, 210);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Complete
            // 
            this.Complete.Location = new System.Drawing.Point(632, 149);
            this.Complete.Name = "Complete";
            this.Complete.Size = new System.Drawing.Size(85, 34);
            this.Complete.TabIndex = 6;
            this.Complete.Text = "Complete";
            this.Complete.UseVisualStyleBackColor = true;
            this.Complete.Click += new System.EventHandler(this.Complete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pharmacists Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Date of Issue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Expiry Date";
            // 
            // PrescriptionList
            // 
            this.PrescriptionList.FormattingEnabled = true;
            this.PrescriptionList.Location = new System.Drawing.Point(191, 204);
            this.PrescriptionList.Name = "PrescriptionList";
            this.PrescriptionList.Size = new System.Drawing.Size(172, 212);
            this.PrescriptionList.TabIndex = 10;
            this.PrescriptionList.SelectedIndexChanged += new System.EventHandler(this.PrescriptionList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FixedPrice);
            this.groupBox1.Controls.Add(this.Free);
            this.groupBox1.Location = new System.Drawing.Point(549, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 70);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prescription Certificate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Instructions";
            // 
            // txtInstructions
            // 
            this.txtInstructions.AutoSize = true;
            this.txtInstructions.Location = new System.Drawing.Point(297, 49);
            this.txtInstructions.Name = "txtInstructions";
            this.txtInstructions.Size = new System.Drawing.Size(66, 13);
            this.txtInstructions.TabIndex = 14;
            this.txtInstructions.Text = "example text";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Prescriptions To Complete ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Prescriptions To Collect";
            // 
            // PrescriptionToCollect
            // 
            this.PrescriptionToCollect.FormattingEnabled = true;
            this.PrescriptionToCollect.Location = new System.Drawing.Point(23, 149);
            this.PrescriptionToCollect.Name = "PrescriptionToCollect";
            this.PrescriptionToCollect.Size = new System.Drawing.Size(147, 212);
            this.PrescriptionToCollect.TabIndex = 17;
            // 
            // Collected
            // 
            this.Collected.Location = new System.Drawing.Point(53, 382);
            this.Collected.Name = "Collected";
            this.Collected.Size = new System.Drawing.Size(85, 34);
            this.Collected.TabIndex = 18;
            this.Collected.Text = "&Collected";
            this.Collected.UseVisualStyleBackColor = true;
            this.Collected.Click += new System.EventHandler(this.Collected_Click);
            // 
            // Collecting
            // 
            this.Collecting.AutoSize = true;
            this.Collecting.Location = new System.Drawing.Point(723, 97);
            this.Collecting.Name = "Collecting";
            this.Collecting.Size = new System.Drawing.Size(62, 17);
            this.Collecting.TabIndex = 19;
            this.Collecting.Text = "Waiting";
            this.Collecting.UseVisualStyleBackColor = true;
            this.Collecting.CheckedChanged += new System.EventHandler(this.Collecting_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(596, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Is Patient Waiting Now?";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(755, 149);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 33);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.Close_Click);
            // 
            // Itemname
            // 
            this.Itemname.Text = "Item Name";
            this.Itemname.Width = 122;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 92;
            // 
            // Pricev
            // 
            this.Pricev.Text = "Price";
            this.Pricev.Width = 130;
            // 
            // ExpirationDate
            // 
            this.ExpirationDate.Text = "Expiry Date";
            this.ExpirationDate.Width = 118;
            // 
            // Pharmacist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 428);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Collecting);
            this.Controls.Add(this.Collected);
            this.Controls.Add(this.PrescriptionToCollect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtInstructions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PrescriptionList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Complete);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.PharmaCombo);
            this.Controls.Add(this.DateExpiry);
            this.Controls.Add(this.DateIssue);
            this.Name = "Pharmacist";
            this.Text = "Pharmacist";
            this.Load += new System.EventHandler(this.Pharmacist_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FixedPrice;
        private System.Windows.Forms.Button Free;
        private System.Windows.Forms.DateTimePicker DateIssue;
        private System.Windows.Forms.DateTimePicker DateExpiry;
        private System.Windows.Forms.ComboBox PharmaCombo;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button Complete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox PrescriptionList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtInstructions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox PrescriptionToCollect;
        private System.Windows.Forms.Button Collected;
        private System.Windows.Forms.CheckBox Collecting;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader Itemname;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Pricev;
        private System.Windows.Forms.ColumnHeader ExpirationDate;
    }
}