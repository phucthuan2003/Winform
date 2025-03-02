using DAL_QuanLy;
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
    public partial class Report_NhanVien : Form
    {
        private DAL_ReportNhanVien DAL_ReportNhanVien = new DAL_ReportNhanVien();
        public Report_NhanVien()
        {

            InitializeComponent();
        }

        private void Report_NhanVien_Load(object sender, EventArgs e)
        {
            string reportPath = Path.Combine(Application.StartupPath, "Reports", "ReportNhanVien.rdlc");
            reportViewer1.LocalReport.ReportPath = reportPath;

            // Tải dữ liệu nhân viên và hiển thị
            LoadReportData();
            //this.reportViewer1.RefreshReport();
        }
        private void LoadReportData()
        {
            var nhanVienList = DAL_ReportNhanVien.GetNhanVienData();
            var dataTable = DAL_ReportNhanVien.ConvertNhanVienListToDataTable(nhanVienList);

            ReportDataSource rds = new ReportDataSource("DataSet_NhanVien", dataTable);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            var reportParameters = new List<ReportParameter>
            {
                new ReportParameter("LoggedInUser", Global.TenNV)
            };

            reportViewer1.LocalReport.SetParameters(reportParameters);

            reportViewer1.RefreshReport();
        }
    }
}
