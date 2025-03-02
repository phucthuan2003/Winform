using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class Edit : Form
    {
        private readonly DAL_HangHoa dalHangHoa;
        private readonly DAL_Loai dAL_Loai = new DAL_Loai();
        private readonly DAL_KichThuoc dAL_KichThuoc = new DAL_KichThuoc();
        private readonly DAL_CongDung dAL_CongDung = new DAL_CongDung();
        private readonly DAL_HinhKhoi dAL_HinhKhoi = new DAL_HinhKhoi();
        private readonly DAL_MauSac dAL_MauSac = new DAL_MauSac();
        private readonly DAL_LoaiMen dAL_LoaiMen = new DAL_LoaiMen();
        private readonly DAL_NuocSanXuat dAL_NuocSanXuat = new DAL_NuocSanXuat();
        private readonly DAL_NhaCungCap dAL_NhaCungCap = new DAL_NhaCungCap();
        public DTO_HangHoa HangHoa { get; set; }
        public int typID = 0;
        public int sizeID = 0;
        public int useID = 0;
        public int HKID = 0;
        public int ColorID = 0;
        public int MenID = 0;
        public int countryID = 0;
        public int hangID = 0;

        private readonly InfoProduct infoProductForm;

        // Tham số để xác định chế độ (thêm, sửa, hay thông tin)
        private string mode;

        public Edit(DTO_HangHoa hangHoa, InfoProduct infoProduct, string mode)
        {
            InitializeComponent();
            dalHangHoa = new DAL_HangHoa();
            HangHoa = hangHoa;
            infoProductForm = infoProduct;
            this.mode = mode; // Lưu chế độ

            // Cập nhật tiêu đề form dựa trên chế độ
            if (mode == "Thêm")
            {
                btnTitle.Text = "Thêm Sản Phẩm";
            }
            else if (mode == "Sửa")
            {
                btnTitle.Text = "Sửa Sản Phẩm";
            }
            else if (mode == "Thông tin")
            {
                btnTitle.Text = "Thông Tin Sản Phẩm";
            }
            else
            {
                this.Text = "Edit";
            }

            LoadHangHoaData();

            // Kiểm tra chế độ để hiển thị nút tương ứng
            if (mode == "Thêm")
            {
                btnLuu.Visible = false; // Ẩn nút Lưu
                btnThem.Visible = true;  // Hiện nút Thêm
            }
            else if (mode == "Sửa")
            {
                btnLuu.Visible = true;   // Hiện nút Lưu
                btnThem.Visible = false;  // Ẩn nút Thêm
            }
            else // Thông tin sản phẩm
            {
                btnLuu.Visible = false; // Ẩn nút Lưu
                btnThem.Visible = false; // Ẩn nút Thêm
            }
        }
        public Edit(DTO_HangHoa hangHoa, ProductView productView, string mode)
        {
            InitializeComponent();
            dalHangHoa = new DAL_HangHoa();
            HangHoa = hangHoa;
            productView = productView;
            this.mode = mode; // Lưu chế độ

            // Cập nhật tiêu đề form dựa trên chế độ
            if (mode == "Thêm")
            {
                btnTitle.Text = "Thêm Sản Phẩm";
            }
            else if (mode == "Sửa")
            {
                btnTitle.Text = "Sửa Sản Phẩm";
            }
            else if (mode == "Thông tin")
            {
                btnTitle.Text = "Thông Tin Sản Phẩm";
            }
            else
            {
                this.Text = "Edit";
            }

            LoadHangHoaData();

            // Kiểm tra chế độ để hiển thị nút tương ứng
            if (mode == "Thêm")
            {
                btnLuu.Visible = false; // Ẩn nút Lưu
                btnThem.Visible = true;  // Hiện nút Thêm
            }
            else if (mode == "Sửa")
            {
                btnLuu.Visible = true;   // Hiện nút Lưu
                btnThem.Visible = false;  // Ẩn nút Thêm
            }
            else // Thông tin sản phẩm
            {
                btnLuu.Visible = false; // Ẩn nút Lưu
                btnThem.Visible = false; // Ẩn nút Thêm
            }
        }
        public Edit(DTO_HangHoa hangHoa, urSanPham sanPham, string mode)
        {
            InitializeComponent();
            dalHangHoa = new DAL_HangHoa();
            HangHoa = hangHoa;
            sanPham = sanPham;
            this.mode = mode; // Lưu chế độ

            // Cập nhật tiêu đề form dựa trên chế độ
            if (mode == "Thêm")
            {
                btnTitle.Text = "Thêm Sản Phẩm";
            }
            else if (mode == "Sửa")
            {
                btnTitle.Text = "Sửa Sản Phẩm";
            }
            else if (mode == "Thông tin")
            {
                btnTitle.Text = "Thông Tin Sản Phẩm";
            }
            else
            {
                this.Text = "Edit";
            }

            LoadHangHoaData();

            // Kiểm tra chế độ để hiển thị nút tương ứng
            if (mode == "Thêm")
            {
                btnLuu.Visible = false; // Ẩn nút Lưu
                btnThem.Visible = true;  // Hiện nút Thêm
            }
            else if (mode == "Sửa")
            {
                btnLuu.Visible = true;   // Hiện nút Lưu
                btnThem.Visible = false;  // Ẩn nút Thêm
            }
            else // Thông tin sản phẩm
            {
                btnLuu.Visible = false; // Ẩn nút Lưu
                btnThem.Visible = false; // Ẩn nút Thêm
            }
        }
        private void LoadHangHoaData()
        {
            if (HangHoa != null)
            {
                txtMaHang.Text = HangHoa.MaHang;
                txtTenHang.Text = HangHoa.TenHangHoa;
                txtSoLuong.Text = HangHoa.SoLuong.ToString();
                txtDGB.Text = HangHoa.DonGiaBan.ToString();
                txtDGN.Text = HangHoa.DonGiaNhap.ToString();
                txtGhiChu.Text = HangHoa.GhiChu;

                // Kiểm tra ảnh và hiển thị ảnh từ byte[], nếu có ảnh hợp lệ
                if (HangHoa.Anh != null && HangHoa.Anh.Length > 0)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(HangHoa.Anh))
                        {
                            picpoc.Image = Image.FromStream(ms);
                        }
                    }
                    catch
                    {
                        // Nếu có lỗi khi tải ảnh, sử dụng ảnh mặc định
                        picpoc.Image = Properties.Resources.logo;
                        MessageBox.Show("Ảnh sản phẩm không hợp lệ, đang sử dụng ảnh mặc định.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Sử dụng ảnh mặc định nếu không có ảnh
                    picpoc.Image = Properties.Resources.logo;
                }

                // Cập nhật thêm các thuộc tính còn lại
                cbbLoaiID.Text = HangHoa.MaLoai;
                cbbKT.Text = HangHoa.MaKichThuoc;
                cbbMen.Text = HangHoa.MaLoaiMen;
                cbbMau.Text = HangHoa.MaMau;
                cbbCD.Text = HangHoa.MaCongDung;
                cbbHK.Text = HangHoa.MaHinhKhoi;
                cbbNSX.Text = HangHoa.MaNuocSX;
                cbbNCC.Text = HangHoa.MaNCC;
            }

            // Nếu chế độ là "Thông tin sản phẩm", khóa các trường nhập
            if (mode == "Thông tin")
            {
                txtMaHang.Enabled = false;
                txtTenHang.Enabled = false;
                txtSoLuong.Enabled = false;
                txtDGB.Enabled = false;
                txtGhiChu.Enabled = false;
                cbbLoaiID.Enabled = false;
                cbbKT.Enabled = false;
                cbbMen.Enabled = false;
                cbbMau.Enabled = false;
                cbbCD.Enabled = false;
                cbbHK.Enabled = false;
                txtDGN.Enabled = false;
                cbbNSX.Enabled = false;
                cbbNCC.Enabled = false;
                btnChonAnh.Enabled = false;
            }
            if (mode == "Sửa")
            {
                txtMaHang.Enabled = false;
                cbbNCC.Enabled = false;

            }
        }



        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                UpdateHangHoa();
                this.DialogResult = DialogResult.OK;
                this.Close(); // Đóng form Edit
                infoProductForm.LoadData(); // Tải lại dữ liệu trong InfoProduct
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã hàng đã tồn tại chưa
            string maHang = txtMaHang.Text;
            if (dalHangHoa.CheckMaHangExists(maHang))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHang.Focus();
                return;
            }

            // Xử lý ảnh
            byte[] anh = GetImageBytes(txtAnh.Text);
            if (anh == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng DTO_HangHoa
            var hangHoa = new DTO_HangHoa
            {
                MaHang = maHang,
                TenHangHoa = txtTenHang.Text,
                MaLoai = cbbLoaiID.Text,
                MaKichThuoc = cbbKT.Text,
                MaLoaiMen = cbbMen.Text,
                MaMau = cbbMau.Text,
                SoLuong = int.Parse(txtSoLuong.Text),
                DonGiaBan = decimal.Parse(txtDGB.Text),
                DonGiaNhap = decimal.Parse(txtDGN.Text),
                Anh = anh,
                GhiChu = txtGhiChu.Text,
                MaCongDung = cbbCD.Text,
                MaHinhKhoi = cbbHK.Text,
                MaNuocSX = cbbNSX.Text,
                MaNCC = cbbNCC.Text
            };

            // Thêm hàng hóa
            dalHangHoa.AddHangHoa(hangHoa);

            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearData();
            this.Close(); // Đóng form Edit
            infoProductForm.LoadData(); // Tải lại dữ liệu trong InfoProduct
        }

        private bool ValidateInputs()
        {
            // Kiểm tra các trường bắt buộc phải có dữ liệu
            if (string.IsNullOrWhiteSpace(txtMaHang.Text) ||
                string.IsNullOrWhiteSpace(txtTenHang.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtDGB.Text) ||
                string.IsNullOrWhiteSpace(txtDGN.Text) ||
                string.IsNullOrWhiteSpace(cbbLoaiID.Text) ||
                string.IsNullOrWhiteSpace(cbbKT.Text) ||
                string.IsNullOrWhiteSpace(cbbMen.Text) ||
                string.IsNullOrWhiteSpace(cbbMau.Text) ||
                string.IsNullOrWhiteSpace(cbbCD.Text) ||
                string.IsNullOrWhiteSpace(cbbHK.Text) ||
                string.IsNullOrWhiteSpace(cbbNSX.Text) ||
                string.IsNullOrWhiteSpace(cbbNCC.Text) ||
                string.IsNullOrWhiteSpace(txtGhiChu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cho tất cả các trường bắt buộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra các trường số lượng và đơn giá phải là số hợp lệ
            if (!int.TryParse(txtSoLuong.Text, out _) || int.Parse(txtSoLuong.Text) <= 0)
            {
                MessageBox.Show("Số lượng phải là một số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtDGB.Text, out _) || decimal.Parse(txtDGB.Text) <= 0)
            {
                MessageBox.Show("Đơn giá bán phải là một số dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtDGN.Text, out _) || decimal.Parse(txtDGN.Text) <= 0)
            {
                MessageBox.Show("Đơn giá nhập phải là một số dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void UpdateHangHoa()
        {

            // Cập nhật các thuộc tính của HangHoa từ các điều khiển
            HangHoa.TenHangHoa = txtTenHang.Text;
            HangHoa.SoLuong = int.Parse(txtSoLuong.Text);
            HangHoa.DonGiaBan = decimal.Parse(txtDGB.Text);
            HangHoa.DonGiaNhap = decimal.Parse(txtDGN.Text); // Cập nhật Đơn giá nhập nếu có
            HangHoa.GhiChu = txtGhiChu.Text;
            HangHoa.MaLoai = cbbLoaiID.Text; // Cập nhật các thuộc tính khác
            HangHoa.MaKichThuoc = cbbKT.Text;
            HangHoa.MaLoaiMen = cbbMen.Text;
            HangHoa.MaMau = cbbMau.Text;
            HangHoa.MaCongDung = cbbCD.Text;
            HangHoa.MaHinhKhoi = cbbHK.Text;
            HangHoa.MaNuocSX = cbbNSX.Text;


            // Chuyển đổi đường dẫn ảnh thành byte[]
            byte[] anh = GetImageBytes(txtAnh.Text);
            if (anh != null)
            {
                HangHoa.Anh = anh;
            }

            // Gọi phương thức cập nhật trong DAL
            dalHangHoa.UpdateHangHoa(HangHoa);

            // Hiển thị thông báo thành công
            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtAnh.Text = openFileDialog.FileName;
                    try
                    {
                        picpoc.Image = new Bitmap(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private byte[] GetImageBytes(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return null;

            try
            {
                return File.ReadAllBytes(filePath);
            }
            catch
            {
                MessageBox.Show("Không thể đọc file ảnh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void clearData()
        {
            txtMaHang.Clear();
            txtTenHang.Clear();
            cbbLoaiID.Text = " ";
            cbbKT.Text = " ";
            cbbMen.Text = " ";
            cbbMau.Text = " ";
            txtSoLuong.Clear();
            txtDGB.Clear();
            txtDGN.Clear();
            txtAnh.Clear();
            txtGhiChu.Clear();
            cbbCD.Text = " ";
            cbbHK.Text = " ";
            cbbNSX.Text = " ";
            cbbNCC.Text = " ";
            picpoc.Image = null;
        }

        private void btnTitle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Gán kết quả là Cancel
            this.Close(); // Đóng form hiện tại
        }

        private void txtTenHang_Load(object sender, EventArgs e)
        {

        }

        private void Edit_Load(object sender, EventArgs e)
        {
            try
            {
                // Gán dữ liệu cho các ComboBox
                BindComboBox(cbbLoaiID, dAL_Loai.GetTypeData(), "id", "name", typID);
                BindComboBox(cbbKT, dAL_KichThuoc.GetTypeData(), "id", "name", sizeID);
                BindComboBox(cbbMen, dAL_LoaiMen.GetTypeData(), "id", "name", MenID);
                BindComboBox(cbbCD, dAL_CongDung.GetTypeData(), "id", "name", useID);
                BindComboBox(cbbHK, dAL_HinhKhoi.GetTypeData(), "id", "name", HKID);
                BindComboBox(cbbMau, dAL_MauSac.GetTypeData(), "id", "name", ColorID);
                BindComboBox(cbbNSX, dAL_NuocSanXuat.GetTypeData(), "id", "name", countryID);
                BindComboBox(cbbNCC, dAL_NhaCungCap.GetTypeData(), "id", "name", hangID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức chung để gán dữ liệu cho ComboBox
        private void BindComboBox(ComboBox comboBox, DataTable data, string valueMember, string displayMember, int selectedValue)
        {
            comboBox.DataSource = data;
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
            if (selectedValue > 0)
            {
                comboBox.SelectedValue = selectedValue;
            }
        }
    }
}