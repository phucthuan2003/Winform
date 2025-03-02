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
    public partial class TKNhaCC : Form
    {
        BUS_NhaCungCap busNhaCungCap = new BUS_NhaCungCap();
        public TKNhaCC()
        {
            InitializeComponent();
            LoadNhaCungCap();

            // Thêm sự kiện cho các TextBox
            textBox1.Enter += TextBox_Enter;

            // Xử lý sự kiện thêm và xóa hàng cho DataGridView để cập nhật số thứ tự
            dgvTK.RowsAdded += dgvNhaCungCap_RowsAdded;
            dgvTK.RowsRemoved += dgvNhaCungCap_RowsRemoved;
        }

        // Sự kiện khi TextBox nhận tiêu điểm
        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.BackColor = Color.White; // Đặt màu nền là trắng
            }
        }

        private void LoadNhaCungCap()
        {
            comboBox1.Text = "Mã Nhà Cung Cấp";
            // Tạo cột số thứ tự nếu chưa có
            if (!dgvTK.Columns.Contains("STT"))
            {
                DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                {
                    Name = "STT",
                    HeaderText = "STT",
                    ReadOnly = true
                };
                dgvTK.Columns.Insert(0, sttColumn); // Thêm vào vị trí đầu tiên
                sttColumn.Width = 30;
            }

            UpdateSoThuTu();
            dgvTK.RowHeadersVisible = false; // Ẩn tiêu đề hàng

            dgvTK.DataSource = busNhaCungCap.getNhaCungCap();
            dgvTK.Columns["MaNCC"].Width = 150;
            dgvTK.Columns["TenNCC"].Width = 200;
            dgvTK.Columns["DiaChi"].Width = 300;
            dgvTK.Columns["DienThoai"].Width = 150;
            dgvTK.RowTemplate.Height = 135;
        }

        // Phương thức cập nhật số thứ tự cho DataGridView
        private void UpdateSoThuTu()
        {
            for (int i = 0; i < dgvTK.Rows.Count; i++)
            {
                dgvTK.Rows[i].Cells["STT"].Value = (i + 1).ToString();
            }
        }

        // Xử lý khi thêm dòng mới vào DataGridView
        private void dgvNhaCungCap_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateSoThuTu();
        }

        // Xử lý khi xóa dòng khỏi DataGridView
        private void dgvNhaCungCap_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateSoThuTu();
        }

        public void Reset()
        {
            textBox1.Clear();
            Color customColor = Color.FromArgb(120, 120, 120);
            textBox1.BackColor = customColor;
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.Trim(); // Lấy từ khóa tìm kiếm từ TextBox
            string searchField = "";

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác định trường tìm kiếm dựa trên comboBox1
            switch (comboBox1.Text)
            {
                case "Mã Nhà Cung Cấp":
                    searchField = "MaNCC";
                    break;
                case "Tên Nhà Cung Cấp":
                    searchField = "TenNCC";
                    break;
                case "Địa Chỉ":
                    searchField = "DiaChi";
                    break;
                case "Số Điện Thoại":
                    searchField = "DienThoai";
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn trường tìm kiếm hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            // Gọi phương thức tìm kiếm từ lớp BUS
            DataTable result = busNhaCungCap.TimKiemNCC(searchTerm, searchField);

            // Kiểm tra nếu không có kết quả
            if (result.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhaCungCap(); // Tải lại danh sách nhà cung cấp gốc nếu không có kết quả
                Reset();
            }
            else
            {
                // Cập nhật DataGridView với kết quả tìm kiếm
                dgvTK.DataSource = result;
                UpdateSoThuTu(); // Cập nhật số thứ tự
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhaCC suaForm = new NhaCC();

            suaForm.FormClosed += (s, args) => {
                LoadNhaCungCap(); // Gọi lại phương thức Load để làm mới dữ liệu
            };

            suaForm.ShowDialog();

        }

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}


		private void TKNhaCC_Load(object sender, EventArgs e)
		{

		}
	}
}

