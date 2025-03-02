using BUS_QuanLy;
using OfficeOpenXml;
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
    public partial class GUI_HoaDonBan : Form
    {
        BUS_HoaDonBan busHDB = new BUS_HoaDonBan();
        DataTable dtHDB;
        public GUI_HoaDonBan()
        {
            InitializeComponent();
            LoadDanhSachHoaDon();
        }

        private void GUI_HoaDonBan_Load(object sender, EventArgs e)
        {
            LoadDanhSachHoaDon();
        }

        // Hàm tải danh sách hóa đơn và hiển thị lên DataGridView
        public void LoadDanhSachHoaDon()
        {
            // Lấy danh sách hóa đơn từ BUS
            dtHDB = busHDB.LayDanhSachHoaDonBan();

            // Gán dữ liệu vào DataGridView
            dgvDSHDB.DataSource = dtHDB;

            // Đánh số thứ tự cho hàng trong DataGridView
            for (int i = 0; i < dgvDSHDB.Rows.Count; i++)
            {
                dgvDSHDB.Rows[i].Cells["STT"].Value = i + 1;
            }

            // Cập nhật số lượng hóa đơn
            txtSLHDB.Text = dtHDB.Rows.Count.ToString();

            // Làm mới DataGridView
            dgvDSHDB.Refresh();
        }

        // Xử lý các sự kiện click trên các cột (Chi tiết, Sửa, Xóa)
        private void dgvDSHDB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Chi tiết
            if (e.ColumnIndex == dgvDSHDB.Columns["ChiTiet"].Index)
            {
                string soHDB = (string)dgvDSHDB.Rows[e.RowIndex].Cells["soHDBDataGridViewTextBoxColumn"].Value;
                GUI_ChiTietHDB chiTietForm = new GUI_ChiTietHDB(soHDB);
                chiTietForm.ShowDialog();
            }
            // Xóa
            else if (e.ColumnIndex == dgvDSHDB.Columns["Xoa"].Index)
            {
                string soHDB = (string)dgvDSHDB.Rows[e.RowIndex].Cells["soHDBDataGridViewTextBoxColumn"].Value;

                // Hỏi người dùng xác nhận xóa
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn số {soHDB}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Gọi phương thức xóa hóa đơn
                    bool xoaThanhCong = busHDB.XoaHoaDon(soHDB);

                    if (xoaThanhCong)
                    {
                        MessageBox.Show($"Hóa đơn số {soHDB} đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Xóa dòng tương ứng trong DataGridView
                        dgvDSHDB.Rows.RemoveAt(e.RowIndex);

                        LoadDanhSachHoaDon();// Cập nhật lại danh sách sau khi xóa

                    }
                    else
                    {
                        MessageBox.Show($"Không thể xóa hóa đơn số {soHDB}. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Tìm kiếm hóa đơn theo các tiêu chí (mã, tháng, năm)
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
            DataTable dsHD = busHDB.TimKiemHoaDon(keyword, month, year);

            // Kiểm tra kết quả tìm kiếm, nếu không có dữ liệu trả về thì hiển thị thông báo
            if (dsHD == null || dsHD.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn nào khớp với điều kiện tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Cập nhật số lượng hóa đơn
                txtSLHDB.Text = "0";
                dgvDSHDB.DataSource = null;
                return;
            }

            // Nếu có dữ liệu, hiển thị lên DataGridView
            dgvDSHDB.DataSource = dsHD;
            // Cập nhật số lượng hóa đơn
            txtSLHDB.Text = dsHD.Rows.Count.ToString();

            // Đánh số thứ tự cho các hàng trong DataGridView
            for (int i = 0; i < dgvDSHDB.Rows.Count; i++)
            {
                dgvDSHDB.Rows[i].Cells["STT"].Value = i + 1;
            }
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            GUI_TaoHoaDonBan taoHoaDon = new GUI_TaoHoaDonBan();
            taoHoaDon.Owner = this; // Thiết lập Owner
            taoHoaDon.ShowDialog();
        }

        private void btnXuatFileExcel_Click(object sender, EventArgs e)
        {
            DataTable dtHDBFiltered = (DataTable)dgvDSHDB.DataSource; // Get the current DataTable from DataGridView
            busHDB.InDanhSachHoaDon(dtHDBFiltered);
        }
    }
}