using DAL_QuanLy;
using DTO_QuanLy;
using Guna.UI2.WinForms.Suite;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class ReportSanPham : Form
    {
        private DAL_ReportSanPham _reportSanPhamDAL = new DAL_ReportSanPham();
        private DateTime? _startDate;
        private DateTime? _endDate;
        public ReportSanPham(DateTime? startDate, DateTime? endDate)
        {
            InitializeComponent();
            _startDate = startDate;
            _endDate = endDate;
        }

        private void ReportSanPham_Load(object sender, EventArgs e)
        {
            string reportPath = System.IO.Path.Combine(Application.StartupPath, "Reports", "Report_SanPham.rdlc");
            reportViewer1.LocalReport.ReportPath = reportPath;
            // this.reportViewer1.RefreshReport();
            //LoadReportData("");
            LoadReportData("", _startDate, _endDate);
        }
        private void LoadReportData(string productID = "" , DateTime? startDate = null, DateTime? endDate = null)
        {
            List<DTO_ReportSanPham> reportList;

            if (!string.IsNullOrEmpty(productID))
            {
                // Lọc theo mã sản phẩm và ngày
                reportList = _reportSanPhamDAL.GetReportSanPhamDataByDate(productID, startDate, endDate);
            }
            else
            {
                // Lọc theo toàn bộ sản phẩm và ngày
                reportList = _reportSanPhamDAL.GetAllReportSanPhamDataByDate(startDate, endDate);
            }
            // Kiểm tra danh sách sản phẩm
            if (reportList == null || reportList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu sản phẩm trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            // Chuyển danh sách sản phẩm thành DataTable
            DataTable reportData = _reportSanPhamDAL.ConvertSanPhamListToDataTable(reportList);

            // Đặt dữ liệu cho ReportViewer
            ReportDataSource rds = new ReportDataSource("DataSet_SanPham", reportData);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            var reportParameters = new List<ReportParameter>
            {
                new ReportParameter("LoggedInUser", Global.TenNV)
            };

            reportViewer1.LocalReport.SetParameters(reportParameters);

            // Làm mới ReportViewer
            reportViewer1.RefreshReport();
        }



        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string productID = txtMaSanPham.Text.Trim();

            if (!string.IsNullOrEmpty(productID))
            {
                LoadReportData(productID, _startDate, _endDate);
            }
            else
            {
                LoadReportData("", _startDate, _endDate);
            }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
