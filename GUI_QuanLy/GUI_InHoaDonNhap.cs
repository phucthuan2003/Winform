using BUS_QuanLy;
using DTO_QuanLy;
using Microsoft.Reporting.WinForms;
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
    public partial class GUI_InHoaDonNhap : Form
    {
        public string SoHDN { get; set; } // Mã hóa đơn cần in
        BUS_ChiTietHoaDonNhap busCT = new BUS_ChiTietHoaDonNhap();
        public GUI_InHoaDonNhap()
        {
            InitializeComponent();
        }

        private void GUI_InHoaDonNhap_Load(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra mã hóa đơn
                if (string.IsNullOrEmpty(SoHDN))
                {
                    MessageBox.Show("Không tìm thấy mã hóa đơn để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy dữ liệu chi tiết hóa đơn
                List<DTO_ChiTietHoaDonNhap> chiTietList = busCT.RP_LayChiTietHoaDon(SoHDN);

                if (chiTietList.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //
                reportViewer1.LocalReport.ReportEmbeddedResource = "GUI_QuanLy.InHDN.rdlc";

                ReportDataSource reportDataSource = new ReportDataSource()
                {
                    Name = "ChiTiet", // Tên DataSource trong RDLC
                    Value = chiTietList // Dữ liệu nguồn
                };

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
