namespace WindowsFormsApplication1
{
    partial class AddPrescription
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
            this.AddItem = new System.Windows.Forms.Button();
            this.DoctorsCombo = new System.Windows.Forms.ComboBox();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ItemCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ItemView = new System.Windows.Forms.ListView();
            this.Save = new System.Windows.Forms.Button();
            this.AddDoctor = new System.Windows.Forms.Button();
            this.txtInstructions = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Clear = new System.Windows.Forms.Button();
            this.RemoveItem = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // AddItem
            // 
            this.AddItem.Location = new System.Drawing.Point(322, 58);
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(75, 23);
            this.AddItem.TabIndex = 0;
            this.AddItem.Text = "Add Item";
            this.AddItem.UseVisualStyleBackColor = true;
            this.AddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // DoctorsCombo
            // 
            this.DoctorsCombo.FormattingEnabled = true;
            this.DoctorsCombo.Location = new System.Drawing.Point(482, 22);
            this.DoctorsCombo.Name = "DoctorsCombo";
            this.DoctorsCombo.Size = new System.Drawing.Size(121, 21);
            this.DoctorsCombo.TabIndex = 3;
            this.DoctorsCombo.Click += new System.EventHandler(this.DoctorsCombo_Click);
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(101, 26);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(257, 20);
            this.txtPatientName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Patient Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Doctor Name";
            // 
            // ItemCombo
            // 
            this.ItemCombo.FormattingEnabled = true;
            this.ItemCombo.Location = new System.Drawing.Point(101, 58);
            this.ItemCombo.Name = "ItemCombo";
            this.ItemCombo.Size = new System.Drawing.Size(190, 21);
            this.ItemCombo.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Item";
            // 
            // ItemView
            // 
            this.ItemView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemName,
            this.Quantity});
            this.ItemView.Location = new System.Drawing.Point(3, 148);
            this.ItemView.Name = "ItemView";
            this.ItemView.Size = new System.Drawing.Size(408, 251);
            this.ItemView.TabIndex = 12;
            this.ItemView.UseCompatibleStateImageBehavior = false;
            this.ItemView.View = System.Windows.Forms.View.Details;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(501, 109);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(83, 23);
            this.Save.TabIndex = 13;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // AddDoctor
            // 
            this.AddDoctor.Location = new System.Drawing.Point(625, 22);
            this.AddDoctor.Name = "AddDoctor";
            this.AddDoctor.Size = new System.Drawing.Size(87, 24);
            this.AddDoctor.TabIndex = 14;
            this.AddDoctor.Text = "Add Doctor";
            this.AddDoctor.UseVisualStyleBackColor = true;
            this.AddDoctor.Click += new System.EventHandler(this.AddDoctor_Click);
            // 
            // txtInstructions
            // 
            this.txtInstructions.Location = new System.Drawing.Point(455, 165);
            this.txtInstructions.Multiline = true;
            this.txtInstructions.Name = "txtInstructions";
            this.txtInstructions.Size = new System.Drawing.Size(303, 234);
            this.txtInstructions.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(454, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Instructions for the Pharmacist";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(58, 110);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(83, 22);
            this.Clear.TabIndex = 17;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // RemoveItem
            // 
            this.RemoveItem.Location = new System.Drawing.Point(213, 110);
            this.RemoveItem.Name = "RemoveItem";
            this.RemoveItem.Size = new System.Drawing.Size(108, 22);
            this.RemoveItem.TabIndex = 18;
            this.RemoveItem.Text = "Remove Item";
            this.RemoveItem.UseVisualStyleBackColor = true;
            this.RemoveItem.Click += new System.EventHandler(this.RemoveItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(670, 109);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 22);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.Close_Click);
            // 
            // ItemName
            // 
            this.ItemName.Text = "Item Name";
            this.ItemName.Width = 191;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 196;
            // 
            // AddPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(770, 411);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.RemoveItem);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInstructions);
            this.Controls.Add(this.AddDoctor);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.ItemView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ItemCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.DoctorsCombo);
            this.Controls.Add(this.AddItem);
            this.Name = "AddPrescription";
            this.Text = "AddPrescription";
            this.Load += new System.EventHandler(this.AddPrescription_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddItem;
        private System.Windows.Forms.ComboBox DoctorsCombo;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ItemCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView ItemView;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button AddDoctor;
        private System.Windows.Forms.TextBox txtInstructions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button RemoveItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader ItemName;
        private System.Windows.Forms.ColumnHeader Quantity;
    }
}