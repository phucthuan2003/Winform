namespace GUI_QuanLy
{
    partial class GUI_ChiTietHDN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHoaDonBanHang = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.MaskedTextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.grbThongTinChung = new System.Windows.Forms.GroupBox();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblTenNCC = new System.Windows.Forms.Label();
            this.lblMaNCC = new System.Windows.Forms.Label();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.dgvDSMatHang = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grbThongTinCacMatHang = new System.Windows.Forms.GroupBox();
            this.btnQuayVe = new System.Windows.Forms.Button();
            this.panelTongTien = new System.Windows.Forms.Panel();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.grbThongTinChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSMatHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbThongTinCacMatHang.SuspendLayout();
            this.panelTongTien.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHoaDonBanHang
            // 
            this.lblHoaDonBanHang.AutoSize = true;
            this.lblHoaDonBanHang.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoaDonBanHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(64)))), ((int)(((byte)(118)))));
            this.lblHoaDonBanHang.Location = new System.Drawing.Point(282, 7);
            this.lblHoaDonBanHang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHoaDonBanHang.Name = "lblHoaDonBanHang";
            this.lblHoaDonBanHang.Size = new System.Drawing.Size(213, 30);
            this.lblHoaDonBanHang.TabIndex = 0;
            this.lblHoaDonBanHang.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(145, 100);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(180, 29);
            this.txtMaNV.TabIndex = 16;
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Location = new System.Drawing.Point(499, 34);
            this.txtMaNCC.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.ReadOnly = true;
            this.txtMaNCC.Size = new System.Drawing.Size(241, 29);
            this.txtMaNCC.TabIndex = 15;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(499, 139);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(2);
            this.txtSDT.Mask = "(999) 000-0000";
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.ReadOnly = true;
            this.txtSDT.Size = new System.Drawing.Size(241, 29);
            this.txtSDT.TabIndex = 14;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(499, 102);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.ReadOnly = true;
            this.txtDiaChi.Size = new System.Drawing.Size(241, 29);
            this.txtDiaChi.TabIndex = 13;
            // 
            // grbThongTinChung
            // 
            this.grbThongTinChung.BackColor = System.Drawing.SystemColors.Control;
            this.grbThongTinChung.Controls.Add(this.txtMaNV);
            this.grbThongTinChung.Controls.Add(this.txtMaNCC);
            this.grbThongTinChung.Controls.Add(this.txtSDT);
            this.grbThongTinChung.Controls.Add(this.txtDiaChi);
            this.grbThongTinChung.Controls.Add(this.txtTenNCC);
            this.grbThongTinChung.Controls.Add(this.txtTenNV);
            this.grbThongTinChung.Controls.Add(this.dtpNgayNhap);
            this.grbThongTinChung.Controls.Add(this.txtMaHD);
            this.grbThongTinChung.Controls.Add(this.lblSDT);
            this.grbThongTinChung.Controls.Add(this.lblDiaChi);
            this.grbThongTinChung.Controls.Add(this.lblTenNCC);
            this.grbThongTinChung.Controls.Add(this.lblMaNCC);
            this.grbThongTinChung.Controls.Add(this.lblTenNV);
            this.grbThongTinChung.Controls.Add(this.lblMaNV);
            this.grbThongTinChung.Controls.Add(this.lblNgayNhap);
            this.grbThongTinChung.Controls.Add(this.lblMaHoaDon);
            this.grbThongTinChung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbThongTinChung.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTinChung.Location = new System.Drawing.Point(22, 64);
            this.grbThongTinChung.Margin = new System.Windows.Forms.Padding(2);
            this.grbThongTinChung.Name = "grbThongTinChung";
            this.grbThongTinChung.Padding = new System.Windows.Forms.Padding(2);
            this.grbThongTinChung.Size = new System.Drawing.Size(748, 172);
            this.grbThongTinChung.TabIndex = 1;
            this.grbThongTinChung.TabStop = false;
            this.grbThongTinChung.Text = "   Thông tin chung   ";
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(499, 69);
            this.txtTenNCC.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.ReadOnly = true;
            this.txtTenNCC.Size = new System.Drawing.Size(241, 29);
            this.txtTenNCC.TabIndex = 12;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(145, 137);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.ReadOnly = true;
            this.txtTenNV.Size = new System.Drawing.Size(180, 29);
            this.txtTenNV.TabIndex = 11;
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(145, 67);
            this.dtpNgayNhap.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(180, 29);
            this.dtpNgayNhap.TabIndex = 9;
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(145, 35);
            this.txtMaHD.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(180, 29);
            this.txtMaHD.TabIndex = 8;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblSDT.Location = new System.Drawing.Point(353, 140);
            this.lblSDT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(111, 21);
            this.lblSDT.TabIndex = 7;
            this.lblSDT.Text = "Số điện thoại";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblDiaChi.Location = new System.Drawing.Point(353, 106);
            this.lblDiaChi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(63, 21);
            this.lblDiaChi.TabIndex = 6;
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // lblTenNCC
            // 
            this.lblTenNCC.AutoSize = true;
            this.lblTenNCC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblTenNCC.Location = new System.Drawing.Point(353, 72);
            this.lblTenNCC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenNCC.Name = "lblTenNCC";
            this.lblTenNCC.Size = new System.Drawing.Size(143, 21);
            this.lblTenNCC.TabIndex = 5;
            this.lblTenNCC.Text = "Tên nhà cung cấp";
            // 
            // lblMaNCC
            // 
            this.lblMaNCC.AutoSize = true;
            this.lblMaNCC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblMaNCC.Location = new System.Drawing.Point(353, 37);
            this.lblMaNCC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaNCC.Name = "lblMaNCC";
            this.lblMaNCC.Size = new System.Drawing.Size(140, 21);
            this.lblMaNCC.TabIndex = 4;
            this.lblMaNCC.Text = "Mã nhà cung cấp";
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblTenNV.Location = new System.Drawing.Point(27, 140);
            this.lblTenNV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(117, 21);
            this.lblTenNV.TabIndex = 3;
            this.lblTenNV.Text = "Tên nhân viên";
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblMaNV.Location = new System.Drawing.Point(27, 106);
            this.lblMaNV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(114, 21);
            this.lblMaNV.TabIndex = 2;
            this.lblMaNV.Text = "Mã nhân viên";
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblNgayNhap.Location = new System.Drawing.Point(27, 72);
            this.lblNgayNhap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(94, 21);
            this.lblNgayNhap.TabIndex = 1;
            this.lblNgayNhap.Text = "Ngày nhập";
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.AutoSize = true;
            this.lblMaHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblMaHoaDon.Location = new System.Drawing.Point(27, 37);
            this.lblMaHoaDon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(101, 21);
            this.lblMaHoaDon.TabIndex = 0;
            this.lblMaHoaDon.Text = "Mã hóa đơn";
            // 
            // dgvDSMatHang
            // 
            this.dgvDSMatHang.AllowUserToAddRows = false;
            this.dgvDSMatHang.AllowUserToDeleteRows = false;
            this.dgvDSMatHang.AllowUserToResizeColumns = false;
            this.dgvDSMatHang.AllowUserToResizeRows = false;
            this.dgvDSMatHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSMatHang.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dgvDSMatHang.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSMatHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDSMatHang.ColumnHeadersHeight = 35;
            this.dgvDSMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDSMatHang.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDSMatHang.Location = new System.Drawing.Point(12, 30);
            this.dgvDSMatHang.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDSMatHang.Name = "dgvDSMatHang";
            this.dgvDSMatHang.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSMatHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDSMatHang.RowHeadersWidth = 51;
            this.dgvDSMatHang.RowTemplate.Height = 24;
            this.dgvDSMatHang.Size = new System.Drawing.Size(725, 274);
            this.dgvDSMatHang.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grbThongTinChung);
            this.splitContainer1.Panel1.Controls.Add(this.lblHoaDonBanHang);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grbThongTinCacMatHang);
            this.splitContainer1.Size = new System.Drawing.Size(775, 682);
            this.splitContainer1.SplitterDistance = 247;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 8;
            // 
            // grbThongTinCacMatHang
            // 
            this.grbThongTinCacMatHang.Controls.Add(this.btnIn);
            this.grbThongTinCacMatHang.Controls.Add(this.dgvDSMatHang);
            this.grbThongTinCacMatHang.Controls.Add(this.btnQuayVe);
            this.grbThongTinCacMatHang.Controls.Add(this.panelTongTien);
            this.grbThongTinCacMatHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTinCacMatHang.Location = new System.Drawing.Point(22, 11);
            this.grbThongTinCacMatHang.Margin = new System.Windows.Forms.Padding(2);
            this.grbThongTinCacMatHang.Name = "grbThongTinCacMatHang";
            this.grbThongTinCacMatHang.Padding = new System.Windows.Forms.Padding(2);
            this.grbThongTinCacMatHang.Size = new System.Drawing.Size(748, 410);
            this.grbThongTinCacMatHang.TabIndex = 0;
            this.grbThongTinCacMatHang.TabStop = false;
            this.grbThongTinCacMatHang.Text = "  Thông tin các mặt hàng  ";
            // 
            // btnQuayVe
            // 
            this.btnQuayVe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(41)))), ((int)(((byte)(102)))));
            this.btnQuayVe.FlatAppearance.BorderSize = 2;
            this.btnQuayVe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnQuayVe.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayVe.ForeColor = System.Drawing.Color.White;
            this.btnQuayVe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuayVe.Location = new System.Drawing.Point(453, 360);
            this.btnQuayVe.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuayVe.Name = "btnQuayVe";
            this.btnQuayVe.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnQuayVe.Size = new System.Drawing.Size(150, 43);
            this.btnQuayVe.TabIndex = 3;
            this.btnQuayVe.Text = "Quay về";
            this.btnQuayVe.UseVisualStyleBackColor = false;
            this.btnQuayVe.Click += new System.EventHandler(this.btnQuayVe_Click);
            // 
            // panelTongTien
            // 
            this.panelTongTien.Controls.Add(this.txtTongTien);
            this.panelTongTien.Controls.Add(this.lblTongTien);
            this.panelTongTien.Location = new System.Drawing.Point(12, 300);
            this.panelTongTien.Margin = new System.Windows.Forms.Padding(2);
            this.panelTongTien.Name = "panelTongTien";
            this.panelTongTien.Size = new System.Drawing.Size(725, 56);
            this.panelTongTien.TabIndex = 2;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(465, 19);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(251, 29);
            this.txtTongTien.TabIndex = 11;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblTongTien.Location = new System.Drawing.Point(367, 23);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(94, 25);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "Tổng tiền";
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(41)))), ((int)(((byte)(102)))));
            this.btnIn.FlatAppearance.BorderSize = 2;
            this.btnIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnIn.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.ForeColor = System.Drawing.Color.White;
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(145, 360);
            this.btnIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnIn.Name = "btnIn";
            this.btnIn.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnIn.Size = new System.Drawing.Size(150, 43);
            this.btnIn.TabIndex = 4;
            this.btnIn.Text = "In hóa đơn";
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // GUI_ChiTietHDN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 682);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GUI_ChiTietHDN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GUI_ChiTietHDN";
            this.grbThongTinChung.ResumeLayout(false);
            this.grbThongTinChung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSMatHang)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbThongTinCacMatHang.ResumeLayout(false);
            this.panelTongTien.ResumeLayout(false);
            this.panelTongTien.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHoaDonBanHang;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.MaskedTextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.GroupBox grbThongTinChung;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblTenNCC;
        private System.Windows.Forms.Label lblMaNCC;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.DataGridView dgvDSMatHang;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grbThongTinCacMatHang;
        private System.Windows.Forms.Panel panelTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnQuayVe;
        private System.Windows.Forms.Button btnIn;
    }
}