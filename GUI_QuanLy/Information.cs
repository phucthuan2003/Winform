using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DAL_QuanLy; 

namespace GUI_QuanLy
{
    public partial class Information: Form
    {
        string maNV = Global.MaNV;
        private DAL_NhanVien dalNhanVien;

        public Information()
        {
            InitializeComponent();
            dalNhanVien = new DAL_NhanVien();
            LoadUserInfo(maNV);
        }

        private void LoadUserInfo(string maNV)
        {
            DataTable result = dalNhanVien.GetUserInfo(maNV);

            if (result.Rows.Count > 0)
            {
                lblHoten.Text = $"Họ và tên: {result.Rows[0]["TenNV"]}";
                lblCV.Text = $"Công việc: {result.Rows[0]["QuyenHan"]}";
                lblMa.Text = $"Mã nhân viên: {result.Rows[0]["MaNV"]}";
                lblCa.Text = $"Ngày tuyển: {Convert.ToDateTime(result.Rows[0]["NgayTuyen"]).ToShortDateString()}";
                lblNgaySinh.Text = $"Ngày sinh: {Convert.ToDateTime(result.Rows[0]["NgaySinh"]).ToShortDateString()}";
                lblSdt.Text = $"Số điện thoại: {result.Rows[0]["DienThoai"]}";
                lblDiaChi.Text = $"Địa chỉ: {result.Rows[0]["DiaChi"]}";

                // Chuyển đổi byte[] thành ảnh và hiển thị
                if (result.Rows[0]["HinhAnh"] != DBNull.Value)
                {
                    byte[] imgData = (byte[])result.Rows[0]["HinhAnh"];
                    Pic.Image = ConvertByteArrayToImage(imgData);
                    Pic.SizeMode = PictureBoxSizeMode.StretchImage; // Điều chỉnh kích thước ảnh cho phù hợp
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Phương thức chuyển đổi byte[] thành Image
        private Image ConvertByteArrayToImage(byte[] imageData)
        {
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                return Image.FromStream(ms);
            }
        }

        private void Information_Load(object sender, EventArgs e)
        {

        }

        private void lblMa_Click(object sender, EventArgs e)
        {

        }

        private void lblCV_Click(object sender, EventArgs e)
        {

        }

        private void lblHoten_Click(object sender, EventArgs e)
        {

        }

        private void lblCa_Click(object sender, EventArgs e)
        {

        }

        private void lblNgaySinh_Click(object sender, EventArgs e)
        {

        }

        private void lblSdt_Click(object sender, EventArgs e)
        {

        }

        private void lblDiaChi_Click(object sender, EventArgs e)
        {

        }
    }
}
