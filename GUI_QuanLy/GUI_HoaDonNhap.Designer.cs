namespace GUI_QuanLy
{
    partial class GUI_HoaDonNhap
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDSHDN = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiTiet = new System.Windows.Forms.DataGridViewImageColumn();
            this.Xoa = new System.Windows.Forms.DataGridViewImageColumn();
            this.hoaDonNhapBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dB_LTTQDataSet = new GUI_QuanLy.DB_LTTQDataSet();
            this.panelTimKiem = new System.Windows.Forms.Panel();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtND = new System.Windows.Forms.TextBox();
            this.lblNhapND = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.panelSLHoaDon = new System.Windows.Forms.Panel();
            this.txtSLHDN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXuatFileExcel = new System.Windows.Forms.Button();
            this.btnThemHoaDon = new System.Windows.Forms.Button();
            this.hoaDonNhapTableAdapter = new GUI_QuanLy.DB_LTTQDataSetTableAdapters.HoaDonNhapTableAdapter();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDonNhapBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_LTTQDataSet)).BeginInit();
            this.panelTimKiem.SuspendLayout();
            this.panelSLHoaDon.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDSHDN
            // 
            this.dgvDSHDN.AllowUserToAddRows = false;
            this.dgvDSHDN.AllowUserToDeleteRows = false;
            this.dgvDSHDN.AllowUserToResizeColumns = false;
            this.dgvDSHDN.AllowUserToResizeRows = false;
            this.dgvDSHDN.AutoGenerateColumns = false;
            this.dgvDSHDN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSHDN.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvDSHDN.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDSHDN.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSHDN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDSHDN.ColumnHeadersHeight = 35;
            this.dgvDSHDN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDSHDN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.SoHDN,
            this.MaNV,
            this.NgayNhap,
            this.MaNCC,
            this.TongTien,
            this.ChiTiet,
            this.Xoa});
            this.dgvDSHDN.DataSource = this.hoaDonNhapBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDSHDN.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDSHDN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDSHDN.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDSHDN.GridColor = System.Drawing.SystemColors.Info;
            this.dgvDSHDN.Location = new System.Drawing.Point(0, 322);
            this.dgvDSHDN.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDSHDN.Name = "dgvDSHDN";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSHDN.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDSHDN.RowHeadersWidth = 51;
            this.dgvDSHDN.RowTemplate.Height = 24;
            this.dgvDSHDN.Size = new System.Drawing.Size(1175, 508);
            this.dgvDSHDN.TabIndex = 7;
            this.dgvDSHDN.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSHDN_CellContentClick);
            // 
            // STT
            // 
            this.STT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 150;
            // 
            // SoHDN
            // 
            this.SoHDN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SoHDN.DataPropertyName = "SoHDN";
            this.SoHDN.HeaderText = "Số HĐN";
            this.SoHDN.Name = "SoHDN";
            this.SoHDN.Width = 250;
            // 
            // MaNV
            // 
            this.MaNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã Nhân Viên";
            this.MaNV.Name = "MaNV";
            this.MaNV.Visible = false;
            // 
            // NgayNhap
            // 
            this.NgayNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NgayNhap.DataPropertyName = "NgayNhap";
            this.NgayNhap.HeaderText = "Ngày Nhập";
            this.NgayNhap.Name = "NgayNhap";
            this.NgayNhap.Width = 200;
            // 
            // MaNCC
            // 
            this.MaNCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MaNCC.DataPropertyName = "MaNCC";
            this.MaNCC.HeaderText = "Mã Nhà Cung Cấp";
            this.MaNCC.Name = "MaNCC";
            this.MaNCC.Visible = false;
            // 
            // TongTien
            // 
            this.TongTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TongTien.DataPropertyName = "TongTien";
            this.TongTien.HeaderText = "Tổng Tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.Width = 300;
            // 
            // ChiTiet
            // 
            this.ChiTiet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ChiTiet.HeaderText = "Chi Tiết";
            this.ChiTiet.Image = global::GUI_QuanLy.Properties.Resources.View_Details;
            this.ChiTiet.Name = "ChiTiet";
            this.ChiTiet.ReadOnly = true;
            this.ChiTiet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ChiTiet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Xoa
            // 
            this.Xoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Xoa.HeaderText = "Xóa";
            this.Xoa.Image = global::GUI_QuanLy.Properties.Resources.Delete1;
            this.Xoa.Name = "Xoa";
            this.Xoa.ReadOnly = true;
            // 
            // hoaDonNhapBindingSource
            // 
            this.hoaDonNhapBindingSource.DataMember = "HoaDonNhap";
            this.hoaDonNhapBindingSource.DataSource = this.dB_LTTQDataSet;
            // 
            // dB_LTTQDataSet
            // 
            this.dB_LTTQDataSet.DataSetName = "DB_LTTQDataSet";
            this.dB_LTTQDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelTimKiem
            // 
            this.panelTimKiem.BackColor = System.Drawing.Color.Gray;
            this.panelTimKiem.Controls.Add(this.txtNam);
            this.panelTimKiem.Controls.Add(this.txtThang);
            this.panelTimKiem.Controls.Add(this.label2);
            this.panelTimKiem.Controls.Add(this.btnTimKiem);
            this.panelTimKiem.Controls.Add(this.txtND);
            this.panelTimKiem.Controls.Add(this.lblNhapND);
            this.panelTimKiem.Controls.Add(this.lblTimKiem);
            this.panelTimKiem.Location = new System.Drawing.Point(67, 25);
            this.panelTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.panelTimKiem.Name = "panelTimKiem";
            this.panelTimKiem.Size = new System.Drawing.Size(448, 201);
            this.panelTimKiem.TabIndex = 6;
            // 
            // txtNam
            // 
            this.txtNam.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam.ForeColor = System.Drawing.Color.Black;
            this.txtNam.Location = new System.Drawing.Point(312, 90);
            this.txtNam.Margin = new System.Windows.Forms.Padding(2);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(102, 33);
            this.txtNam.TabIndex = 7;
            // 
            // txtThang
            // 
            this.txtThang.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThang.ForeColor = System.Drawing.Color.Black;
            this.txtThang.Location = new System.Drawing.Point(98, 90);
            this.txtThang.Margin = new System.Windows.Forms.Padding(2);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(102, 33);
            this.txtThang.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(240, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Năm";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(30)))), ((int)(((byte)(53)))));
            this.btnTimKiem.Location = new System.Drawing.Point(167, 151);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(127, 36);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtND
            // 
            this.txtND.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtND.ForeColor = System.Drawing.Color.Black;
            this.txtND.Location = new System.Drawing.Point(180, 21);
            this.txtND.Margin = new System.Windows.Forms.Padding(2);
            this.txtND.Name = "txtND";
            this.txtND.Size = new System.Drawing.Size(245, 33);
            this.txtND.TabIndex = 3;
            // 
            // lblNhapND
            // 
            this.lblNhapND.AutoSize = true;
            this.lblNhapND.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhapND.ForeColor = System.Drawing.Color.Black;
            this.lblNhapND.Location = new System.Drawing.Point(24, 24);
            this.lblNhapND.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNhapND.Name = "lblNhapND";
            this.lblNhapND.Size = new System.Drawing.Size(152, 25);
            this.lblNhapND.TabIndex = 2;
            this.lblNhapND.Text = "Nhập nội dung ";
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiem.ForeColor = System.Drawing.Color.Black;
            this.lblTimKiem.Location = new System.Drawing.Point(24, 93);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(68, 25);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tháng";
            this.lblTimKiem.Click += new System.EventHandler(this.lblTimKiem_Click);
            // 
            // panelSLHoaDon
            // 
            this.panelSLHoaDon.BackColor = System.Drawing.Color.Gray;
            this.panelSLHoaDon.Controls.Add(this.txtSLHDN);
            this.panelSLHoaDon.Controls.Add(this.label1);
            this.panelSLHoaDon.Location = new System.Drawing.Point(702, 25);
            this.panelSLHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.panelSLHoaDon.Name = "panelSLHoaDon";
            this.panelSLHoaDon.Size = new System.Drawing.Size(348, 132);
            this.panelSLHoaDon.TabIndex = 10;
            // 
            // txtSLHDN
            // 
            this.txtSLHDN.BackColor = System.Drawing.Color.Gray;
            this.txtSLHDN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSLHDN.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLHDN.ForeColor = System.Drawing.Color.Black;
            this.txtSLHDN.Location = new System.Drawing.Point(85, 54);
            this.txtSLHDN.Margin = new System.Windows.Forms.Padding(2);
            this.txtSLHDN.Name = "txtSLHDN";
            this.txtSLHDN.Size = new System.Drawing.Size(164, 64);
            this.txtSLHDN.TabIndex = 8;
            this.txtSLHDN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số lượng hóa đơn";
            // 
            // btnXuatFileExcel
            // 
            this.btnXuatFileExcel.BackColor = System.Drawing.Color.Black;
            this.btnXuatFileExcel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatFileExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatFileExcel.Location = new System.Drawing.Point(887, 176);
            this.btnXuatFileExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnXuatFileExcel.Name = "btnXuatFileExcel";
            this.btnXuatFileExcel.Size = new System.Drawing.Size(150, 60);
            this.btnXuatFileExcel.TabIndex = 9;
            this.btnXuatFileExcel.Text = "Xuất DS Excel";
            this.btnXuatFileExcel.UseVisualStyleBackColor = false;
            this.btnXuatFileExcel.Click += new System.EventHandler(this.btnXuatFileExcel_Click);
            // 
            // btnThemHoaDon
            // 
            this.btnThemHoaDon.BackColor = System.Drawing.Color.Black;
            this.btnThemHoaDon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnThemHoaDon.Location = new System.Drawing.Point(713, 176);
            this.btnThemHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemHoaDon.Name = "btnThemHoaDon";
            this.btnThemHoaDon.Size = new System.Drawing.Size(149, 60);
            this.btnThemHoaDon.TabIndex = 8;
            this.btnThemHoaDon.Text = "Thêm hóa đơn";
            this.btnThemHoaDon.UseVisualStyleBackColor = false;
            this.btnThemHoaDon.Click += new System.EventHandler(this.btnThemHoaDon_Click);
            // 
            // hoaDonNhapTableAdapter
            // 
            this.hoaDonNhapTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.HeaderText = "Chi Tiết";
            this.dataGridViewImageColumn1.Image = global::GUI_QuanLy.Properties.Resources.View_Details;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn2.HeaderText = "Xóa";
            this.dataGridViewImageColumn2.Image = global::GUI_QuanLy.Properties.Resources.Delete1;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            // 
            // GUI_HoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1175, 830);
            this.Controls.Add(this.dgvDSHDN);
            this.Controls.Add(this.panelTimKiem);
            this.Controls.Add(this.panelSLHoaDon);
            this.Controls.Add(this.btnXuatFileExcel);
            this.Controls.Add(this.btnThemHoaDon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GUI_HoaDonNhap";
            this.Text = "GUI_HoaDonNhap";
            this.Load += new System.EventHandler(this.GUI_HoaDonNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoaDonNhapBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_LTTQDataSet)).EndInit();
            this.panelTimKiem.ResumeLayout(false);
            this.panelTimKiem.PerformLayout();
            this.panelSLHoaDon.ResumeLayout(false);
            this.panelSLHoaDon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSHDN;
        private System.Windows.Forms.Panel panelTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtND;
        private System.Windows.Forms.Label lblNhapND;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Panel panelSLHoaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXuatFileExcel;
        private System.Windows.Forms.Button btnThemHoaDon;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSLHDN;
        private DB_LTTQDataSet dB_LTTQDataSet;
        private System.Windows.Forms.BindingSource hoaDonNhapBindingSource;
        private DB_LTTQDataSetTableAdapters.HoaDonNhapTableAdapter hoaDonNhapTableAdapter;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewImageColumn ChiTiet;
        private System.Windows.Forms.DataGridViewImageColumn Xoa;
    }
}