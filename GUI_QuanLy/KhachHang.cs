using BUS_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class KhachHang : Form
    {
        BUS_KhachHang busKhachHang = new BUS_KhachHang();
        public KhachHang()
        {
            InitializeComponent();
            LoadKhachHang();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // Thêm sự kiện cho các TextBox
            txtMaKH.Enter += TextBox_Enter;
            txtMaKH.Leave += TextBox_Leave;

            txtTenKH.Enter += TextBox_Enter;
            txtTenKH.Leave += TextBox_Leave;

            txtDiaChi.Enter += TextBox_Enter;
            txtDiaChi.Leave += TextBox_Leave;

            txtDienThoai.Enter += TextBox_Enter;
            txtDienThoai.Leave += TextBox_Leave;

            // Xử lý sự kiện thêm và xóa hàng cho DataGridView để cập nhật số thứ tự
            dgvKhachHang.RowsAdded += dgvKhachHang_RowsAdded;
            dgvKhachHang.RowsRemoved += dgvKhachHang_RowsRemoved;
        }
        // Sự kiện khi TextBox nhận tiêu điểm
        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.BackColor = Color.White; // Đặt màu nền là trắng
            }
        }

        // Sự kiện khi TextBox mất tiêu điểm
        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.BackColor = SystemColors.Window; // Màu nền mặc định
            }
        }

        private void LoadKhachHang()
        {
            // Tạo cột số thứ tự nếu chưa có
            if (!dgvKhachHang.Columns.Contains("STT"))
            {
                DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                {
                    Name = "STT",
                    HeaderText = "STT",
                    ReadOnly = true
                };
                dgvKhachHang.Columns.Insert(0, sttColumn); // Thêm vào vị trí đầu tiên
                sttColumn.Width = 30;
            }

            UpdateSoThuTu();
            dgvKhachHang.RowHeadersVisible = false; // Ẩn tiêu đề hàng

            dgvKhachHang.DataSource = busKhachHang.getKhachHang();
            dgvKhachHang.Columns["MaKhach"].Width = 150;
            dgvKhachHang.Columns["TenKhach"].Width = 200;
            dgvKhachHang.Columns["DiaChi"].Width = 300;
            dgvKhachHang.Columns["DienThoai"].Width = 150;
            dgvKhachHang.RowTemplate.Height = 135;
        }

        // Phương thức cập nhật số thứ tự cho DataGridView
        private void UpdateSoThuTu()
        {
            for (int i = 0; i < dgvKhachHang.Rows.Count; i++)
            {
                dgvKhachHang.Rows[i].Cells["STT"].Value = (i + 1).ToString();
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
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // Đặt lại màu nền cho các TextBox về màu mặc định
            Color customColor = Color.FromArgb(120, 120, 120);
            txtMaKH.BackColor = customColor;
            txtTenKH.BackColor = customColor;
            txtDiaChi.BackColor = customColor;
            txtDienThoai.BackColor = customColor;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường đầu vào có rỗng hay không
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Khách Hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Khách Hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKH.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập Địa Chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập Số Điện Thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return;
            }

            // Kiểm tra số điện thoại có hợp lệ hay không
            if (!long.TryParse(txtDienThoai.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập Số Điện Thoại là số hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return;
            }

            // Kiểm tra mã khách hàng đã tồn tại
            if (busKhachHang.KiemTraKhachHangTonTai(txtMaKH.Text.Trim()))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại! Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }

            string maKhach = txtMaKH.Text.Trim();
            // Kiểm tra mã khách hàng phải bắt đầu bằng 'KH' và sau đó là số
            if (!maKhach.StartsWith("KH", StringComparison.OrdinalIgnoreCase) ||
                 maKhach.Length < 3 ||
                !char.IsUpper(maKhach[0]) ||
                !char.IsUpper(maKhach[1]) ||
                !int.TryParse(maKhach.Substring(2), out _)) // Kiểm tra phần sau 'KH' có phải là số không
            {
                MessageBox.Show("Mã Khách Hàng phải bắt đầu bằng 'KH' theo sau là số (ví dụ: KH01)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }

            // Tạo đối tượng DTO_KhachHang với dữ liệu hợp lệ
            DTO_KhachHang kh = new DTO_KhachHang(txtMaKH.Text.Trim(), txtTenKH.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim());

            // Gọi phương thức thêm khách hàng từ lớp BUS
            if (busKhachHang.themKhachHang(kh))
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadKhachHang();
                reset();
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường đầu vào có rỗng hay không
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Khách Hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Khách Hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKH.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập Địa Chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập Số Điện Thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return;
            }

            // Kiểm tra số điện thoại có hợp lệ hay không
            if (!long.TryParse(txtDienThoai.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập Số Điện Thoại là số hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return;
            }

            string maKhach = txtMaKH.Text.Trim();
            // Kiểm tra mã khách hàng phải bắt đầu bằng 'KH' và sau đó là số
            if (!maKhach.StartsWith("KH", StringComparison.OrdinalIgnoreCase) ||
                 maKhach.Length < 3 ||
                !char.IsUpper(maKhach[0]) ||
                !char.IsUpper(maKhach[1]) ||
                !int.TryParse(maKhach.Substring(2), out _)) // Kiểm tra phần sau 'KH' có phải là số không
            {
                MessageBox.Show("Mã Khách Hàng phải bắt đầu bằng 'KH' theo sau là số (ví dụ: KH01)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }

            // Kiểm tra mã khách hàng đã tồn tại
            if (!busKhachHang.KiemTraKhachHangTonTai(txtMaKH.Text.Trim()))
            {
                MessageBox.Show("Mã khách hàng không tồn tại! Không thể sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }

            // Tạo đối tượng DTO_KhachHang với dữ liệu hợp lệ
            DTO_KhachHang kh = new DTO_KhachHang(txtMaKH.Text.Trim(), txtTenKH.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim());

            // Gọi phương thức sửa khách hàng từ lớp BUS
            if (busKhachHang.suaKhachHang(kh))
            {
                MessageBox.Show("Sửa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadKhachHang(); // Cập nhật lại danh sách khách hàng
                reset(); // Gọi phương thức reset để làm sạch các trường
                this.Close();
            }
            else
            {
                MessageBox.Show("Sửa khách hàng thất bại! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã khách hàng có rỗng hay không
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Gọi phương thức xóa khách hàng từ lớp BUS
                if (busKhachHang.xoaKhachHang(txtMaKH.Text.Trim()))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadKhachHang(); // Cập nhật lại danh sách khách hàng
                    reset(); // Gọi phương thức reset để làm sạch các trường
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng thất bại! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu có dòng được chọn
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin khách hàng từ dòng đã chọn
                txtMaKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells["MaKhach"].Value.ToString();
                txtTenKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells["TenKhach"].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                txtDienThoai.Text = dgvKhachHang.Rows[e.RowIndex].Cells["DienThoai"].Value.ToString();

                btnSua.Enabled = true; // Bật nút sửa
                btnXoa.Enabled = true; // Bật nút xóa

                // Gọi sự kiện Enter cho các TextBox để thay đổi màu nền
                TextBox_Enter(txtMaKH, EventArgs.Empty);
                TextBox_Enter(txtTenKH, EventArgs.Empty);
                TextBox_Enter(txtDiaChi, EventArgs.Empty);
                TextBox_Enter(txtDienThoai, EventArgs.Empty);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
