namespace GUI_QuanLy
{
    partial class GUI_HoaDonBan
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtND = new System.Windows.Forms.TextBox();
            this.lblNhapTimKiem = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.panelTimKiem = new System.Windows.Forms.Panel();
            this.dgvDSHDB = new System.Windows.Forms.DataGridView();
            this.panelSLHoaDon = new System.Windows.Forms.Panel();
            this.txtSLHDB = new System.Windows.Forms.TextBox();
            this.lblLHDB = new System.Windows.Forms.Label();
            this.btnXuatFileExcel = new System.Windows.Forms.Button();
            this.btnThemHoaDon = new System.Windows.Forms.Button();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.hoaDon = new GUI_QuanLy.HoaDon();
            this.hoaDonBanBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.hoaDonBanTableAdapter = new GUI_QuanLy.HoaDonTableAdapters.HoaDonBanTableAdapter();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.hoaDonBanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dBdsHDBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBLTTQDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soHDBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maNVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayBanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maKhachDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongTienDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giamGiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiTiet = new System.Windows.Forms.DataGridViewImageColumn();
            this.Xoa = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHDB)).BeginInit();
            this.panelSLHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDonBanBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDonBanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBdsHDBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBLTTQDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNam
            // 
            this.txtNam.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam.Location = new System.Drawing.Point(281, 90);
            this.txtNam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(105, 33);
            this.txtNam.TabIndex = 7;
            // 
            // txtThang
            // 
            this.txtThang.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThang.Location = new System.Drawing.Point(107, 90);
            this.txtThang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(85, 33);
            this.txtThang.TabIndex = 6;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNgay.ForeColor = System.Drawing.Color.Black;
            this.lblDenNgay.Location = new System.Drawing.Point(221, 93);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(54, 25);
            this.lblDenNgay.TabIndex = 5;
            this.lblDenNgay.Text = "Năm";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Black;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(127, 151);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(129, 44);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtND
            // 
            this.txtND.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtND.Location = new System.Drawing.Point(186, 22);
            this.txtND.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtND.Name = "txtND";
            this.txtND.Size = new System.Drawing.Size(200, 33);
            this.txtND.TabIndex = 3;
            // 
            // lblNhapTimKiem
            // 
            this.lblNhapTimKiem.AutoSize = true;
            this.lblNhapTimKiem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhapTimKiem.ForeColor = System.Drawing.Color.Black;
            this.lblNhapTimKiem.Location = new System.Drawing.Point(33, 93);
            this.lblNhapTimKiem.Name = "lblNhapTimKiem";
            this.lblNhapTimKiem.Size = new System.Drawing.Size(68, 25);
            this.lblNhapTimKiem.TabIndex = 2;
            this.lblNhapTimKiem.Text = "Tháng";
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiem.ForeColor = System.Drawing.Color.Black;
            this.lblTimKiem.Location = new System.Drawing.Point(33, 25);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(147, 25);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Nhập nội dung";
            // 
            // panelTimKiem
            // 
            this.panelTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelTimKiem.Controls.Add(this.txtNam);
            this.panelTimKiem.Controls.Add(this.txtThang);
            this.panelTimKiem.Controls.Add(this.lblDenNgay);
            this.panelTimKiem.Controls.Add(this.btnTimKiem);
            this.panelTimKiem.Controls.Add(this.txtND);
            this.panelTimKiem.Controls.Add(this.lblNhapTimKiem);
            this.panelTimKiem.Controls.Add(this.lblTimKiem);
            this.panelTimKiem.Location = new System.Drawing.Point(89, 8);
            this.panelTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTimKiem.Name = "panelTimKiem";
            this.panelTimKiem.Size = new System.Drawing.Size(417, 225);
            this.panelTimKiem.TabIndex = 13;
            // 
            // dgvDSHDB
            // 
            this.dgvDSHDB.AllowUserToAddRows = false;
            this.dgvDSHDB.AllowUserToDeleteRows = false;
            this.dgvDSHDB.AllowUserToResizeColumns = false;
            this.dgvDSHDB.AllowUserToResizeRows = false;
            this.dgvDSHDB.AutoGenerateColumns = false;
            this.dgvDSHDB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSHDB.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvDSHDB.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDSHDB.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSHDB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSHDB.ColumnHeadersHeight = 35;
            this.dgvDSHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDSHDB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.soHDBDataGridViewTextBoxColumn,
            this.maNVDataGridViewTextBoxColumn,
            this.ngayBanDataGridViewTextBoxColumn,
            this.maKhachDataGridViewTextBoxColumn,
            this.tongTienDataGridViewTextBoxColumn,
            this.giamGiaDataGridViewTextBoxColumn,
            this.ChiTiet,
            this.Xoa});
            this.dgvDSHDB.DataSource = this.hoaDonBanBindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDSHDB.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDSHDB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDSHDB.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDSHDB.GridColor = System.Drawing.Color.Black;
            this.dgvDSHDB.Location = new System.Drawing.Point(0, 307);
            this.dgvDSHDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDSHDB.Name = "dgvDSHDB";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSHDB.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDSHDB.RowHeadersWidth = 51;
            this.dgvDSHDB.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDSHDB.RowTemplate.Height = 24;
            this.dgvDSHDB.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDSHDB.Size = new System.Drawing.Size(1175, 523);
            this.dgvDSHDB.TabIndex = 14;
            this.dgvDSHDB.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSHDB_CellContentClick);
            // 
            // panelSLHoaDon
            // 
            this.panelSLHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSLHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelSLHoaDon.Controls.Add(this.txtSLHDB);
            this.panelSLHoaDon.Controls.Add(this.lblLHDB);
            this.panelSLHoaDon.Location = new System.Drawing.Point(740, 9);
            this.panelSLHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelSLHoaDon.Name = "panelSLHoaDon";
            this.panelSLHoaDon.Size = new System.Drawing.Size(355, 155);
            this.panelSLHoaDon.TabIndex = 17;
            // 
            // txtSLHDB
            // 
            this.txtSLHDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSLHDB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSLHDB.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLHDB.ForeColor = System.Drawing.Color.Black;
            this.txtSLHDB.Location = new System.Drawing.Point(71, 61);
            this.txtSLHDB.Margin = new System.Windows.Forms.Padding(4);
            this.txtSLHDB.Name = "txtSLHDB";
            this.txtSLHDB.Size = new System.Drawing.Size(207, 64);
            this.txtSLHDB.TabIndex = 3;
            this.txtSLHDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLHDB
            // 
            this.lblLHDB.AutoSize = true;
            this.lblLHDB.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLHDB.ForeColor = System.Drawing.Color.Black;
            this.lblLHDB.Location = new System.Drawing.Point(25, 22);
            this.lblLHDB.Name = "lblLHDB";
            this.lblLHDB.Size = new System.Drawing.Size(178, 25);
            this.lblLHDB.TabIndex = 1;
            this.lblLHDB.Text = "Số lượng hóa đơn:";
            // 
            // btnXuatFileExcel
            // 
            this.btnXuatFileExcel.BackColor = System.Drawing.Color.Black;
            this.btnXuatFileExcel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatFileExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatFileExcel.Location = new System.Drawing.Point(931, 177);
            this.btnXuatFileExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXuatFileExcel.Name = "btnXuatFileExcel";
            this.btnXuatFileExcel.Size = new System.Drawing.Size(164, 56);
            this.btnXuatFileExcel.TabIndex = 16;
            this.btnXuatFileExcel.Text = "Xuất DS Excel";
            this.btnXuatFileExcel.UseVisualStyleBackColor = false;
            this.btnXuatFileExcel.Click += new System.EventHandler(this.btnXuatFileExcel_Click);
            // 
            // btnThemHoaDon
            // 
            this.btnThemHoaDon.BackColor = System.Drawing.Color.Black;
            this.btnThemHoaDon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnThemHoaDon.Location = new System.Drawing.Point(740, 177);
            this.btnThemHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemHoaDon.Name = "btnThemHoaDon";
            this.btnThemHoaDon.Size = new System.Drawing.Size(164, 56);
            this.btnThemHoaDon.TabIndex = 15;
            this.btnThemHoaDon.Text = "Thêm hóa đơn";
            this.btnThemHoaDon.UseVisualStyleBackColor = false;
            this.btnThemHoaDon.Click += new System.EventHandler(this.btnThemHoaDon_Click);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.BackColor = System.Drawing.Color.White;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.Black;
            this.lblTieuDe.Location = new System.Drawing.Point(386, 249);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(454, 45);
            this.lblTieuDe.TabIndex = 18;
            this.lblTieuDe.Text = "DANH SÁCH HÓA ĐƠN BÁN";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // hoaDon
            // 
            this.hoaDon.DataSetName = "HoaDon";
            this.hoaDon.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hoaDonBanBindingSource1
            // 
            this.hoaDonBanBindingSource1.DataMember = "HoaDonBan";
            this.hoaDonBanBindingSource1.DataSource = this.hoaDon;
            // 
            // hoaDonBanTableAdapter
            // 
            this.hoaDonBanTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.FillWeight = 3.214872F;
            this.dataGridViewImageColumn1.HeaderText = "Chi tiết";
            this.dataGridViewImageColumn1.Image = global::GUI_QuanLy.Properties.Resources.View_Details;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 5;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn2.FillWeight = 3.214872F;
            this.dataGridViewImageColumn2.HeaderText = "Sửa";
            this.dataGridViewImageColumn2.Image = global::GUI_QuanLy.Properties.Resources.Edit1;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 5;
            // 
            // hoaDonBanBindingSource
            // 
            this.hoaDonBanBindingSource.DataMember = "HoaDonBan";
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn3.FillWeight = 3.214872F;
            this.dataGridViewImageColumn3.HeaderText = "Xóa";
            this.dataGridViewImageColumn3.Image = global::GUI_QuanLy.Properties.Resources.Delete1;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Width = 5;
            // 
            // STT
            // 
            this.STT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // soHDBDataGridViewTextBoxColumn
            // 
            this.soHDBDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.soHDBDataGridViewTextBoxColumn.DataPropertyName = "SoHDB";
            this.soHDBDataGridViewTextBoxColumn.HeaderText = "Số HĐB";
            this.soHDBDataGridViewTextBoxColumn.Name = "soHDBDataGridViewTextBoxColumn";
            this.soHDBDataGridViewTextBoxColumn.Width = 200;
            // 
            // maNVDataGridViewTextBoxColumn
            // 
            this.maNVDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.maNVDataGridViewTextBoxColumn.DataPropertyName = "MaNV";
            this.maNVDataGridViewTextBoxColumn.HeaderText = "Mã Nhân Viên";
            this.maNVDataGridViewTextBoxColumn.Name = "maNVDataGridViewTextBoxColumn";
            this.maNVDataGridViewTextBoxColumn.Visible = false;
            this.maNVDataGridViewTextBoxColumn.Width = 150;
            // 
            // ngayBanDataGridViewTextBoxColumn
            // 
            this.ngayBanDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ngayBanDataGridViewTextBoxColumn.DataPropertyName = "NgayBan";
            this.ngayBanDataGridViewTextBoxColumn.HeaderText = "Ngày Bán";
            this.ngayBanDataGridViewTextBoxColumn.Name = "ngayBanDataGridViewTextBoxColumn";
            this.ngayBanDataGridViewTextBoxColumn.Width = 200;
            // 
            // maKhachDataGridViewTextBoxColumn
            // 
            this.maKhachDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.maKhachDataGridViewTextBoxColumn.DataPropertyName = "MaKhach";
            this.maKhachDataGridViewTextBoxColumn.HeaderText = "Mã Khách Hàng";
            this.maKhachDataGridViewTextBoxColumn.Name = "maKhachDataGridViewTextBoxColumn";
            this.maKhachDataGridViewTextBoxColumn.Visible = false;
            this.maKhachDataGridViewTextBoxColumn.Width = 120;
            // 
            // tongTienDataGridViewTextBoxColumn
            // 
            this.tongTienDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tongTienDataGridViewTextBoxColumn.DataPropertyName = "TongTien";
            this.tongTienDataGridViewTextBoxColumn.HeaderText = "Tổng Tiền";
            this.tongTienDataGridViewTextBoxColumn.Name = "tongTienDataGridViewTextBoxColumn";
            this.tongTienDataGridViewTextBoxColumn.Width = 200;
            // 
            // giamGiaDataGridViewTextBoxColumn
            // 
            this.giamGiaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.giamGiaDataGridViewTextBoxColumn.DataPropertyName = "GiamGia";
            this.giamGiaDataGridViewTextBoxColumn.HeaderText = "Giảm Giá";
            this.giamGiaDataGridViewTextBoxColumn.Name = "giamGiaDataGridViewTextBoxColumn";
            this.giamGiaDataGridViewTextBoxColumn.Width = 200;
            // 
            // ChiTiet
            // 
            this.ChiTiet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ChiTiet.FillWeight = 4.075782F;
            this.ChiTiet.HeaderText = "Chi Tiết";
            this.ChiTiet.Image = global::GUI_QuanLy.Properties.Resources.View_Details;
            this.ChiTiet.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ChiTiet.Name = "ChiTiet";
            this.ChiTiet.Width = 90;
            // 
            // Xoa
            // 
            this.Xoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Xoa.FillWeight = 4.075782F;
            this.Xoa.HeaderText = "Xóa";
            this.Xoa.Image = global::GUI_QuanLy.Properties.Resources.Delete1;
            this.Xoa.Name = "Xoa";
            this.Xoa.Width = 90;
            // 
            // GUI_HoaDonBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1175, 830);
            this.Controls.Add(this.panelTimKiem);
            this.Controls.Add(this.dgvDSHDB);
            this.Controls.Add(this.panelSLHoaDon);
            this.Controls.Add(this.btnXuatFileExcel);
            this.Controls.Add(this.btnThemHoaDon);
            this.Controls.Add(this.lblTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GUI_HoaDonBan";
            this.Text = "GUI_HoaDonBan";
            this.Load += new System.EventHandler(this.GUI_HoaDonBan_Load);
            this.panelTimKiem.ResumeLayout(false);
            this.panelTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHDB)).EndInit();
            this.panelSLHoaDon.ResumeLayout(false);
            this.panelSLHoaDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDonBanBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDonBanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBdsHDBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBLTTQDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtND;
        private System.Windows.Forms.Label lblNhapTimKiem;
        private System.Windows.Forms.BindingSource dBdsHDBBindingSource;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Panel panelTimKiem;
        private System.Windows.Forms.DataGridView dgvDSHDB;
        private System.Windows.Forms.BindingSource hoaDonBanBindingSource;
        private System.Windows.Forms.Panel panelSLHoaDon;
        private System.Windows.Forms.TextBox txtSLHDB;
        private System.Windows.Forms.Label lblLHDB;
        private System.Windows.Forms.Button btnXuatFileExcel;
        private System.Windows.Forms.Button btnThemHoaDon;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.BindingSource dBLTTQDataSetBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiamGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhach;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private HoaDon hoaDon;
        private System.Windows.Forms.BindingSource hoaDonBanBindingSource1;
        private HoaDonTableAdapters.HoaDonBanTableAdapter hoaDonBanTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn soHDBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayBanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maKhachDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongTienDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn giamGiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn ChiTiet;
        private System.Windows.Forms.DataGridViewImageColumn Xoa;
    }
}