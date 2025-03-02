using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLy;
using DTO_QuanLy;

namespace GUI_QuanLy
{
    public partial class LuongNV : Form
    {
        BUS_CongViec busCongViec = new BUS_CongViec();
        public LuongNV()
        {
            InitializeComponent();
            LoadCongViec();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            button1.Enabled = false;

            // Thêm sự kiện cho các TextBox
            txtMaCV.Enter += TextBox_Enter;
            txtMaCV.Leave += TextBox_Leave;

            txtTenCV.Enter += TextBox_Enter;
            txtTenCV.Leave += TextBox_Leave;

            txtLuong.Enter += TextBox_Enter;
            txtLuong.Leave += TextBox_Leave;

            // Xử lý sự kiện thêm và xóa hàng cho DataGridView để cập nhật số thứ tự
            dgvLuong.RowsAdded += dgvTaiKhoan_RowsAdded;
            dgvLuong.RowsRemoved += dgvTaiKhoan_RowsRemoved;

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
        private void LoadCongViec()
        {
            // Tạo cột số thứ tự nếu chưa có
            if (!dgvLuong.Columns.Contains("STT"))
            {
                DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn();
                sttColumn.Name = "STT";
                sttColumn.HeaderText = "STT";
                sttColumn.ReadOnly = true; // Chỉ hiển thị, không chỉnh sửa
                dgvLuong.Columns.Insert(0, sttColumn); // Thêm vào vị trí đầu tiên
                sttColumn.Width = 50;

            }

            UpdateSoThuTu();
            dgvLuong.RowHeadersVisible = false; // Ẩn tiêu đề hàng

            dgvLuong.DataSource = busCongViec.getCongViec();
            //dvg1.DataSource = busCongViec.getCongViec();
            dgvLuong.Columns["MaCV"].Width = 170;
            dgvLuong.Columns["TenCV"].Width = 300;
            dgvLuong.Columns["MucLuong"].Width = 300;
            dgvLuong.RowTemplate.Height = 135;

        }
        // Phương thức cập nhật số thứ tự cho DataGridView
        private void UpdateSoThuTu()
        {
            for (int i = 0; i < dgvLuong.Rows.Count; i++)
            {
                dgvLuong.Rows[i].Cells["STT"].Value = (i + 1).ToString();
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
            txtMaCV.Clear();
            txtTenCV.Clear();
            txtLuong.Clear();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            button1.Enabled = false;
            txtMaCV.ReadOnly = false;

            // Đặt lại màu nền cho các TextBox về màu RGB(120, 120, 120)
            Color customColor = Color.FromArgb(120, 120, 120);
            txtMaCV.BackColor = customColor;
            txtTenCV.BackColor = customColor;
            txtLuong.BackColor = customColor;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            // Kiểm tra các trường đầu vào có rỗng hay không
            if (string.IsNullOrWhiteSpace(txtMaCV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Công Việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenCV.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Công Việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập Mức Lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuong.Focus();
                return;
            }

            // Kiểm tra xem lương có phải là số hợp lệ hay không
            if (!decimal.TryParse(txtLuong.Text, out decimal luong))
            {
                MessageBox.Show("Vui lòng nhập Mức Lương là số hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuong.Focus();
                return;
            }

            // Chuyển đổi chữ cái đầu tiên của tên công việc thành chữ hoa
            string maCV = txtMaCV.Text.Trim();
            string tenCV = txtTenCV.Text.Trim();


            // Chuyển đổi chữ cái đầu tiên của Tên Công Việc thành chữ hoa, phần còn lại là chữ thường
            if (tenCV.Length > 0)
            {
                tenCV = char.ToUpper(tenCV[0]) + tenCV.Substring(1).ToLower(); // Chữ cái đầu tiên viết hoa, còn lại thường
            }

            // Kiểm tra mã công việc phải bắt đầu bằng 'CV' và sau đó là số
            if (!maCV.StartsWith("CV", StringComparison.OrdinalIgnoreCase) ||
                 maCV.Length < 3 ||
                !char.IsUpper(maCV[0]) ||
                !char.IsUpper(maCV[1]) ||
                !int.TryParse(maCV.Substring(2), out _)) // Kiểm tra phần sau 'CV' có phải là số không
            {
                MessageBox.Show("Mã Công Việc phải bắt đầu bằng 'CV' theo sau là số (ví dụ: CV01)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                return;
            }

            // Kiểm tra xem Mã Công Việc đã tồn tại trong cơ sở dữ liệu chưa
            if (busCongViec.KiemTraCongViecTonTai(maCV))
            {
                MessageBox.Show("Mã Công Việc đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                return;
            }

            // Tạo đối tượng DTO_CongViec với dữ liệu hợp lệ
            DTO_CongViec cv = new DTO_CongViec(maCV, tenCV, luong);

            // Gọi phương thức thêm công việc từ lớp BUS
            if (busCongViec.themCongViec(cv))
            {
                MessageBox.Show("Thêm công việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCongViec();
                reset();
            }
            else
            {
                MessageBox.Show("Thêm công việc thất bại! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            // Kiểm tra các trường đầu vào có rỗng hay không
            if (string.IsNullOrWhiteSpace(txtMaCV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Công Việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenCV.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Công Việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập Mức Lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuong.Focus();
                return;
            }

            // Kiểm tra xem lương có phải là số hợp lệ hay không
            if (!decimal.TryParse(txtLuong.Text, out decimal luong))
            {
                MessageBox.Show("Vui lòng nhập Mức Lương là số hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuong.Focus();
                return;
            }

            // Chuyển đổi chữ cái đầu tiên của tên công việc thành chữ hoa
            string maCV = txtMaCV.Text.Trim();
            string tenCV = char.ToUpper(txtTenCV.Text[0]) + txtTenCV.Text.Substring(1).ToLower();

            // Kiểm tra mã công việc phải bắt đầu bằng 'CV' và sau đó là số
            if (!maCV.StartsWith("CV", StringComparison.OrdinalIgnoreCase) ||
                 maCV.Length < 3 ||
                !char.IsUpper(maCV[0]) ||
                !char.IsUpper(maCV[1]) ||
                !int.TryParse(maCV.Substring(2), out _)) // Kiểm tra phần sau 'CV' có phải là số không
            {
                MessageBox.Show("Mã Công Việc phải bắt đầu bằng 'CV' theo sau là số (ví dụ: CV01)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                return;
            }

            // Kiểm tra xem Mã Công Việc có tồn tại trong cơ sở dữ liệu để sửa không
            if (!busCongViec.KiemTraCongViecTonTai(maCV))
            {
                MessageBox.Show("Mã Công Việc không tồn tại, không thể sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                return;
            }

            // Tạo đối tượng DTO_CongViec với dữ liệu hợp lệ
            DTO_CongViec cv = new DTO_CongViec(maCV, tenCV, luong);

            // Gọi phương thức sửa công việc từ lớp BUS
            if (busCongViec.suaCongViec(cv))
            {
                MessageBox.Show("Sửa công việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCongViec(); // Cập nhật lại danh sách công việc
                reset(); // Gọi phương thức reset để làm sạch các trường
            }
            else
            {
                MessageBox.Show("Sửa công việc thất bại! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã công việc có rỗng hay không
            if (string.IsNullOrWhiteSpace(txtMaCV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã công việc để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mã công việc " + txtMaCV.Text + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Tiến hành xóa công việc
                if (busCongViec.xoaCongViec(txtMaCV.Text))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCongViec();
                    reset();
                }

            }
        }


        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấn vào một dòng hợp lệ không
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn từ DataGridView
                DataGridViewRow row = dgvLuong.Rows[e.RowIndex];

                // Lấy giá trị từ các cột và hiển thị lên các TextBox
                txtMaCV.Text = row.Cells["MaCV"].Value.ToString();
                txtMaCV.ReadOnly = true;
                txtTenCV.Text = row.Cells["TenCV"].Value.ToString();
                txtLuong.Text = row.Cells["MucLuong"].Value.ToString();

                // Kiểm tra quyền hạn trước khi bật các nút
                if (Global.QuyenHan != "NhanVien")
                {
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    button1.Enabled = true;
                }

                // Gọi sự kiện Enter cho các TextBox để thay đổi màu nền
                TextBox_Enter(txtMaCV, EventArgs.Empty);
                TextBox_Enter(txtTenCV, EventArgs.Empty);
                TextBox_Enter(txtLuong, EventArgs.Empty);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void KiemTraQuyen()
        {
            if (Global.QuyenHan == "NhanVien")
            {
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnThem.Enabled = false;

                Color disabledColor = Color.Aqua;
                btnXoa.BackColor = disabledColor;
                btnSua.BackColor = disabledColor;
                btnThem.BackColor = disabledColor;
            }
            else
            {
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnThem.Enabled = true;

                // Đặt lại màu nền gốc nếu cần
                btnXoa.BackColor = Color.IndianRed;
                btnSua.BackColor = Color.IndianRed;
                btnThem.BackColor = Color.IndianRed;
            }
        }
        private void LuongNV_Load(object sender, EventArgs e)
        {
            KiemTraQuyen();
        }

        private void dgvLuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
