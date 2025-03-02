using BUS_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class GUI_ChiTietHDB : Form
    {
        private string soHDB;
        //BindingSource bindingSource = new BindingSource();
        BUS_HoaDonBan busHDB = new BUS_HoaDonBan();
        BUS_NhanVien busNV = new BUS_NhanVien();
        BUS_KhachHang busKH = new BUS_KhachHang();
        BUS_ChiTietHoaDonBan busCT = new BUS_ChiTietHoaDonBan();

        public GUI_ChiTietHDB(string soHDB)
        {
            InitializeComponent();
            this.soHDB = soHDB;
            LoadChiTietHoaDon();
        }

        private void LoadChiTietHoaDon()
        {
            //Lấy thông tin hóa đơn
            var hoaDon = busHDB.LayThongTinHoaDon(soHDB);
            txtMaHD.Text = hoaDon.SoHDB;
            dtpNgayBan.Value = hoaDon.NgayBan;
            dtpNgayBan.Enabled = false;
            txtMaNV.Text = hoaDon.MaNV;
            txtTenNV.Text = busNV.LayTenNhanVien(hoaDon.MaNV);

            //Lấy thông tin khách hàng
            var khachHang = busKH.LayThongTinKhachHang(hoaDon.MaKhach);
            txtMaKH.Text = khachHang.MaKhach;
            txtTenKH.Text = khachHang.TenKhach;
            txtDiaChi.Text = khachHang.DiaChi;
            txtSDT.Text = khachHang.DienThoai;

            // Tải thông tin chi tiết hóa đơn từ database
            var chiTietHoaDonBan = busCT.LayChiTietHoaDon(soHDB);

            if (chiTietHoaDonBan != null)
            {
                dgvDSMatHang.DataSource = chiTietHoaDonBan;
            }
            else
            {
                MessageBox.Show("Không tìm thấy chi tiết hóa đơn này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Ẩn cột SoHDB nếu cần thiết
            dgvDSMatHang.Columns["SoHDB"].Visible = false; // Nếu cột này vẫn còn
            dgvDSMatHang.Columns["MaNV"].Visible = false;
            dgvDSMatHang.Columns["NgayBan"].Visible = false;

            dgvDSMatHang.Columns["MaHang"].HeaderText = "Mã Hàng";
            dgvDSMatHang.Columns["TenHang"].HeaderText = "Tên Hàng";
            dgvDSMatHang.Columns["TenHang"].DisplayIndex = 2;
            dgvDSMatHang.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvDSMatHang.Columns["GiamGia"].HeaderText = "Giảm Giá (%)";
            dgvDSMatHang.Columns["DonGiaBan"].HeaderText = "Đơn Giá";
            dgvDSMatHang.Columns["ThanhTien"].HeaderText = "Thành Tiền";


            //Tính tổng tiền
            decimal tongTien = chiTietHoaDonBan.Sum(item => item.ThanhTien);
            txtTongTien.Text = tongTien.ToString();
        }

        private void btnQuayVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string soHDB = txtMaHD.Text;
            //busCT.InChiTietHoaDon(soHDB); // In chi tiết hóa đơn
            GUI_InHoaDonBan frmReport = new GUI_InHoaDonBan()
            {
                SoHDB = soHDB
            };
            frmReport.ShowDialog();
        }
    }
}