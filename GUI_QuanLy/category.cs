using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class Category : Form
    {
        private string selectedComboBoxItem;
        private readonly DAL_Loai dal_Loai;
        private readonly DAL_MauSac dal_MauSac; // DAL cho màu sắc
        private readonly DAL_LoaiMen dal_LoaiMen; // DAL cho mã men
        private readonly DAL_KichThuoc  dal_KichThuoc; // DAL cho kích thước
        private readonly DAL_CongDung dal_CongDung; // DAL cho công dụng
        private readonly DAL_HoaVan dal_HoaVan; // DAL cho hoa văn
        private readonly DAL_NuocSanXuat dal_NuocSanXuat; // DAL cho nước sản xuất
        private readonly DAL_HinhKhoi dal_HinhKhoi; // DAL cho hình khối

        public Category()
        {
            InitializeComponent();
            dal_Loai = new DAL_Loai(); // Khởi tạo DAL_Loai
            dal_MauSac = new DAL_MauSac(); // Khởi tạo DAL_MauSac
            dal_LoaiMen = new DAL_LoaiMen(); // Khởi tạo DAL_MaMen
            dal_KichThuoc = new DAL_KichThuoc(); // Khởi tạo DAL_KichThuoc
            dal_CongDung = new DAL_CongDung(); // Khởi tạo DAL_CongDung
            dal_HoaVan = new DAL_HoaVan(); // Khởi tạo DAL_HoaVan
            dal_NuocSanXuat = new DAL_NuocSanXuat(); // Khởi tạo DAL_NuocSanXuat
            dal_HinhKhoi = new DAL_HinhKhoi(); // Khởi tạo DAL_HinhKhối
        }
        private void LoadData()
        {
            DataTable dataTable = null;

            switch (selectedComboBoxItem)
            {
                case "Loại":
                    dataTable = dal_Loai.GetLoaiData(); // Gọi hàm để lấy dữ liệu loại
                    break;
                case "Màu sắc":
                    dataTable = dal_MauSac.GetMauSacData(); // Gọi hàm để lấy dữ liệu màu sắc
                    break;
                case "Kích thước":
                    dataTable = dal_KichThuoc.GetKichThuocData(); // Gọi hàm để lấy dữ liệu kích thước
                    break;
                case "Công dụng":
                    dataTable = dal_CongDung.GetCongDungData(); // Gọi hàm để lấy dữ liệu loại
                    break;
                case "Nước SX":
                    dataTable = dal_NuocSanXuat.GetNuocSanXuatData(); // Gọi hàm để lấy dữ liệu màu sắc
                    break;
                case "Hình khối":
                    dataTable = dal_HinhKhoi.GetHinhKhoiData(); // Gọi hàm để lấy dữ liệu kích thước
                    break;
                case "Men":
                    dataTable = dal_LoaiMen.GetLoaiMenData(); // Gọi hàm để lấy dữ liệu kích thước
                    break;

                default:
                    break;
            }

            if (dataTable != null)
            {
                dsDanhMuc.DataSource = dataTable; // Đổ dữ liệu vào DataGridView
            }
        }


        private void cbbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Visible = true;  // Hiện label2
            label3.Visible = true;  // Hiện label3
            txt1.Visible = true; // Hiện textbox1
            txt2.Visible = true; // Hiện textbox2

            string selectedDanhMuc = cbbDanhMuc.SelectedItem.ToString();
            DataTable dataTable = null;
            LoadData();
            switch (selectedDanhMuc)
            {
                case "Loại":
                    label2.Text = "Mã loại";
                    label3.Text = "Tên loại";
                    dataTable = dal_Loai.GetLoaiData(); // Gọi hàm để lấy dữ liệu loại
                    selectedComboBoxItem = "Loại";
                    break;
                case "Màu sắc":
                    label2.Text = "Mã màu";
                    label3.Text = "Tên màu";
                    dataTable = dal_MauSac.GetMauSacData(); // Gọi hàm để lấy dữ liệu màu sắc
                    selectedComboBoxItem = "Màu sắc";
                    break;
                case "Men":
                    label2.Text = "Mã men";
                    label3.Text = "Tên men";
                    dataTable = dal_LoaiMen.GetLoaiMenData(); // Gọi hàm để lấy dữ liệu mã men
                    selectedComboBoxItem = "Men";
                    break;
                case "Kích thước":
                    label2.Text = "Mã kích thước";
                    label3.Text = "Tên kích thước";
                    dataTable = dal_KichThuoc.GetKichThuocData(); // Gọi hàm để lấy dữ liệu kích thước
                    selectedComboBoxItem = "Kích thước";
                    break;
                case "Công dụng":
                    label2.Text = "Mã công dụng";
                    label3.Text = "Tên công dụng";
                    dataTable = dal_CongDung.GetCongDungData(); // Gọi hàm để lấy dữ liệu công dụng
                    selectedComboBoxItem = "Công dụng";
                    break;
                case "Hoa văn":
                    label2.Text = "Mã hoa văn";
                    label3.Text = "Tên hoa văn";
                    dataTable = dal_HoaVan.GetLoaiData(); // Gọi hàm để lấy dữ liệu hoa văn
                    selectedComboBoxItem = "Hoa văn";
                    break;
                case "Nước SX":
                    label2.Text = "Mã nước SX";
                    label3.Text = "Tên nước SX";
                    dataTable = dal_NuocSanXuat.GetNuocSanXuatData(); // Gọi hàm để lấy dữ liệu nước sản xuất
                    selectedComboBoxItem = "Nước SX";
                    break;
                case "Hình khối":
                    label2.Text = "Mã hình khối";
                    label3.Text = "Tên hình khối";
                    dataTable = dal_HinhKhoi.GetHinhKhoiData(); // Gọi hàm để lấy dữ liệu hình khối
                    selectedComboBoxItem = "Hình khối";
                    break;
                default:
                    // Xử lý cho bảng mặc định...
                    break;
            }

            if (dataTable != null)
            {
                dsDanhMuc.DataSource = dataTable; // Đổ dữ liệu vào DataGridView
            }
        }
        private void dsDanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy hàng đã chọn
                DataGridViewRow selectedRow = dsDanhMuc.Rows[e.RowIndex];

                switch (selectedComboBoxItem)
                {
                    case "Loại":
                        txt1.Text = selectedRow.Cells["MaLoai"].Value?.ToString(); // Lấy giá trị Mã loại
                        txt2.Text = selectedRow.Cells["TenLoai"].Value?.ToString(); // Lấy giá trị Tên loại
                        break;

                    case "Màu sắc":
                        txt1.Text = selectedRow.Cells["MaMau"].Value?.ToString(); // Lấy giá trị Mã màu
                        txt2.Text = selectedRow.Cells["TenMau"].Value?.ToString(); // Lấy giá trị Tên màu
                        break;

                    case "Men":
                        txt1.Text = selectedRow.Cells["MaLoaiMen"].Value?.ToString(); // Lấy giá trị Mã men
                        txt2.Text = selectedRow.Cells["TenLoaiMen"].Value?.ToString(); // Lấy giá trị Tên men
                        break;

                    case "Kích thước":
                        txt1.Text = selectedRow.Cells["MaKichThuoc"].Value?.ToString(); // Lấy giá trị Mã kích thước
                        txt2.Text = selectedRow.Cells["TenKichThuoc"].Value?.ToString(); // Lấy giá trị Tên kích thước
                        break;

                    case "Công dụng":
                        txt1.Text = selectedRow.Cells["MaCongDung"].Value?.ToString(); // Lấy giá trị Mã công dụng
                        txt2.Text = selectedRow.Cells["TenCongDung"].Value?.ToString(); // Lấy giá trị Tên công dụng
                        break;

                    case "Hoa văn":
                        txt1.Text = selectedRow.Cells["MaHoaVan"].Value?.ToString(); // Lấy giá trị Mã hoa văn
                        txt2.Text = selectedRow.Cells["TenHoaVan"].Value?.ToString(); // Lấy giá trị Tên hoa văn
                        break;

                    case "Nước SX":
                        txt1.Text = selectedRow.Cells["MaNuocSX"].Value?.ToString(); // Lấy giá trị Mã nước sản xuất
                        txt2.Text = selectedRow.Cells["TenNuocSX"].Value?.ToString(); // Lấy giá trị Tên nước sản xuất
                        break;

                    case "Hình khối":
                        txt1.Text = selectedRow.Cells["MaHinhKhoi"].Value?.ToString(); // Lấy giá trị Mã hình khối
                        txt2.Text = selectedRow.Cells["TenHinhKhoi"].Value?.ToString(); // Lấy giá trị Tên hình khối
                        break;

                    default:
                        break;
                }
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text.Trim();
            string ten = txt2.Text.Trim();

            // Kiểm tra xem các ô nhập liệu có trống không
            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Thực hiện thêm dữ liệu vào bảng tương ứng dựa trên mục được chọn
                switch (selectedComboBoxItem)
                {
                    case "Loại":
                        dal_Loai.AddLoai(ma, ten);
                        break;
                    case "Màu sắc":
                        dal_MauSac.AddMauSac(ma, ten); // Thêm dữ liệu vào bảng Màu sắc
                        break;
                    case "Kích thước":
                        dal_KichThuoc.AddKichThuoc(ma, ten); // Thêm dữ liệu vào bảng Kích thước
                        break;
                    case "Công dụng":
                        dal_CongDung.AddCongDung(ma, ten); // Thêm dữ liệu vào bảng Công dụng
                        break;
                    case "Hoa văn":
                        dal_HoaVan.AddHoaVan(ma, ten); // Thêm dữ liệu vào bảng Hoa văn
                        break;
                    case "Nước SX":
                        dal_NuocSanXuat.AddNuocSanXuat(ma, ten); // Thêm dữ liệu vào bảng Nước sản xuất
                        break;
                    case "Hình khối":
                        dal_HinhKhoi.AddHinhKhoi(ma, ten); // Thêm dữ liệu vào bảng Hình khối
                        break;
                    case "Men":
                        dal_LoaiMen.AddLoaiMen(ma, ten); // Thêm dữ liệu vào bảng Mã men
                        break;
                    default:
                        throw new Exception("Bảng không hợp lệ.");
                }

                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Làm mới DataGridView sau khi thêm thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text.Trim();
            string ten = txt2.Text.Trim();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng chọn hàng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                switch (selectedComboBoxItem)
                {
                    case "Loại":
                        dal_Loai.UpdateLoai(ma, ten);
                        break;
                    case "Hoa văn":
                        dal_HoaVan.UpdateHoaVan(ma, ten);
                        break;
                    case "Kích thước":
                        dal_KichThuoc.UpdateKichThuoc(ma, ten);
                        break;
                    case "Màu sắc":
                        dal_MauSac.UpdateMauSac(ma, ten);
                        break;
                    case "Công dụng":
                        dal_CongDung.UpdateCongDung(ma, ten);
                        break;
                    case "Nước SX":
                        dal_NuocSanXuat.UpdateNuocSanXuat(ma, ten);
                        break;
                    case "Hình khối":
                        dal_HinhKhoi.UpdateHinhKhoi(ma, ten);
                        break;
                    case "Men":
                        dal_LoaiMen.UpdateLoaiMen(ma, ten);
                        break;
                    default:
                        throw new Exception("Bảng không hợp lệ.");
                }

                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Làm mới DataGridView sau khi sửa
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text.Trim();

            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Vui lòng chọn hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                switch (selectedComboBoxItem)
                {
                    case "Loại":
                        dal_Loai.DeleteLoai(ma);
                        break;
                    case "Hoa văn":
                        dal_HoaVan.DeleteHoaVan(ma);
                        break;
                    case "Kích thước":
                        dal_KichThuoc.DeleteKichThuoc(ma);
                        break;
                    case "Màu sắc":
                        dal_MauSac.DeleteMauSac(ma);
                        break;
                    case "Công dụng":
                        dal_CongDung.DeleteCongDung(ma);
                        break;
                    case "Nước SX":
                        dal_NuocSanXuat.DeleteNuocSanXuat(ma);
                        break;
                    case "Hình khối":
                        dal_HinhKhoi.DeleteHinhKhoi(ma);
                        break;
                    case "Men":
                        dal_LoaiMen.DeleteLoaiMen(ma);
                        break;
                    default:
                        throw new Exception("Bảng không hợp lệ.");
                }

                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Làm mới DataGridView sau khi xóa
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void txt2_TextChanged(object sender, EventArgs e)
		{

		}

		private void txt1_TextChanged(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}
