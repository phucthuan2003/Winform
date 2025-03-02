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
    public partial class GUI_HoaDonNhap : Form
    {
        BUS_HoaDonNhap busHDN = new BUS_HoaDonNhap();
        DataTable dtHDN;
        public GUI_HoaDonNhap()
        {
            InitializeComponent();
            LoadDanhSachHoaDon();
        }
        private void GUI_HoaDonNhap_Load(object sender, EventArgs e)
        {
            LoadDanhSachHoaDon();
        }

        public void LoadDanhSachHoaDon()
        {
            // Lấy danh sách hóa đơn từ BUS
            dtHDN = busHDN.LayDanhSachHoaDonNhap();

            // Gán dữ liệu vào DataGridView
            dgvDSHDN.DataSource = dtHDN;

            // Đánh số thứ tự cho hàng trong DataGridView
            for (int i = 0; i < dgvDSHDN.Rows.Count; i++)
            {
                dgvDSHDN.Rows[i].Cells["STT"].Value = i + 1;
            }

            // Cập nhật số lượng hóa đơn
            txtSLHDN.Text = dtHDN.Rows.Count.ToString();

            // Làm mới DataGridView
            dgvDSHDN.Refresh();
        }
        private void dgvDSHDN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Chi tiết
            if (e.ColumnIndex == dgvDSHDN.Columns["ChiTiet"].Index)
            {
                string soHDN = (string)dgvDSHDN.Rows[e.RowIndex].Cells["SoHDN"].Value;
                GUI_ChiTietHDN chiTietForm = new GUI_ChiTietHDN(soHDN);
                chiTietForm.ShowDialog();
            }
            // Xóa
            else if (e.ColumnIndex == dgvDSHDN.Columns["Xoa"].Index)
            {
                string soHDN = (string)dgvDSHDN.Rows[e.RowIndex].Cells["SoHDN"].Value;

                // Hỏi người dùng xác nhận xóa
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn số {soHDN}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Gọi phương thức xóa hóa đơn
                    bool xoaThanhCong = busHDN.XoaHoaDon(soHDN);

                    if (xoaThanhCong)
                    {
                        MessageBox.Show($"Hóa đơn số {soHDN} đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Xóa dòng tương ứng trong DataGridView
                        dgvDSHDN.Rows.RemoveAt(e.RowIndex);

                        LoadDanhSachHoaDon();// Cập nhật lại danh sách sau khi xóa

                    }
                    else
                    {
                        MessageBox.Show($"Không thể xóa hóa đơn số {soHDN}. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtND.Text.Trim();
            string month = txtThang.Text.Trim();
            string year = txtNam.Text.Trim();

            if (!string.IsNullOrEmpty(month) && string.IsNullOrEmpty(year))
            {
                MessageBox.Show("Vui lòng nhập cả tháng và năm để tìm kiếm theo thời gian.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra nếu không nhập gì mà bấm tìm kiếm
            if (string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(month) && string.IsNullOrEmpty(year))
            {
                MessageBox.Show("Vui lòng nhập nội dung hoặc thời gian để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Gọi hàm tìm kiếm từ BUS_HoaDonBan
            DataTable dsHD = busHDN.TimKiemHoaDon(keyword, month, year);

            // Kiểm tra kết quả tìm kiếm, nếu không có dữ liệu trả về thì hiển thị thông báo
            if (dsHD == null || dsHD.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn nào khớp với điều kiện tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Cập nhật số lượng hóa đơn
                txtSLHDN.Text = "0";
                dgvDSHDN.DataSource = null;
                return;
            }

            // Nếu có dữ liệu, hiển thị lên DataGridView
            dgvDSHDN.DataSource = dsHD;
            // Cập nhật số lượng hóa đơn
            txtSLHDN.Text = dsHD.Rows.Count.ToString();

            // Đánh số thứ tự cho các hàng trong DataGridView
            for (int i = 0; i < dgvDSHDN.Rows.Count; i++)
            {
                dgvDSHDN.Rows[i].Cells["STT"].Value = i + 1;
            }
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            GUI_TaoHoaDonNhap taoHoaDon = new GUI_TaoHoaDonNhap();
            taoHoaDon.Owner = this; // Thiết lập Owner
            taoHoaDon.ShowDialog();
        }

        private void btnXuatFileExcel_Click(object sender, EventArgs e)
        {
            DataTable dtHDBFiltered = (DataTable)dgvDSHDN.DataSource; // Get the current DataTable from DataGridView
            busHDN.InDanhSachHoaDon(dtHDBFiltered);
        }

        private void lblTimKiem_Click(object sender, EventArgs e)
        {

        }
    }
}
