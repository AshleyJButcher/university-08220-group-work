namespace WindowsFormsApplication1
{
    partial class AddDoctor
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddDoc = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(92, 177);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(155, 20);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Doctor Name : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // AddDoc
            // 
            this.AddDoc.Location = new System.Drawing.Point(258, 173);
            this.AddDoc.Name = "AddDoc";
            this.AddDoc.Size = new System.Drawing.Size(82, 28);
            this.AddDoc.TabIndex = 2;
            this.AddDoc.Text = "Add Doctor";
            this.AddDoc.UseVisualStyleBackColor = true;
            this.AddDoc.Click += new System.EventHandler(this.AddDoc_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(353, 173);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(82, 28);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(423, 149);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // AddDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(449, 214);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.AddDoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDoctor";
            this.Text = "AddDoctor";
            this.Load += new System.EventHandler(this.AddDoctor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddDoc;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}