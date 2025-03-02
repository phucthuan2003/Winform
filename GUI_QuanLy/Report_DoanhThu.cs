using BUS_QuanLy;
using DTO_QuanLy;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class Report_DoanhThu : Form
    {
        private string connectionString = "Data Source=DESKTOP-R4RPQKD;Initial Catalog=BTL_6;Integrated Security=True;Encrypt=True";

        public Report_DoanhThu()
        {
            InitializeComponent();
        }

        private void Report_DoanhThu_Load(object sender, EventArgs e)
        {

            this.reportViewer_DoanhThu.RefreshReport();

        }
        private void LoadRevenueReport()
        {
            DataTable reportData = GetReportData();

            // Kiểm tra nếu có dữ liệu để hiển thị
            if (reportData.Rows.Count > 0)
            {
                reportViewer_DoanhThu.LocalReport.DataSources.Clear();
                reportViewer_DoanhThu.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", reportData));
                reportViewer_DoanhThu.RefreshReport();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị trong báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private DataTable GetReportData()
        {
            DataTable dataTable = new DataTable();

            // Truy vấn SQL để lấy dữ liệu
            string query = @"
                SELECT hb.SoHDB AS InvoiceNumber,
                       SUM(ct.SoLuong * ct.DonGiaBan * (1 - ISNULL(ct.GiamGia, 0))) AS Revenue,
                       hb.NgayBan AS SaleDate,
                       SUM(ct.SoLuong) AS ProductCount,
                       hh.MaHang AS ProductCode,
                       hh.TenHang AS ProductName
                FROM HoaDonBan hb
                JOIN ChiTietHoaDonBan ct ON hb.SoHDB = ct.SoHDB
                JOIN HangHoa hh ON ct.MaHang = hh.MaHang
                GROUP BY hb.SoHDB, hb.NgayBan, hh.MaHang, hh.TenHang";

            // Kết nối và lấy dữ liệu từ CSDL
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable); // Đổ dữ liệu vào DataTable
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kết nối đến cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return dataTable;
        }
    }
}
