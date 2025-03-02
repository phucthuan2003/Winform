using BUS_QuanLy;
using DTO_QuanLy;
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
    public partial class NhaCC : Form
    {
        BUS_NhaCungCap busNhaCungCap = new BUS_NhaCungCap();
        public NhaCC()
        {
            InitializeComponent();
            LoadNhaCungCap();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // Thêm sự kiện cho các TextBox
            txtMaNCC.Enter += TextBox_Enter;
            txtMaNCC.Leave += TextBox_Leave;

            txtTenNCC.Enter += TextBox_Enter;
            txtTenNCC.Leave += TextBox_Leave;

            txtDiaChi.Enter += TextBox_Enter;
            txtDiaChi.Leave += TextBox_Leave;

            txtDienThoai.Enter += TextBox_Enter;
            txtDienThoai.Leave += TextBox_Leave;

            // Xử lý sự kiện thêm và xóa hàng cho DataGridView để cập nhật số thứ tự
            dgvNCC.RowsAdded += dgvNhaCungCap_RowsAdded;
            dgvNCC.RowsRemoved += dgvNhaCungCap_RowsRemoved;
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

        private void LoadNhaCungCap()
        {
            // Tạo cột số thứ tự nếu chưa có
            if (!dgvNCC.Columns.Contains("STT"))
            {
                DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                {
                    Name = "STT",
                    HeaderText = "STT",
                    ReadOnly = true
                };
                dgvNCC.Columns.Insert(0, sttColumn); // Thêm vào vị trí đầu tiên
                sttColumn.Width = 30;
            }

            UpdateSoThuTu();
            dgvNCC.RowHeadersVisible = false; // Ẩn tiêu đề hàng

            dgvNCC.DataSource = busNhaCungCap.getNhaCungCap();
            dgvNCC.Columns["MaNCC"].Width = 150;
            dgvNCC.Columns["TenNCC"].Width = 200;
            dgvNCC.Columns["DiaChi"].Width = 300;
            dgvNCC.Columns["DienThoai"].Width = 150;
            dgvNCC.RowTemplate.Height = 135;
        }

        // Phương thức cập nhật số thứ tự cho DataGridView
        private void UpdateSoThuTu()
        {
            for (int i = 0; i < dgvNCC.Rows.Count; i++)
            {
                dgvNCC.Rows[i].Cells["STT"].Value = (i + 1).ToString();
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

        public void reset()
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // Đặt lại màu nền cho các TextBox về màu mặc định
            Color customColor = Color.FromArgb(120, 120, 120);
            txtMaNCC.BackColor = customColor;
            txtTenNCC.BackColor = customColor;
            txtDiaChi.BackColor = customColor;
            txtDienThoai.BackColor = customColor;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường đầu vào có rỗng hay không
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Nhà Cung Cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Nhà Cung Cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
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

            // Kiểm tra mã nhà cung cấp đã tồn tại
            if (busNhaCungCap.KiemTraNhaCungCapTonTai(txtMaNCC.Text.Trim()))
            {
                MessageBox.Show("Mã nhà cung cấp đã tồn tại! Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }

            string maNhaCungCap = txtMaNCC.Text.Trim();
            // Kiểm tra mã nhà cung cấp phải bắt đầu bằng 'NCC' và sau đó là số
            if (!maNhaCungCap.StartsWith("NCC", StringComparison.OrdinalIgnoreCase) ||
                maNhaCungCap.Length < 4 || // Đảm bảo chiều dài tối thiểu là 4 ký tự (2 ký tự cho 'NCC' và 2 ký tự cho số)
                !char.IsUpper(maNhaCungCap[0]) ||
                !char.IsUpper(maNhaCungCap[1]) ||
                !char.IsUpper(maNhaCungCap[2]) ||
                !int.TryParse(maNhaCungCap.Substring(3), out _)) // Kiểm tra phần sau 'NCC' có phải là số không
            {
                MessageBox.Show("Mã Nhà Cung Cấp phải bắt đầu bằng 'NCC' theo sau là số (ví dụ: NCC01)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }

            // Tạo đối tượng DTO_NhaCungCap với dữ liệu hợp lệ
            DTO_NhaCungCap ncc = new DTO_NhaCungCap(txtMaNCC.Text.Trim(), txtTenNCC.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim());

            // Gọi phương thức thêm nhà cung cấp từ lớp BUS
            if (busNhaCungCap.themNhaCungCap(ncc))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhaCungCap();
                reset();
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường đầu vào có rỗng hay không
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Nhà Cung Cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Nhà Cung Cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
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

            // Kiểm tra mã nhà cung cấp đã tồn tại
            if (!busNhaCungCap.KiemTraNhaCungCapTonTai(txtMaNCC.Text.Trim()))
            {
                MessageBox.Show("Mã nhà cung cấp không tồn tại, không thể sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }


            // Tạo đối tượng DTO_NhaCungCap với dữ liệu hợp lệ
            DTO_NhaCungCap ncc = new DTO_NhaCungCap(txtMaNCC.Text.Trim(), txtTenNCC.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim());

            // Gọi phương thức sửa nhà cung cấp từ lớp BUS
            if (busNhaCungCap.suaNhaCungCap(ncc))
            {
                MessageBox.Show("Sửa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhaCungCap();
                reset();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sửa nhà cung cấp thất bại! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Xác nhận xóa nhà cung cấp
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                // Gọi phương thức xóa nhà cung cấp từ lớp BUS
                if (busNhaCungCap.xoaNhaCungCap(txtMaNCC.Text.Trim()))
                {
                    MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNhaCungCap();
                    reset();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xóa nhà cung cấp thất bại! Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu có dòng được chọn
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin khách hàng từ dòng đã chọn
                txtMaNCC.Text = dgvNCC.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = dgvNCC.Rows[e.RowIndex].Cells["TenNCC"].Value.ToString();
                txtDiaChi.Text = dgvNCC.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                txtDienThoai.Text = dgvNCC.Rows[e.RowIndex].Cells["DienThoai"].Value.ToString();

                btnSua.Enabled = true; // Bật nút sửa
                btnXoa.Enabled = true; // Bật nút xóa

                // Gọi sự kiện Enter cho các TextBox để thay đổi màu nền
                TextBox_Enter(txtMaNCC, EventArgs.Empty);
                TextBox_Enter(txtTenNCC, EventArgs.Empty);
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
