using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLy;
using DTO_QuanLy;

namespace GUI_QuanLy
{
    public partial class TaiKhoan : Form
    {
        BUS_TaiKhoan busTaiKhoan = new BUS_TaiKhoan();
        public TaiKhoan()
        {
            InitializeComponent();
            LoadTaiKhoan();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            button1.Enabled = false;

            // Thêm sự kiện cho các TextBox
            txtMaTK.Enter += TextBox_Enter;
            txtMaTK.Leave += TextBox_Leave;

            txtMaNV.Enter += TextBox_Enter;
            txtMaNV.Leave += TextBox_Leave;

            txtTenDangNhap.Enter += TextBox_Enter;
            txtTenDangNhap.Leave += TextBox_Leave;

            txtMatKhau.Enter += TextBox_Enter;
            txtMatKhau.Leave += TextBox_Leave;

            txtQuyenHan.Enter += TextBox_Enter;
            txtQuyenHan.Leave += TextBox_Leave;

            // Xử lý sự kiện thêm và xóa hàng cho DataGridView để cập nhật số thứ tự
            dgvTaiKhoan.RowsAdded += dgvTaiKhoan_RowsAdded;
            dgvTaiKhoan.RowsRemoved += dgvTaiKhoan_RowsRemoved;


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

        private void LoadTaiKhoan()
        {
            // Tạo cột số thứ tự nếu chưa có
            if (!dgvTaiKhoan.Columns.Contains("STT"))
            {
                DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn();
                sttColumn.Name = "STT";
                sttColumn.HeaderText = "STT";
                sttColumn.ReadOnly = true; // Chỉ hiển thị, không chỉnh sửa
                dgvTaiKhoan.Columns.Insert(0, sttColumn); // Thêm vào vị trí đầu tiên
                sttColumn.Width = 50;
            }

            dgvTaiKhoan.DataSource = busTaiKhoan.getTaiKhoan();
            dgvTaiKhoan.Columns["MaTK"].Width = 100;
            dgvTaiKhoan.Columns["MaNV"].Width = 100;
            dgvTaiKhoan.Columns["TenDangNhap"].Width = 200;
            dgvTaiKhoan.Columns["MatKhau"].Width = 200;
            dgvTaiKhoan.Columns["QuyenHan"].Width = 300;
            dgvTaiKhoan.RowTemplate.Height = 135;

            UpdateSoThuTu();
            dgvTaiKhoan.RowHeadersVisible = false; // Ẩn tiêu đề hàng

        }

        // Phương thức cập nhật số thứ tự cho DataGridView
        private void UpdateSoThuTu()
        {
            for (int i = 0; i < dgvTaiKhoan.Rows.Count; i++)
            {
                dgvTaiKhoan.Rows[i].Cells["STT"].Value = (i + 1).ToString();
            }
        }

        // Xử lý khi thêm dòng mới vào DataGridView
        private void dgvTaiKhoan_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateSoThuTu();
        }

