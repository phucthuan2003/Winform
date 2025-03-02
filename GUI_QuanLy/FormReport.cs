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
    public partial class FormReport : Form
    {
        private DAL_Report_DoanhThu _reportDAL = new DAL_Report_DoanhThu();
        public FormReport()
        {
            InitializeComponent();
        }
        private void FormReport_Load(object sender, EventArgs e)
        {

            string reportPath = System.IO.Path.Combine(Application.StartupPath, "Reports", "Report_DoanhThu.rdlc");
            reportViewer1.LocalReport.ReportPath = reportPath;


            //    List<DTO_ReportDoanhThu> reportList = _reportDAL.GetReportData();
            //    DataTable reportData = _reportDAL.ConvertToDataTable(reportList);

            //    // Tạo một nguồn dữ liệu cho báo cáo và thêm nó vào ReportViewer
            //    ReportDataSource rds = new ReportDataSource("DataSet_DoanhThu", reportData); 
            //    reportViewer1.LocalReport.DataSources.Clear();
            //    reportViewer1.LocalReport.DataSources.Add(rds);


            //    reportViewer1.RefreshReport();
            // Đảm bảo rằng đường dẫn tệp báo cáo là chính xác


            // Khởi tạo ReportViewer với dữ liệu
            DateTime startDate = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime endDate = DateTime.Now;
            LoadReportData(startDate, endDate);
        }
        private void LoadReportData(DateTime startDate, DateTime endDate)
        {

            List<DTO_ReportDoanhThu> reportList = _reportDAL.GetReportData(startDate, endDate);
            DataTable reportData = _reportDAL.ConvertToDataTable(reportList);


            ReportDataSource rds = new ReportDataSource("DataSet_DoanhThu", reportData);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            var reportParameters = new List<ReportParameter>
            {
                new ReportParameter("LoggedInUser", Global.TenNV)
            };

            reportViewer1.LocalReport.SetParameters(reportParameters);

            reportViewer1.RefreshReport();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            LoadReportData(startDate, endDate);
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void btnQuayVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
