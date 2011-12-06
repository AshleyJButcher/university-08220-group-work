namespace WindowsFormsApplication1
{
    partial class StockControl
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
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.ItemsListView = new System.Windows.Forms.ListView();
            this.ItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExpiryDat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Restock = new System.Windows.Forms.Button();
            this.IncreaseQuan = new System.Windows.Forms.Button();
            this.DecreaseQuan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Closebtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(61, 167);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(310, 20);
            this.txtAmount.TabIndex = 0;
            // 
            // ItemsListView
            // 
            this.ItemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemName,
            this.Quantity,
            this.Price,
            this.ExpiryDat});
            this.ItemsListView.Location = new System.Drawing.Point(15, 198);
            this.ItemsListView.Name = "ItemsListView";
            this.ItemsListView.Size = new System.Drawing.Size(356, 282);
            this.ItemsListView.TabIndex = 1;
            this.ItemsListView.UseCompatibleStateImageBehavior = false;
            this.ItemsListView.View = System.Windows.Forms.View.Details;
            // 
            // ItemName
            // 
            this.ItemName.Text = "Item Name";
            this.ItemName.Width = 127;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 63;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            // 
            // ExpiryDat
            // 
            this.ExpiryDat.Text = "Expiry Date";
            this.ExpiryDat.Width = 90;
            // 
            // Restock
            // 
            this.Restock.Location = new System.Drawing.Point(377, 162);
            this.Restock.Name = "Restock";
            this.Restock.Size = new System.Drawing.Size(81, 29);
            this.Restock.TabIndex = 2;
            this.Restock.Text = "Restock";
            this.Restock.UseVisualStyleBackColor = true;
            this.Restock.Click += new System.EventHandler(this.Restock_Click);
            // 
            // IncreaseQuan
            // 
            this.IncreaseQuan.Location = new System.Drawing.Point(377, 198);
            this.IncreaseQuan.Name = "IncreaseQuan";
            this.IncreaseQuan.Size = new System.Drawing.Size(81, 29);
            this.IncreaseQuan.TabIndex = 3;
            this.IncreaseQuan.Text = "Increase";
            this.IncreaseQuan.UseVisualStyleBackColor = true;
            this.IncreaseQuan.Click += new System.EventHandler(this.IncreaseQuan_Click);
            // 
            // DecreaseQuan
            // 
            this.DecreaseQuan.Location = new System.Drawing.Point(377, 233);
            this.DecreaseQuan.Name = "DecreaseQuan";
            this.DecreaseQuan.Size = new System.Drawing.Size(81, 31);
            this.DecreaseQuan.TabIndex = 4;
            this.DecreaseQuan.Text = "Decrease";
            this.DecreaseQuan.UseVisualStyleBackColor = true;
            this.DecreaseQuan.Click += new System.EventHandler(this.DecreaseQuan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Amount";
            // 
            // Closebtn
            // 
            this.Closebtn.Location = new System.Drawing.Point(377, 451);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(81, 29);
            this.Closebtn.TabIndex = 8;
            this.Closebtn.Text = "Close";
            this.Closebtn.UseVisualStyleBackColor = true;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(423, 149);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // StockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(466, 489);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Closebtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DecreaseQuan);
            this.Controls.Add(this.IncreaseQuan);
            this.Controls.Add(this.Restock);
            this.Controls.Add(this.ItemsListView);
            this.Controls.Add(this.txtAmount);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StockControl";
            this.Load += new System.EventHandler(this.StockControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ListView ItemsListView;
        private System.Windows.Forms.Button Restock;
        private System.Windows.Forms.Button IncreaseQuan;
        private System.Windows.Forms.Button DecreaseQuan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader ItemName;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader ExpiryDat;
        private System.Windows.Forms.Button Closebtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}