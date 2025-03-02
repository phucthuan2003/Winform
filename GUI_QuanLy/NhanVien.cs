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
using System.IO;

namespace GUI_QuanLy
{
    public partial class NhanVien : Form
    {
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        public NhanVien()
        {
            InitializeComponent();

            // Thêm sự kiện cho các TextBox
            txtMaNV.Enter += TextBox_Enter;

            txtMaCV.Enter += TextBox_Enter;

            txtTenNV.Enter += TextBox_Enter;

            txtCCCD.Enter += TextBox_Enter;

            txtGT.Enter += TextBox_Enter;

            txtSDT.Enter += TextBox_Enter;

            txtDiaChi.Enter += TextBox_Enter;

            txtVaiTro.Enter += TextBox_Enter;

            // Đăng ký sự kiện TextChanged cho txtMaCV
            txtMaCV.TextChanged += txtMaCV_TextChanged;


        }


        private byte[] ConvertImageToByteArray(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    return br.ReadBytes((int)fs.Length);
                }
            }
        }
        private byte[] imageData;

        private void btnChon_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Hình ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.wmf";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imageData = ConvertImageToByteArray(ofd.FileName);
                    // Bạn có thể lưu trữ imageData vào đối tượng DTO_NhanVien tại đây
                    pictureBox1.Image = Image.FromStream(new MemoryStream(imageData));
                }
                else
                {
                    imageData = null; // Không có ảnh nào được chọn
                }
            }
        }
        private void txtMaCV_TextChanged(object sender, EventArgs e)
        {
            // Lấy mã công việc từ textbox
            string maCV = txtMaCV.Text.Trim();

            // Nếu mã công việc không rỗng, gọi phương thức lấy vai trò
            if (!string.IsNullOrEmpty(maCV) && System.Text.RegularExpressions.Regex.IsMatch(maCV, @"^CV\d+$"))
            {
                string vaiTro = busNhanVien.GetVaiTroByMaCV(maCV);

                // Hiển thị vai trò vào txtVaiTro
                txtVaiTro.Text = vaiTro;
                // Thay đổi màu nền nếu vai trò không rỗng
                if (!string.IsNullOrEmpty(vaiTro))
                {
                    txtVaiTro.BackColor = Color.White; // Màu nền khi có giá trị
                }
                else
                {
                    txtVaiTro.BackColor = Color.FromArgb(120, 120, 120);  // Màu nền khi không có giá trị
                }
            }
            else
            {
                // Nếu mã công việc rỗng, xóa nội dung txtVaiTro
                txtVaiTro.Clear();
                txtVaiTro.BackColor = Color.FromArgb(120, 120, 120);
            }
        }

        // Sự kiện khi TextBox nhận tiêu điểm
        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.BackColor = Color.White; // Đặt màu nền là trắng
            }
        }

        public void reset()
        {
            txtMaCV.Clear();
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtCCCD.Clear();
            txtGT.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtVaiTro.Clear();


            // Đặt lại màu nền cho các TextBox về màu RGB(120, 120, 120)
            Color customColor = Color.FromArgb(120, 120, 120);
            txtMaCV.BackColor = customColor;
            txtMaNV.BackColor = customColor;
            txtTenNV.BackColor = customColor;
            txtCCCD.BackColor = customColor;
            txtGT.BackColor = customColor;
            txtSDT.BackColor = customColor;
            txtVaiTro.BackColor = customColor;
            txtDiaChi.BackColor = customColor;

        }

        // Phương thức chuyển chữ cái đầu của mỗi từ thành viết hoa
        private string vietHoaChuDau(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            // Chuyển mỗi từ thành viết hoa chữ cái đầu
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text) ||
                string.IsNullOrEmpty(txtTenNV.Text) ||
                // string.IsNullOrEmpty(txtGT.Text) ||
                //  string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(txtMaCV.Text) ||
                string.IsNullOrEmpty(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin chính!");
                return;
            }

            // Ràng buộc: Mã NV phải có dạng bắt đầu bằng 'NV' viết hoa
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtMaNV.Text, @"^NV\d+$"))
            {
                MessageBox.Show("Mã nhân viên phải bắt đầu bằng 'NV' và theo sau là các chữ số (VD: NV01)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }

            // Ràng buộc: Mã công việc phải có dạng 'CV' viết hoa và theo sau là 2 chữ số
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtMaCV.Text, @"^CV\d+$"))
            {
                MessageBox.Show("Mã công việc phải tồn tại và bắt đầu bằng 'CV' và theo sau là các chữ số (VD: CV01)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                return;
            }

            // Ràng buộc: Số CCCD phải là số và có độ dài 12 ký tự
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCCCD.Text, @"^\d{12}$"))
            {
                MessageBox.Show("Số CCCD phải là số và có 12 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            //// Ràng buộc: Số điện thoại phải là số và có độ dài từ 10 đến 11 chữ số
            //if (!System.Text.RegularExpressions.Regex.IsMatch(txtSDT.Text, @"^\d{10,11}$"))
            //{
            //    MessageBox.Show("Số điện thoại phải là số và có từ 10 đến 11 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtSDT.Focus();
            //    return;
            //}

            // Chuyển đổi các trường nhập vào thành dạng chữ cái đầu viết hoa
            txtTenNV.Text = vietHoaChuDau(txtTenNV.Text);
            txtDiaChi.Text = vietHoaChuDau(txtDiaChi.Text);
            txtGT.Text = vietHoaChuDau(txtGT.Text);

            // Kiểm tra xem mã nhân viên đã tồn tại chưa
            if (busNhanVien.KiemTraMaNV(txtMaNV.Text.Trim()))
            {
                MessageBox.Show("Mã Nhân Viên đã tồn tại! Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            // Kiểm tra xem mã công việc đã tồn tại chưa
            if (!busNhanVien.KiemTraMaCV(txtMaCV.Text.Trim()))
            {
                MessageBox.Show("Mã Công Việc chưa tồn tại! Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                return;
            }


            // Tạo đối tượng DTO_NhanVien với các tham số từ form
            DTO_NhanVien nv = new DTO_NhanVien(
            txtMaNV.Text,             // Mã nhân viên
            txtTenNV.Text,            // Tên nhân viên
            txtGT.Text,               // Giới tính
            dtpNgaySinh.Value,        // Ngày sinh
            txtSDT.Text,              // Số điện thoại
            txtDiaChi.Text,           // Địa chỉ
            txtMaCV.Text,             // Mã công việc
            0,
            0,
            dtpNgayTuyen.Value,       // Ngày tuyển
            txtCCCD.Text,             // Số CCCD
            imageData
            );

            // Gọi BLL để thêm nhân viên vào cơ sở dữ liệu
            if (busNhanVien.themNhanVien(nv))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void NhanVien_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
