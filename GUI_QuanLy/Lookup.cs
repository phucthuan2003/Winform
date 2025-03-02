using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class Lookup : Form
    {
        private DAL_HangHoa dalHangHoa; 

        public Lookup()
        {
            InitializeComponent();
            dalHangHoa = new DAL_HangHoa(); 
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string searchValue = txtThongTin.Text.Trim();

            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Vui lòng nhập nội dung cần tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable result = dalHangHoa.SearchHangHoaData(searchValue); // Gọi phương thức tìm kiếm từ DAL

                if (result.Rows.Count > 0)
                {
                    dtDanhSach.DataSource = result; // Gán dữ liệu vào DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
