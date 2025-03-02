using DAL_QuanLy;
using Guna.UI2.WinForms.Suite;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class Report_HoaDon : Form
    {
        private DAL_ReportHoaDon dalReportHoaDon = new DAL_ReportHoaDon();
        public Report_HoaDon()
        {
            InitializeComponent();
        }

        private void Report_HoaDon_Load(object sender, EventArgs e)
        {
            string reportPath = Path.Combine(Application.StartupPath, "Reports", "ReportHoaDon.rdlc");
            reportViewer1.LocalReport.ReportPath = reportPath;

            // Đặt ngày mặc định khi load form (từ 1/10/2024 đến hôm nay)
            dateTimePickerStart.Value = new DateTime(2024, 10, 1);
            dateTimePickerEnd.Value = DateTime.Now;

            // Tải báo cáo với ngày mặc định
            LoadReportData(dateTimePickerStart.Value, dateTimePickerEnd.Value);

        }
        private void LoadReportData(DateTime startDate, DateTime endDate)
        {
            // Lấy dữ liệu hóa đơn gộp (bao gồm cả hóa đơn bán và nhập) cho khoảng thời gian đã chọn
            var hoaDonList = dalReportHoaDon.GetHoaDonGopData(startDate, endDate);
            var dataTable = dalReportHoaDon.ConvertHoaDonListToDataTable(hoaDonList);

            // Thiết lập nguồn dữ liệu cho ReportViewer
            ReportDataSource rds = new ReportDataSource("DataSet_HoaDon", dataTable);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            var reportParameters = new List<ReportParameter>
            {
                new ReportParameter("LoggedInUser", Global.TenNV)
            };

            reportViewer1.LocalReport.SetParameters(reportParameters);

            // Làm mới báo cáo
            reportViewer1.RefreshReport();
        }


        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            // Lấy ngày bắt đầu và ngày kết thúc từ DateTimePicker
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            // Tải báo cáo dựa trên khoảng thời gian đã chọn
            LoadReportData(startDate, endDate);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
