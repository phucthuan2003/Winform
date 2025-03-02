namespace GUI_QuanLy
{
    partial class GUI_TaoHoaDonBan
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
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.panelThongTinMatHang = new System.Windows.Forms.Panel();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.cbMaHang = new System.Windows.Forms.ComboBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.lblTenHang = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblMaHang = new System.Windows.Forms.Label();
            this.panelTongTien = new System.Windows.Forms.Panel();
            this.panelChucNang = new System.Windows.Forms.Panel();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.grbThongTinCacMatHang = new System.Windows.Forms.GroupBox();
            this.dgvDSMatHang = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grbThongTinChung = new System.Windows.Forms.GroupBox();
            this.cbMaKH = new System.Windows.Forms.ComboBox();
            this.txtSDT = new System.Windows.Forms.MaskedTextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.cbMaMV = new System.Windows.Forms.ComboBox();
            this.dtpNgayBan = new System.Windows.Forms.DateTimePicker();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.lblNgayBan = new System.Windows.Forms.Label();
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.lblHoaDonBanHang = new System.Windows.Forms.Label();
            this.lblHDBH = new System.Windows.Forms.Label();
            this.panelThongTinMatHang.SuspendLayout();
            this.panelTongTien.SuspendLayout();
            this.panelChucNang.SuspendLayout();
            this.grbThongTinCacMatHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSMatHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbThongTinChung.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(759, 16);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(2);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(191, 29);
            this.txtTongTien.TabIndex = 11;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblTongTien.Location = new System.Drawing.Point(655, 19);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(94, 25);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "Tổng tiền";
            // 
            // panelThongTinMatHang
            // 
            this.panelThongTinMatHang.Controls.Add(this.txtDonGia);
            this.panelThongTinMatHang.Controls.Add(this.txtGiamGia);
            this.panelThongTinMatHang.Controls.Add(this.txtTenHang);
            this.panelThongTinMatHang.Controls.Add(this.txtSoLuong);
            this.panelThongTinMatHang.Controls.Add(this.cbMaHang);
            this.panelThongTinMatHang.Controls.Add(this.lblDonGia);
            this.panelThongTinMatHang.Controls.Add(this.lblGiamGia);
            this.panelThongTinMatHang.Controls.Add(this.lblTenHang);
            this.panelThongTinMatHang.Controls.Add(this.lblSoLuong);
            this.panelThongTinMatHang.Controls.Add(this.lblMaHang);
            this.panelThongTinMatHang.Location = new System.Drawing.Point(4, 27);
            this.panelThongTinMatHang.Margin = new System.Windows.Forms.Padding(2);
            this.panelThongTinMatHang.Name = "panelThongTinMatHang";
            this.panelThongTinMatHang.Size = new System.Drawing.Size(1019, 84);
            this.panelThongTinMatHang.TabIndex = 1;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(796, 9);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(2);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(191, 29);
            this.txtDonGia.TabIndex = 11;
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Location = new System.Drawing.Point(452, 44);
            this.txtGiamGia.Margin = new System.Windows.Forms.Padding(2);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(191, 29);
            this.txtGiamGia.TabIndex = 10;
            this.txtGiamGia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGiamGia_KeyDown);
            // 
            // txtTenHang
            // 
            this.txtTenHang.Location = new System.Drawing.Point(452, 9);
            this.txtTenHang.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenHang.Name = "txtTenHang";
            this.txtTenHang.ReadOnly = true;
            this.txtTenHang.Size = new System.Drawing.Size(191, 29);
            this.txtTenHang.TabIndex = 9;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(110, 44);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(191, 29);
            this.txtSoLuong.TabIndex = 8;
            this.txtSoLuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoLuong_KeyDown);
            // 
            // cbMaHang
            // 
            this.cbMaHang.FormattingEnabled = true;
            this.cbMaHang.Location = new System.Drawing.Point(110, 9);
            this.cbMaHang.Margin = new System.Windows.Forms.Padding(2);
            this.cbMaHang.Name = "cbMaHang";
            this.cbMaHang.Size = new System.Drawing.Size(191, 29);
            this.cbMaHang.TabIndex = 7;
            this.cbMaHang.SelectedIndexChanged += new System.EventHandler(this.cbMaHang_SelectedIndexChanged);
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblDonGia.Location = new System.Drawing.Point(698, 11);
            this.lblDonGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(70, 21);
            this.lblDonGia.TabIndex = 5;
            this.lblDonGia.Text = "Đơn giá";
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblGiamGia.Location = new System.Drawing.Point(332, 46);
            this.lblGiamGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(108, 21);
            this.lblGiamGia.TabIndex = 4;
            this.lblGiamGia.Text = "Giảm giá (%)";
            // 
            // lblTenHang
            // 
            this.lblTenHang.AutoSize = true;
            this.lblTenHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblTenHang.Location = new System.Drawing.Point(332, 11);
            this.lblTenHang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenHang.Name = "lblTenHang";
            this.lblTenHang.Size = new System.Drawing.Size(80, 21);
            this.lblTenHang.TabIndex = 3;
            this.lblTenHang.Text = "Tên hàng";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblSoLuong.Location = new System.Drawing.Point(25, 46);
            this.lblSoLuong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(79, 21);
            this.lblSoLuong.TabIndex = 2;
            this.lblSoLuong.Text = "Số lượng";
            // 
            // lblMaHang
            // 
            this.lblMaHang.AutoSize = true;
            this.lblMaHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblMaHang.Location = new System.Drawing.Point(25, 11);
            this.lblMaHang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaHang.Name = "lblMaHang";
            this.lblMaHang.Size = new System.Drawing.Size(77, 21);
            this.lblMaHang.TabIndex = 1;
            this.lblMaHang.Text = "Mã hàng";
            // 
            // panelTongTien
            // 
            this.panelTongTien.Controls.Add(this.txtTongTien);
            this.panelTongTien.Controls.Add(this.lblTongTien);
            this.panelTongTien.Location = new System.Drawing.Point(4, 350);
            this.panelTongTien.Margin = new System.Windows.Forms.Padding(2);
            this.panelTongTien.Name = "panelTongTien";
            this.panelTongTien.Size = new System.Drawing.Size(1019, 56);
            this.panelTongTien.TabIndex = 2;
            // 
            // panelChucNang
            // 
            this.panelChucNang.Controls.Add(this.btnIn);
            this.panelChucNang.Controls.Add(this.btnThoat);
            this.panelChucNang.Controls.Add(this.btnXoa);
            this.panelChucNang.Controls.Add(this.btnLuu);
            this.panelChucNang.Location = new System.Drawing.Point(4, 410);
            this.panelChucNang.Margin = new System.Windows.Forms.Padding(2);
            this.panelChucNang.Name = "panelChucNang";
            this.panelChucNang.Size = new System.Drawing.Size(1019, 53);
            this.panelChucNang.TabIndex = 0;
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(41)))), ((int)(((byte)(102)))));
            this.btnIn.FlatAppearance.BorderSize = 2;
            this.btnIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnIn.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.ForeColor = System.Drawing.Color.White;
            this.btnIn.Image = global::GUI_QuanLy.Properties.Resources.Printer;
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(550, 4);
            this.btnIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnIn.Name = "btnIn";
            this.btnIn.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnIn.Size = new System.Drawing.Size(172, 43);
            this.btnIn.TabIndex = 8;
            this.btnIn.Text = "     In hóa đơn";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(41)))), ((int)(((byte)(102)))));
            this.btnThoat.FlatAppearance.BorderSize = 2;
            this.btnThoat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Image = global::GUI_QuanLy.Properties.Resources.Close;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(796, 2);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnThoat.Size = new System.Drawing.Size(172, 43);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "      Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(41)))), ((int)(((byte)(102)))));
            this.btnXoa.FlatAppearance.BorderSize = 2;
            this.btnXoa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Image = global::GUI_QuanLy.Properties.Resources.X;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(297, 4);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnXoa.Size = new System.Drawing.Size(172, 43);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "     Xóa hóa đơn";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(41)))), ((int)(((byte)(102)))));
            this.btnLuu.FlatAppearance.BorderSize = 2;
            this.btnLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Image = global::GUI_QuanLy.Properties.Resources.Save1;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(61, 4);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnLuu.Size = new System.Drawing.Size(172, 43);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "     Lưu hóa đơn";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // grbThongTinCacMatHang
            // 
            this.grbThongTinCacMatHang.Controls.Add(this.dgvDSMatHang);
            this.grbThongTinCacMatHang.Controls.Add(this.panelTongTien);
            this.grbThongTinCacMatHang.Controls.Add(this.panelThongTinMatHang);
            this.grbThongTinCacMatHang.Controls.Add(this.panelChucNang);
            this.grbThongTinCacMatHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTinCacMatHang.Location = new System.Drawing.Point(25, 2);
            this.grbThongTinCacMatHang.Margin = new System.Windows.Forms.Padding(2);
            this.grbThongTinCacMatHang.Name = "grbThongTinCacMatHang";
            this.grbThongTinCacMatHang.Padding = new System.Windows.Forms.Padding(2);
            this.grbThongTinCacMatHang.Size = new System.Drawing.Size(1030, 476);
            this.grbThongTinCacMatHang.TabIndex = 0;
            this.grbThongTinCacMatHang.TabStop = false;
            this.grbThongTinCacMatHang.Text = "  Thông tin các mặt hàng  ";
            // 
            // dgvDSMatHang
            // 
            this.dgvDSMatHang.AllowUserToAddRows = false;
            this.dgvDSMatHang.AllowUserToDeleteRows = false;
            this.dgvDSMatHang.AllowUserToResizeColumns = false;
            this.dgvDSMatHang.AllowUserToResizeRows = false;
            this.dgvDSMatHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSMatHang.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvDSMatHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvDSMatHang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSMatHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDSMatHang.ColumnHeadersHeight = 35;
            this.dgvDSMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDSMatHang.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDSMatHang.GridColor = System.Drawing.Color.Black;
            this.dgvDSMatHang.Location = new System.Drawing.Point(4, 114);
            this.dgvDSMatHang.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDSMatHang.Name = "dgvDSMatHang";
            this.dgvDSMatHang.RowHeadersWidth = 51;
            this.dgvDSMatHang.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDSMatHang.RowTemplate.Height = 24;
            this.dgvDSMatHang.Size = new System.Drawing.Size(1019, 232);
            this.dgvDSMatHang.TabIndex = 3;
            this.dgvDSMatHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSMatHang_CellClick);
            this.dgvDSMatHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSMatHang_CellContentClick);
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grbThongTinCacMatHang);
            this.splitContainer1.Size = new System.Drawing.Size(1080, 718);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 6;
            // 
            // grbThongTinChung
            // 
            this.grbThongTinChung.BackColor = System.Drawing.SystemColors.Control;
            this.grbThongTinChung.Controls.Add(this.cbMaKH);
            this.grbThongTinChung.Controls.Add(this.txtSDT);
            this.grbThongTinChung.Controls.Add(this.txtDiaChi);
            this.grbThongTinChung.Controls.Add(this.txtTenKH);
            this.grbThongTinChung.Controls.Add(this.txtTenNV);
            this.grbThongTinChung.Controls.Add(this.cbMaMV);
            this.grbThongTinChung.Controls.Add(this.dtpNgayBan);
            this.grbThongTinChung.Controls.Add(this.txtMaHD);
            this.grbThongTinChung.Controls.Add(this.lblSDT);
            this.grbThongTinChung.Controls.Add(this.lblDiaChi);
            this.grbThongTinChung.Controls.Add(this.lblTenKH);
            this.grbThongTinChung.Controls.Add(this.lblMaKH);
            this.grbThongTinChung.Controls.Add(this.lblTenNV);
            this.grbThongTinChung.Controls.Add(this.lblMaNV);
            this.grbThongTinChung.Controls.Add(this.lblNgayBan);
            this.grbThongTinChung.Controls.Add(this.lblMaHoaDon);
            this.grbThongTinChung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbThongTinChung.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTinChung.Location = new System.Drawing.Point(25, 35);
            this.grbThongTinChung.Margin = new System.Windows.Forms.Padding(2);
            this.grbThongTinChung.Name = "grbThongTinChung";
            this.grbThongTinChung.Padding = new System.Windows.Forms.Padding(2);
            this.grbThongTinChung.Size = new System.Drawing.Size(1030, 184);
            this.grbThongTinChung.TabIndex = 1;
            this.grbThongTinChung.TabStop = false;
            this.grbThongTinChung.Text = "   Thông tin chung   ";
            // 
            // cbMaKH
            // 
            this.cbMaKH.FormattingEnabled = true;
            this.cbMaKH.Location = new System.Drawing.Point(695, 29);
            this.cbMaKH.Margin = new System.Windows.Forms.Padding(2);
            this.cbMaKH.Name = "cbMaKH";
            this.cbMaKH.Size = new System.Drawing.Size(241, 29);
            this.cbMaKH.TabIndex = 15;
            this.cbMaKH.SelectedIndexChanged += new System.EventHandler(this.cbMaKH_SelectedIndexChanged);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(695, 139);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(2);
            this.txtSDT.Mask = "(999) 000-0000";
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(241, 29);
            this.txtSDT.TabIndex = 14;
            this.txtSDT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSDT_KeyDown);
            this.txtSDT.Leave += new System.EventHandler(this.txtSDT_Leave);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(695, 103);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(241, 29);
            this.txtDiaChi.TabIndex = 13;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(695, 69);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(241, 29);
            this.txtTenKH.TabIndex = 12;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(145, 137);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.ReadOnly = true;
            this.txtTenNV.Size = new System.Drawing.Size(240, 29);
            this.txtTenNV.TabIndex = 11;
            // 
            // cbMaMV
            // 
            this.cbMaMV.FormattingEnabled = true;
            this.cbMaMV.Location = new System.Drawing.Point(145, 103);
            this.cbMaMV.Margin = new System.Windows.Forms.Padding(2);
            this.cbMaMV.Name = "cbMaMV";
            this.cbMaMV.Size = new System.Drawing.Size(241, 29);
            this.cbMaMV.TabIndex = 10;
            // 
            // dtpNgayBan
            // 
            this.dtpNgayBan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBan.Location = new System.Drawing.Point(145, 67);
            this.dtpNgayBan.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayBan.Name = "dtpNgayBan";
            this.dtpNgayBan.Size = new System.Drawing.Size(241, 29);
            this.dtpNgayBan.TabIndex = 9;
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(145, 35);
            this.txtMaHD.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(241, 29);
            this.txtMaHD.TabIndex = 8;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblSDT.Location = new System.Drawing.Point(550, 140);
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
            this.lblDiaChi.Location = new System.Drawing.Point(550, 106);
            this.lblDiaChi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(63, 21);
            this.lblDiaChi.TabIndex = 6;
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblTenKH.Location = new System.Drawing.Point(550, 72);
            this.lblTenKH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(130, 21);
            this.lblTenKH.TabIndex = 5;
            this.lblTenKH.Text = "Tên khách hàng";
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblMaKH.Location = new System.Drawing.Point(550, 37);
            this.lblMaKH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(127, 21);
            this.lblMaKH.TabIndex = 4;
            this.lblMaKH.Text = "Mã khách hàng";
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
            // lblNgayBan
            // 
            this.lblNgayBan.AutoSize = true;
            this.lblNgayBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(69)))), ((int)(((byte)(136)))));
            this.lblNgayBan.Location = new System.Drawing.Point(27, 72);
            this.lblNgayBan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgayBan.Name = "lblNgayBan";
            this.lblNgayBan.Size = new System.Drawing.Size(84, 21);
            this.lblNgayBan.TabIndex = 1;
            this.lblNgayBan.Text = "Ngày bán";
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
            // lblHoaDonBanHang
            // 
            this.lblHoaDonBanHang.AutoSize = true;
            this.lblHoaDonBanHang.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoaDonBanHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(64)))), ((int)(((byte)(118)))));
            this.lblHoaDonBanHang.Location = new System.Drawing.Point(424, 7);
            this.lblHoaDonBanHang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHoaDonBanHang.Name = "lblHoaDonBanHang";
            this.lblHoaDonBanHang.Size = new System.Drawing.Size(241, 30);
            this.lblHoaDonBanHang.TabIndex = 0;
            this.lblHoaDonBanHang.Text = "HÓA ĐƠN BÁN HÀNG";
            // 
            // lblHDBH
            // 
            this.lblHDBH.AutoSize = true;
            this.lblHDBH.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHDBH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(64)))), ((int)(((byte)(118)))));
            this.lblHDBH.Location = new System.Drawing.Point(439, 15);
            this.lblHDBH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHDBH.Name = "lblHDBH";
            this.lblHDBH.Size = new System.Drawing.Size(223, 28);
            this.lblHDBH.TabIndex = 5;
            this.lblHDBH.Text = "HÓA ĐƠN BÁN HÀNG";
            this.lblHDBH.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GUI_TaoHoaDonBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 718);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblHDBH);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GUI_TaoHoaDonBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GUI_TaoHoaDonBan";
            this.Load += new System.EventHandler(this.GUI_TaoHoaDonBan_Load);
            this.panelThongTinMatHang.ResumeLayout(false);
            this.panelThongTinMatHang.PerformLayout();
            this.panelTongTien.ResumeLayout(false);
            this.panelTongTien.PerformLayout();
            this.panelChucNang.ResumeLayout(false);
            this.grbThongTinCacMatHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSMatHang)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbThongTinChung.ResumeLayout(false);
            this.grbThongTinChung.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Panel panelThongTinMatHang;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.ComboBox cbMaHang;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.Label lblTenHang;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblMaHang;
        private System.Windows.Forms.Panel panelTongTien;
        private System.Windows.Forms.Panel panelChucNang;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.GroupBox grbThongTinCacMatHang;
        private System.Windows.Forms.DataGridView dgvDSMatHang;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grbThongTinChung;
        private System.Windows.Forms.ComboBox cbMaKH;
        private System.Windows.Forms.MaskedTextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.ComboBox cbMaMV;
        private System.Windows.Forms.DateTimePicker dtpNgayBan;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.Label lblNgayBan;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.Label lblHoaDonBanHang;
        private System.Windows.Forms.Label lblHDBH;
        private System.Windows.Forms.Button btnIn;
    }
}