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
    public partial class TKNhanVien : Form
    {
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        public TKNhanVien()
        {
            InitializeComponent();
            LoadNhanVien();


            // Thêm sự kiện cho các TextBox
            textBox1.Enter += TextBox_Enter;


            // Xử lý sự kiện thêm và xóa hàng cho DataGridView để cập nhật số thứ tự
            dgvTK.RowsAdded += dgvKhachHang_RowsAdded;
            dgvTK.RowsRemoved += dgvKhachHang_RowsRemoved;
        }

        // Sự kiện khi TextBox nhận tiêu điểm
        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.BackColor = Color.White; // Đặt màu nền là trắng

            }
        }


        private void LoadNhanVien()
        {
            comboBox1.Text = "Mã Nhân Viên";

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
                sttColumn.Width = 25;
            }

            UpdateSoThuTu();
            dgvTK.RowHeadersVisible = false; // Ẩn tiêu đề hàng

            dgvTK.DataSource = busNhanVien.getNhanVien();
            dgvTK.Columns["MaNV"].Width = 100;
            dgvTK.Columns["TenNV"].Width = 130;
            dgvTK.Columns["MaCV"].Width = 60;
            dgvTK.Columns["GioiTinh"].Width = 100;
            dgvTK.Columns["GioiTinh"].Visible = false;
            dgvTK.Columns["NgaySinh"].Width = 100;
            dgvTK.Columns["NgaySinh"].Visible = false ;
            dgvTK.Columns["DienThoai"].Width = 100;
            dgvTK.Columns["DiaChi"].Width = 150;
            dgvTK.Columns["SoNgayPhep"].Width = 80;
            dgvTK.Columns["SoNgayPhep"].Visible=false;
            dgvTK.Columns["SoNgayNghi"].Width = 80;
            dgvTK.Columns["SoNgayNghi"].Visible = false;
            dgvTK.Columns["NgayTuyen"].Width = 100;
            dgvTK.Columns["NgayTuyen"].Visible=false ;
            dgvTK.Columns["CCCD"].Width = 120;
            dgvTK.RowTemplate.Height = 135;

            if (dgvTK.Columns["HinhAnh"] is DataGridViewImageColumn imgCol)
            {
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }

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
        private void dgvKhachHang_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateSoThuTu();
        }

        // Xử lý khi xóa dòng khỏi DataGridView
        private void dgvKhachHang_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateSoThuTu();
        }

        public void reset()
        {
            textBox1.Clear();


            // Đặt lại màu nền cho các TextBox về màu mặc định
            Color customColor = Color.FromArgb(120, 120, 120);
            textBox1.BackColor = customColor;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView hay không
            if (dgvTK.SelectedRows.Count == 0)
            {
                MessageBox.Show("Không có dòng nào được chọn ", "Kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy hàng đã chọn
            DataGridViewRow selectedRow = dgvTK.SelectedRows[0];
            if (selectedRow != null)
            {
                // Kiểm tra xem giá trị trong ô "MaNV" có phải là null không
                if (selectedRow.Cells["MaNV"].Value != null)
                {
                    string maNV = selectedRow.Cells["MaNV"].Value.ToString();
                    Console.WriteLine("Xóa MaNV: " + maNV);

                    // Xác nhận xóa
                    DialogResult confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        if (busNhanVien.xoaNhanVien(maNV))
                        {
                            MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadNhanVien();
                        }
                        else
                        {
                            MessageBox.Show("Xóa nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if clicked on a valid row
            {
                // Set current row as selected
                dgvTK.Rows[e.RowIndex].Selected = true;
                string maNV = dgvTK.Rows[e.RowIndex].Cells["MaNV"].Value?.ToString();
                Console.WriteLine("Mã nhân viên được chọn: " + maNV);
            }
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
                case "Mã Nhân Viên":
                    searchField = "MaNV";
                    break;
                case "Tên Nhân Viên":
                    searchField = "TenNV";
                    break;
                case "Số Điện Thoại":
                    searchField = "DienThoai";
                    break;
                case "CCCD":
                    searchField = "CCCD";
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn trường tìm kiếm hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            // Gọi phương thức tìm kiếm từ lớp BUS
            DataTable result = busNhanVien.TimKiemNV(searchTerm, searchField);

            // Kiểm tra nếu không có kết quả
            if (result.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhanVien(); // Tải lại danh sách gốc nếu không có kết quả
                reset();
            }
            else
            {
                // Cập nhật DataGridView với kết quả tìm kiếm
                dgvTK.DataSource = result;
                UpdateSoThuTu(); // Cập nhật số thứ tự
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {

            // Kiểm tra xem có dòng nào được chọn trong DataGridView hay không
            if (dgvTK.SelectedRows.Count == 0)
            {
                MessageBox.Show("Không có dòng nào được chọn để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy hàng đã chọn
            DataGridViewRow selectedRow = dgvTK.SelectedRows[0];
            if (selectedRow != null)
            {
                // Kiểm tra xem giá trị trong ô "MaNV" có phải là null không
                if (selectedRow.Cells["MaNV"].Value != null)
                {
                    string maNV = selectedRow.Cells["MaNV"].Value.ToString();
                    Console.WriteLine("Sửa MaNV: " + maNV);

                    NhanVien_Sua suaForm = new NhanVien_Sua(maNV);

                    suaForm.FormClosed += (s, args) => {
                        LoadNhanVien(); // Gọi lại phương thức Load để làm mới dữ liệu
                    };

                    suaForm.ShowDialog();

                }
                else
                {
                    // Thông báo khi mã nhân viên không tồn tại
                    MessageBox.Show("Vui lòng chọn đúng hàng có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVien suaForm = new NhanVien();

            suaForm.FormClosed += (s, args) => {
                LoadNhanVien(); // Gọi lại phương thức Load để làm mới dữ liệu
            };

            suaForm.ShowDialog();
        }


    }
}
