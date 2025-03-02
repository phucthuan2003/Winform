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
using System.Windows.Media;

namespace GUI_QuanLy
{
    public partial class GUI_ChiTietHDN : Form
    {
        private string soHDN;
        BUS_NhanVien busNV = new BUS_NhanVien();
        BUS_HoaDonNhap busHDN = new BUS_HoaDonNhap();
        BUS_ChiTietHoaDonNhap busCT = new BUS_ChiTietHoaDonNhap();
        BUS_NhaCungCap busNCC = new BUS_NhaCungCap();
        public GUI_ChiTietHDN(string soHDN)
        {
            InitializeComponent();
            this.soHDN = soHDN;
            LoadChiTietHoaDon();
        }

        private void LoadChiTietHoaDon()
        {
            //Lấy thông tin hóa đơn
            var hoaDon = busHDN.LayThongTinHoaDon(soHDN);
            txtMaHD.Text = hoaDon.SoHDN;
            dtpNgayNhap.Value = hoaDon.NgayNhap;
            dtpNgayNhap.Enabled = false;
            txtMaNV.Text = hoaDon.MaNV;
            txtTenNV.Text = busNV.LayTenNhanVien(hoaDon.MaNV);

            //Lấy thông tin nhaCC
            var nhaCC = busNCC.LayThongTinNhaCungCap(hoaDon.MaNCC);
            txtMaNCC.Text = nhaCC.MaNCC;
            txtTenNCC.Text = nhaCC.TenNCC;
            txtDiaChi.Text = nhaCC.DiaChi;
            txtSDT.Text = nhaCC.DienThoai;

            // Tải thông tin chi tiết hóa đơn từ database
            var chiTietHoaDonNhap = busCT.LayChiTietHoaDon(soHDN);

            if (chiTietHoaDonNhap != null)
            {
                dgvDSMatHang.DataSource = chiTietHoaDonNhap;
            }
            else
            {
                MessageBox.Show("Không tìm thấy chi tiết hóa đơn này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Ẩn cột SoHDB nếu cần thiết
            dgvDSMatHang.Columns["SoHDN"].Visible = false;
            dgvDSMatHang.Columns["MaNV"].Visible = false;
            dgvDSMatHang.Columns["NgayNhap"].Visible = false;

            dgvDSMatHang.Columns["MaHang"].HeaderText = "Mã Hàng";
            dgvDSMatHang.Columns["TenHang"].HeaderText = "Tên Hàng";
            dgvDSMatHang.Columns["TenHang"].DisplayIndex = 2;
            dgvDSMatHang.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvDSMatHang.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvDSMatHang.Columns["ThanhTien"].HeaderText = "Thành Tiền";


            //Tính tổng tiền
            decimal tongTien = chiTietHoaDonNhap.Sum(item => item.ThanhTien);
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
            string soHDN = txtMaHD.Text;
            //busCT.InChiTietHoaDon(soHDB); // In chi tiết hóa đơn
            GUI_InHoaDonNhap frmReport = new GUI_InHoaDonNhap()
            {
                SoHDN = soHDN
            };
            frmReport.ShowDialog();
        }
    }
}