        // Xử lý khi xóa dòng khỏi DataGridView
        private void dgvTaiKhoan_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateSoThuTu();
        }
        public void reset()
        {
            txtMaTK.Clear();
            txtMaNV.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtQuyenHan.Clear();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            button1.Enabled = false;

            txtMaTK.ReadOnly = false;
            txtMaNV.ReadOnly = false;
            // Đặt lại màu nền cho các TextBox về màu RGB(120, 120, 120)
            Color customColor = Color.FromArgb(120, 120, 120);
            txtMaTK.BackColor = customColor;
            txtMaNV.BackColor = customColor;
            txtTenDangNhap.BackColor = customColor;
            txtMatKhau.BackColor = customColor;
            txtQuyenHan.BackColor = customColor;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường đầu vào có rỗng hay không
            if (string.IsNullOrWhiteSpace(txtMaTK.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Tài Khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTK.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Nhân Viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTK.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Đăng Nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập Mật Khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuyenHan.Text))
            {
                MessageBox.Show("Vui lòng nhập Quyền Hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuyenHan.Focus();
                return;
            }

            // Kiểm tra mã tài khoản phải bắt đầu bằng 'TK' và có định dạng đúng 

            string maTK = txtMaTK.Text.Trim();
            if (!maTK.StartsWith("TK", StringComparison.OrdinalIgnoreCase) || maTK.Length < 3 || !char.IsUpper(maTK[0]) || !char.IsUpper(maTK[1]) || !int.TryParse(maTK.Substring(2), out _))
            {
                MessageBox.Show("Mã Tài Khoản phải bắt đầu bằng 'TK' theo sau là số (ví dụ: TK01, TK02)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTK.Focus();
                return;
            }

            // Kiểm tra xem Mã Tài Khoản đã tồn tại trong cơ sở dữ liệu chưa
            if (busTaiKhoan.KiemTraTaiKhoanTonTai(maTK))
            {
                MessageBox.Show("Mã Tài Khoản đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTK.Focus();
                return;
            }

            // Kiểm tra mã tài khoản phải bắt đầu bằng 'NV' và có định dạng đúng 

            string maNV = txtMaNV.Text.Trim();
            if (!maNV.StartsWith("NV", StringComparison.OrdinalIgnoreCase) || maNV.Length < 3 || !char.IsUpper(maNV[0]) || !char.IsUpper(maNV[1]) || !int.TryParse(maNV.Substring(2), out _))
            {
                MessageBox.Show("Mã Nhân Viên phải bắt đầu bằng 'NV' theo sau là số (ví dụ: NV01, NV02)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTK.Focus();
                return;
            }

            // Kiểm tra xem mã nhân viên đã tồn tại chưa
            if (busTaiKhoan.KiemTraMaNV(txtMaNV.Text.Trim()))
            {
                MessageBox.Show("Mã Nhân Viên đã tồn tại! Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }

            string quyenHan = txtQuyenHan.Text.Trim();
            if (quyenHan != "Admin" && quyenHan != "NhanVien")
            {
                MessageBox.Show("Quyền hạn chỉ được phép là 'Admin' hoặc 'NhanVien'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuyenHan.Focus();
                return;
            }

            // Tạo đối tượng DTO_TaiKhoan với dữ liệu hợp lệ
            DTO_TaiKhoan tk = new DTO_TaiKhoan(txtMaTK.Text.Trim(), txtMaNV.Text.Trim(), txtTenDangNhap.Text.Trim(), txtMatKhau.Text.Trim(), txtQuyenHan.Text.Trim());

            // Gọi phương thức thêm tài khoản từ lớp BUS
            if (busTaiKhoan.themTaiKhoan(tk))
            {
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTaiKhoan(); // Cập nhật lại danh sách tài khoản
                reset(); // Đặt lại các trường nhập
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại! Không có mã nhân viên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra các trường đầu vào có rỗng hay không
            if (string.IsNullOrWhiteSpace(txtMaTK.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Tài Khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTK.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Đăng Nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập Mật Khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuyenHan.Text))
            {
                MessageBox.Show("Vui lòng nhập Quyền Hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuyenHan.Focus();
                return;
            }

            // Kiểm tra xem Mã Tài Khoản có tồn tại trong cơ sở dữ liệu để sửa không
            if (!busTaiKhoan.KiemTraTaiKhoanTonTai(txtMaTK.Text.Trim()))
            {
                MessageBox.Show("Mã Tài Khoản không tồn tại, không thể sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTK.Focus();
                return;
            }

            // Kiểm tra xem Mã Nhân Viên có tồn tại trong cơ sở dữ liệu để sửa không
            if (!busTaiKhoan.KiemTraMaNV(txtMaNV.Text.Trim()))
            {
                MessageBox.Show("Mã Nhân Viên không tồn tại, không thể sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }

            // Tạo đối tượng DTO_TaiKhoan với dữ liệu hợp lệ
            DTO_TaiKhoan tk = new DTO_TaiKhoan(txtMaTK.Text.Trim(), txtMaNV.Text.Trim(), txtTenDangNhap.Text.Trim(), txtMatKhau.Text.Trim(), txtQuyenHan.Text.Trim());
            // Gọi phương thức sửa tài khoản từ lớp BUS
            if (busTaiKhoan.suaTaiKhoan(tk))
            {
                MessageBox.Show("Sửa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTaiKhoan();
                reset();
            }
            else
            {
                MessageBox.Show("Sửa tài khoản thất bại! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã tài khoản có rỗng hay không
            if (string.IsNullOrWhiteSpace(txtMaTK.Text))
            {
                MessageBox.Show("Vui lòng nhập mã tài khoản để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mã tài khoản " + txtMaTK.Text + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Tiến hành xóa tài khoản
                if (busTaiKhoan.xoaTaiKhoan(txtMaTK.Text.Trim()))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTaiKhoan();
                    reset();
                }
            }
        }



        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấn vào một dòng hợp lệ không
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn từ DataGridView
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                // Lấy giá trị từ các cột và hiển thị lên các TextBox
                txtMaTK.Text = row.Cells["MaTK"].Value.ToString();
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtMaTK.ReadOnly = true;
                txtMaNV.ReadOnly = true;
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                txtQuyenHan.Text = row.Cells["QuyenHan"].Value.ToString();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                button1.Enabled = true;

                // Gọi sự kiện Enter cho các TextBox để thay đổi màu nền
                TextBox_Enter(txtMaTK, EventArgs.Empty);
                TextBox_Enter(txtMaNV, EventArgs.Empty);
                TextBox_Enter(txtTenDangNhap, EventArgs.Empty);
                TextBox_Enter(txtMatKhau, EventArgs.Empty);
                TextBox_Enter(txtQuyenHan, EventArgs.Empty);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
