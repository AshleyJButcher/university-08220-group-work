namespace WindowsFormsApplication1
{
    partial class UserManagement
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
            this.Add = new System.Windows.Forms.Button();
            this.UserTypeCombo = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.UserListView = new System.Windows.Forms.ListView();
            this.Username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Remove = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(245, 114);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(94, 29);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // UserTypeCombo
            // 
            this.UserTypeCombo.FormattingEnabled = true;
            this.UserTypeCombo.Location = new System.Drawing.Point(13, 114);
            this.UserTypeCombo.Name = "UserTypeCombo";
            this.UserTypeCombo.Size = new System.Drawing.Size(151, 21);
            this.UserTypeCombo.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 25);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(255, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(13, 66);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(254, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // UserListView
            // 
            this.UserListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Username,
            this.Password,
            this.Type});
            this.UserListView.Location = new System.Drawing.Point(12, 159);
            this.UserListView.Name = "UserListView";
            this.UserListView.Size = new System.Drawing.Size(438, 181);
            this.UserListView.TabIndex = 4;
            this.UserListView.UseCompatibleStateImageBehavior = false;
            this.UserListView.View = System.Windows.Forms.View.Details;
            // 
            // Username
            // 
            this.Username.Text = "Username";
            // 
            // Password
            // 
            this.Password.Text = "Password";
            // 
            // Type
            // 
            this.Type.Text = "User Type";
            this.Type.Width = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "User Type";
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(356, 114);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(94, 27);
            this.Remove.TabIndex = 8;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(363, 12);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(87, 24);
            this.CloseBtn.TabIndex = 9;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 352);
            this.ControlBox = false;
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserListView);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.UserTypeCombo);
            this.Controls.Add(this.Add);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserManagement";
            this.Text = "User Management";
            this.Load += new System.EventHandler(this.UserManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.ComboBox UserTypeCombo;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ListView UserListView;
        private System.Windows.Forms.ColumnHeader Username;
        private System.Windows.Forms.ColumnHeader Password;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Button CloseBtn;
    }
}