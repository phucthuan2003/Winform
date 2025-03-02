namespace GUI_QuanLy
{
    partial class Information
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Information));
            this.lblDiaChi = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSdt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNgaySinh = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCa = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCV = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMa = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblHoten = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Pic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.BackColor = System.Drawing.Color.Transparent;
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDiaChi.ForeColor = System.Drawing.Color.Black;
            this.lblDiaChi.Location = new System.Drawing.Point(411, 499);
            this.lblDiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(76, 32);
            this.lblDiaChi.TabIndex = 17;
            this.lblDiaChi.Text = "Địa chỉ:";
            this.lblDiaChi.Click += new System.EventHandler(this.lblDiaChi_Click);
            // 
            // lblSdt
            // 
            this.lblSdt.BackColor = System.Drawing.Color.Transparent;
            this.lblSdt.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSdt.ForeColor = System.Drawing.Color.Black;
            this.lblSdt.Location = new System.Drawing.Point(411, 438);
            this.lblSdt.Margin = new System.Windows.Forms.Padding(2);
            this.lblSdt.Name = "lblSdt";
            this.lblSdt.Size = new System.Drawing.Size(140, 32);
            this.lblSdt.TabIndex = 16;
            this.lblSdt.Text = "Số điện thoại:";
            this.lblSdt.Click += new System.EventHandler(this.lblSdt_Click);
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.BackColor = System.Drawing.Color.Transparent;
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNgaySinh.ForeColor = System.Drawing.Color.Black;
            this.lblNgaySinh.Location = new System.Drawing.Point(411, 384);
            this.lblNgaySinh.Margin = new System.Windows.Forms.Padding(2);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(108, 32);
            this.lblNgaySinh.TabIndex = 15;
            this.lblNgaySinh.Text = "Ngày sinh:";
            this.lblNgaySinh.Click += new System.EventHandler(this.lblNgaySinh_Click);
            // 
            // lblCa
            // 
            this.lblCa.BackColor = System.Drawing.Color.Transparent;
            this.lblCa.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblCa.ForeColor = System.Drawing.Color.Black;
            this.lblCa.Location = new System.Drawing.Point(411, 326);
            this.lblCa.Margin = new System.Windows.Forms.Padding(2);
            this.lblCa.Name = "lblCa";
            this.lblCa.Size = new System.Drawing.Size(123, 32);
            this.lblCa.TabIndex = 14;
            this.lblCa.Text = "Ngày tuyển:";
            this.lblCa.Click += new System.EventHandler(this.lblCa_Click);
            // 
            // lblCV
            // 
            this.lblCV.BackColor = System.Drawing.Color.Transparent;
            this.lblCV.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblCV.ForeColor = System.Drawing.Color.Black;
            this.lblCV.Location = new System.Drawing.Point(411, 274);
            this.lblCV.Margin = new System.Windows.Forms.Padding(2);
            this.lblCV.Name = "lblCV";
            this.lblCV.Size = new System.Drawing.Size(105, 32);
            this.lblCV.TabIndex = 13;
            this.lblCV.Text = "Công việc:";
            this.lblCV.Click += new System.EventHandler(this.lblCV_Click);
            // 
            // lblMa
            // 
            this.lblMa.BackColor = System.Drawing.Color.Transparent;
            this.lblMa.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMa.ForeColor = System.Drawing.Color.Black;
            this.lblMa.Location = new System.Drawing.Point(411, 221);
            this.lblMa.Margin = new System.Windows.Forms.Padding(2);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(143, 32);
            this.lblMa.TabIndex = 12;
            this.lblMa.Text = "Mã nhân viên:";
            this.lblMa.Click += new System.EventHandler(this.lblMa_Click);
            // 
            // lblHoten
            // 
            this.lblHoten.BackColor = System.Drawing.Color.Transparent;
            this.lblHoten.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblHoten.ForeColor = System.Drawing.Color.Black;
            this.lblHoten.Location = new System.Drawing.Point(411, 166);
            this.lblHoten.Margin = new System.Windows.Forms.Padding(2);
            this.lblHoten.Name = "lblHoten";
            this.lblHoten.Size = new System.Drawing.Size(104, 32);
            this.lblHoten.TabIndex = 11;
            this.lblHoten.Text = "Họ và tên:";
            this.lblHoten.Click += new System.EventHandler(this.lblHoten_Click);
            // 
            // Pic
            // 
            this.Pic.BorderRadius = 20;
            this.Pic.Image = ((System.Drawing.Image)(resources.GetObject("Pic.Image")));
            this.Pic.ImageRotate = 0F;
            this.Pic.Location = new System.Drawing.Point(79, 166);
            this.Pic.Margin = new System.Windows.Forms.Padding(2);
            this.Pic.Name = "Pic";
            this.Pic.Size = new System.Drawing.Size(271, 299);
            this.Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pic.TabIndex = 9;
            this.Pic.TabStop = false;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(351, 47);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(357, 48);
            this.guna2HtmlLabel1.TabIndex = 18;
            this.guna2HtmlLabel1.Text = "TÀI KHOẢN CỦA TÔI";
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1175, 830);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.lblSdt);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.lblCa);
            this.Controls.Add(this.lblCV);
            this.Controls.Add(this.lblMa);
            this.Controls.Add(this.lblHoten);
            this.Controls.Add(this.Pic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Information";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Information";
            this.Load += new System.EventHandler(this.Information_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDiaChi;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSdt;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNgaySinh;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCa;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCV;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMa;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHoten;
        private Guna.UI2.WinForms.Guna2PictureBox Pic;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}