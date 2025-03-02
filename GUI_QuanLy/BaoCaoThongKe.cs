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
    public partial class BaoCaoThongKe : Form
    {
        private BUS_SalesData salesDataBUS;
        public BaoCaoThongKe()
        {
            InitializeComponent();
            salesDataBUS = new BUS_SalesData();

            bunifuDatePicker1.ValueChanged += new EventHandler(DateRangeChanged);
            bunifuDatePicker2.ValueChanged += new EventHandler(DateRangeChanged);

            btnThongKe.Click += new EventHandler(btnThongKe_Click);
            ShowDefaultOverview();
        }
        private void ShowDefaultOverview()
        {
            // Gọi dữ liệu tổng quan cho toàn bộ khoảng thời gian
            var data = salesDataBUS.GetTotalSalesData();

            // Hiển thị dữ liệu tổng quan mặc định vào các TextBox
            txtDoanhThu.Text = data.DoanhThu.ToString("N0") + " VNĐ";
            txtSanPham.Text = data.SoSanPham.ToString();
            txtDonHang.Text = data.SoDonHang.ToString();
            txtNhanVien.Text = data.SoNhanVien.ToString();
        }
        private void DateRangeChanged(object sender, EventArgs e)
        {
            DateTime startDate = bunifuDatePicker1.Value.Date;
            DateTime endDate = bunifuDatePicker2.Value.Date;

            if (startDate <= endDate)
            {
                ShowOverView(startDate, endDate);
            }
            else
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
            }
        }
        private void ShowOverView(DateTime startDate, DateTime endDate)
        {
            // Lấy dữ liệu tổng quan cho khoảng thời gian đã chọn
            var data = salesDataBUS.GetSalesDataForPeriod(startDate, endDate);

            // Hiển thị dữ liệu tổng quan cho khoảng thời gian đã chọn
            txtDoanhThu.Text = data.DoanhThu.ToString("N0") + " VNĐ";
            txtSanPham.Text = data.SoSanPham.ToString();
            //txtDonHang.Text = data.SoDonHang.ToString();
            // txtNhanVien.Text = data.SoNhanVien.ToString();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Lấy ngày bắt đầu và ngày kết thúc từ DatePickers
            DateTime startDate = bunifuDatePicker1.Value.Date;
            DateTime endDate = bunifuDatePicker2.Value.Date;

            // Kiểm tra tính hợp lệ của khoảng thời gian
            if (startDate <= endDate)
            {
                // Gọi hàm để tải dữ liệu vào DataGridView
                LoadProductRankingData(startDate, endDate);
            }
            else
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
            }

        }
        private void LoadProductRankingData(DateTime startDate, DateTime endDate)
        {
            var products = salesDataBUS.GetProductSalesDataForPeriod(startDate, endDate);
            Dvg_Products.Rows.Clear();

            foreach (var product in products)
            {
                Dvg_Products.Rows.Add(product.Rank, product.ProductInfo, product.Revenue.ToString("C0") + " VNĐ", product.Quantity);
            }
        }

        private void txtDonHang_Click(object sender, EventArgs e)
        {

        }

        private void txtNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            FormReport formReport = new FormReport();
            formReport.ShowDialog();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            DateTime? startDate = bunifuDatePicker1.Value.Date;
            DateTime? endDate = bunifuDatePicker2.Value.Date;
            ReportSanPham reportSanPham = new ReportSanPham(startDate, endDate);
            reportSanPham.ShowDialog();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            Report_HoaDon report_HoaDon = new Report_HoaDon();
            report_HoaDon.ShowDialog();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            Report_NhanVien report_NhanVien = new Report_NhanVien();
            report_NhanVien.ShowDialog();
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
