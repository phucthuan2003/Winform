using DAL_QuanLy;
using DTO_QuanLy;
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
    public partial class HomePage : Form
    {
        private DAL_TaiKhoan dalTaiKhoan;
        private DAL_KhachHang dalKhachHang;
        private DAL_ChiTietHoaDonBan dalChiTietHoaDonBan;
        private DAL_ChiTietHoaDonNhap dalChiTietHoaDonNhap;
        private DAL_HangHoa dalHangHoa;
        private DAL_HoaDonBan dalHoaDonBan;

        public HomePage()
        {
            InitializeComponent();
            dalTaiKhoan = new DAL_TaiKhoan();
            dalKhachHang = new DAL_KhachHang();
            dalChiTietHoaDonBan = new DAL_ChiTietHoaDonBan();
            dalChiTietHoaDonNhap = new DAL_ChiTietHoaDonNhap();
            dalHangHoa = new DAL_HangHoa();
            dalHoaDonBan = new DAL_HoaDonBan();
            
        }

        private void headerControl1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadEmployeeData()
        {
            DataTable totalResult = dalTaiKhoan.GetEmployeeCount();
            if (totalResult.Rows.Count > 0)
            {
                lblTongSo.Text = $"Tổng số: {totalResult.Rows[0]["Bang1"]}";
            }

            DataTable positionResult = dalTaiKhoan.GetEmployeeByRole();
            int managers = 0;
            int staff = 0;
            foreach (DataRow row in positionResult.Rows)
            {
                string position = row["QuyenHan"].ToString();
                int count = Convert.ToInt32(row["Count"]);

                if (position == "Admin")
                {
                    managers = count;
                }
                else if (position == "NhanVien")
                {
                    staff = count;
                }
            }
            lblQuanLy.Text = $"Quản lý: {managers}";
            lblNhanVien.Text = $"Nhân viên: {staff}";
        }
        private void LoadCustomer()
        {
            DataTable totalResult = dalKhachHang.GetCustomerCount();
            if (totalResult.Rows.Count > 0)
            {
                lblTongSo2.Text = $"Tổng số: {totalResult.Rows[0]["Bang2"]}";
            }
        }
        private void LoadProduct()
        {
            // Giả sử bạn đã khởi tạo dalChiTietHoaDonBan
            DataTable totalResult = dalChiTietHoaDonBan.GetTotalSoldQuantity();
            if (totalResult.Rows.Count > 0)
            {
                lblTongSo3.Text = $"Tổng số: {totalResult.Rows[0]["Bang3"]}";
            }

            DataTable totalResult1 = dalChiTietHoaDonBan.GetTotalCustomerCount();
            if (totalResult1.Rows.Count > 0)
            {
                lblKH.Text = $"Số lượng KH: {totalResult1.Rows[0]["Bang4"]}";
            }
        }
        private void LoadStored()
        {
            DataTable totalResult = dalHangHoa.GetTotalProductsCount();
            if (totalResult.Rows.Count > 0)
            {
                lblSP.Text = $"SL sản phẩm: {totalResult.Rows[0]["Bang3"]}";
            }

            DataTable totalResult1 = dalHangHoa.GetTotalStockQuantity();
            if (totalResult1.Rows.Count > 0)
            {
                lblTK.Text = $"SL tồn kho: {totalResult1.Rows[0]["Bang3"]}";
            }

            DataTable totalResult2 = dalChiTietHoaDonNhap.GetTotalImportedQuantity();
            if (totalResult2.Rows.Count > 0)
            {
                lblN.Text = $"SL nhập: {totalResult2.Rows[0]["Bang4"]}";
            }
        }
        private void LoadRevenue()
        {
            DataTable totalResult = dalHoaDonBan.GetTotalRevenue();
            if (totalResult.Rows.Count > 0)
            {
                lblDT.Text = $"Doanh thu: {totalResult.Rows[0]["Bang3"]}";
            }

            DataTable totalResult1 = dalHoaDonBan.GetTotalDiscount();
            if (totalResult1.Rows.Count > 0)
            {
                lblGG.Text = $"Giảm giá: {totalResult1.Rows[0]["Bang3"]}";
            }
        }


        private void HomePage_Load(object sender, EventArgs e)
        {
            LoadRevenue();
            LoadStored();
            LoadProduct();
            LoadCustomer();
            LoadEmployeeData();
        }

        private void btnXemThemNS_Click(object sender, EventArgs e)
        {

        }
    }
}
