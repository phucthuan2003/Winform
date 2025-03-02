using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QuanLy;
using BUS_QuanLy;
using COMExcel = Microsoft.Office.Interop.Excel;
using DAL_QuanLy;

namespace GUI_QuanLy
{
    public partial class GUI_TaoHoaDonBan : Form
    {
        BUS_KhachHang busKH = new BUS_KhachHang();
        BUS_HangHoa busHH = new BUS_HangHoa();
        BUS_NhanVien busNV = new BUS_NhanVien();
        BUS_HoaDonBan busHDB = new BUS_HoaDonBan();
        BUS_ChiTietHoaDonBan busCT = new BUS_ChiTietHoaDonBan();
        BUS_TaiKhoan busTK = new BUS_TaiKhoan();

        BindingSource bindingSource = new BindingSource();
        private List<DTO_ChiTietHoaDonBan> chiTietHoaDonBanList = new List<DTO_ChiTietHoaDonBan>();

        // Khởi tạo giao diện thêm hóa đơn mới
        public GUI_TaoHoaDonBan()
        {
            InitializeComponent();
            LoadForm();
        }

        private void LoadForm()
        {
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnXoa.Enabled = false;
            txtMaHD.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            cbMaKH.Enabled = false;
            txtDiaChi.ReadOnly = true;
            txtSDT.ReadOnly = false;
            txtDiaChi.Enabled = true ;
            txtTenHang.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";

            LoadDataComboBox();

            // Tạo mã hóa đơn mới nếu vào chế độ thêm mới
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                txtMaHD.Text = busHDB.TaoMaHoaDon();
                cbMaMV.Text = Global.MaNV;
                txtTenNV.Text = busTK.GetEmployeeNameByAccount(Global.MaNV);
            }
        }

        //Nạp dữ liệu vào combobox
        private void LoadDataComboBox()
        {
            // Nạp danh sách mã khách hàng
            cbMaKH.DataSource = busKH.LayDanhSachKhachHang();
            cbMaKH.DisplayMember = "MaKhach";
            cbMaKH.ValueMember = "MaKhach";

            // Nạp danh sách mã hàng
            cbMaHang.DataSource = busHH.LayDanhSachHangHoa();
            cbMaHang.DisplayMember = "MaHang";
            cbMaHang.ValueMember = "MaHang";
        }

        private void CapNhatTongTien()
        {
            decimal tongTien = 0;
            foreach (var row in chiTietHoaDonBanList)
            {
                tongTien += row.ThanhTien;
            }
            txtTongTien.Text = tongTien.ToString("N0");
        }

        private void cbMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaHang.SelectedIndex != null)
            {
                string maHH = cbMaHang.SelectedValue.ToString();
                var hangHoa = busHH.LayThongTinHangHoa(maHH);

                if (hangHoa != null)
                {
                    txtTenHang.Text = hangHoa.TenHangHoa;
                    txtDonGia.Text = hangHoa.DonGiaBan.ToString("N0");
                }

            }
        }

        private void cbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maKH = cbMaKH.SelectedValue.ToString();
            var khachHang = busKH.LayThongTinKhachHang(maKH);

            if (khachHang != null)
            {
                txtTenKH.Text = khachHang.TenKhach;
                txtDiaChi.Text = khachHang.DiaChi;
                txtSDT.Text = khachHang.DienThoai;
            }
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            //string soDienThoai = txtSDT.Text;

            //// Kiểm tra số điện thoại đã tồn tại chưa
            //var khachHang = busKH.TimKiemKhachHangTheoSDT(soDienThoai);

            //if (khachHang != null)
            //{
            //    // Nếu có, hiển thị thông tin khách hàng vào các trường tương ứng
            //    txtTenKH.Text = khachHang.TenKhach;
            //    txtDiaChi.Text = khachHang.DiaChi;
            //    cbMaKH.Text = khachHang.MaKhach;
            //}
            //else
            //{
            //    // Nếu chưa có, tự động sinh mã khách hàng và yêu cầu người dùng nhập thêm thông tin
            //    txtTenKH.Text = string.Empty;
            //    txtDiaChi.Text = string.Empty;
            //    //cbMaKH.Text = SinhMaKhachHangMoi();
            //}
        }



        private void dgvDSMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu hàng được chọn hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy hàng đã chọn
                DataGridViewRow row = dgvDSMatHang.Rows[e.RowIndex];

                // Cập nhật các ô nhập liệu với thông tin từ hàng đã chọn
                cbMaHang.SelectedValue = row.Cells["MaHang"].Value.ToString();
                txtTenHang.Text = row.Cells["TenHang"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGiaBan"].Value.ToString();
                txtGiamGia.Text = row.Cells["GiamGia"].Value.ToString();
            }
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Lấy số lượng tồn kho của mặt hàng từ cơ sở dữ liệu
                string maHH = cbMaHang.SelectedValue.ToString();
                int soLuongTonKho = busHH.LaySoLuongSanPham(maHH);

                // Kiểm tra dữ liệu hợp lệ trước khi tính toán
                if (int.TryParse(txtSoLuong.Text, out int soLuong) && decimal.TryParse(txtDonGia.Text, out decimal donGia))
                {
                    // Kiểm tra số lượng nhập không vượt quá tồn kho
                    if (soLuong > soLuongTonKho)
                    {
                        MessageBox.Show($"Số lượng bán không được vượt quá số lượng tồn kho ({soLuongTonKho}).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSoLuong.Text = soLuongTonKho.ToString();
                        txtSoLuong.Focus();
                        return;
                    }

                    decimal giamGia = string.IsNullOrEmpty(txtGiamGia.Text) ? 0 : decimal.Parse(txtGiamGia.Text);
                    decimal thanhTien = soLuong * donGia * (1 - giamGia / 100);

                    // Tìm chi tiết hóa đơn tương ứng với mã hàng được chọn
                    var selectedItem = chiTietHoaDonBanList.Find(item => item.MaHang == cbMaHang.SelectedValue.ToString());

                    if (selectedItem != null)
                    {
                        // Cập nhật số lượng và thành tiền của chi tiết hóa đơn
                        selectedItem.SoLuong = soLuong;
                        selectedItem.GiamGia = giamGia;
                        selectedItem.ThanhTien = thanhTien;
                    }
                    else
                    {
                        // Tạo chi tiết hóa đơn mới
                        DTO_ChiTietHoaDonBan chiTiet = new DTO_ChiTietHoaDonBan
                        {
                            MaHang = cbMaHang.SelectedValue.ToString(),
                            TenHang = txtTenHang.Text,
                            SoLuong = soLuong,
                            GiamGia = giamGia,
                            DonGiaBan = donGia,
                            ThanhTien = thanhTien
                        };

                        // Thêm vào danh sách chi tiết hóa đơn
                        chiTietHoaDonBanList.Add(chiTiet);
                    }

                    // Cập nhật DataGridView
                    bindingSource.DataSource = null; // Reset DataSource
                    bindingSource.DataSource = chiTietHoaDonBanList; // Gán lại DataSource
                    dgvDSMatHang.DataSource = bindingSource;
                    // Ẩn cột "SoHDB"
                    dgvDSMatHang.Columns["SoHDB"].Visible = false;
                    dgvDSMatHang.Columns["NgayBan"].Visible = false;
                    dgvDSMatHang.Columns["MaNV"].Visible = false ;

                    // Đổi tên các cột
                    dgvDSMatHang.Columns["MaHang"].HeaderText = "Mã Hàng";
                    dgvDSMatHang.Columns["TenHang"].HeaderText = "Tên Hàng";
                    dgvDSMatHang.Columns["TenHang"].DisplayIndex = 2;
                    dgvDSMatHang.Columns["SoLuong"].HeaderText = "Số Lượng";
                    dgvDSMatHang.Columns["DonGiaBan"].HeaderText = "Đơn Giá";
                    dgvDSMatHang.Columns["GiamGia"].HeaderText = "Giảm Giá (%)";
                    dgvDSMatHang.Columns["ThanhTien"].HeaderText = "Thành Tiền";


                    dgvDSMatHang.RowTemplate.Height = 135;

                    // Cập nhật tổng tiền
                    CapNhatTongTien();

                    // Reset các trường nhập liệu
                    txtSoLuong.Clear();
                    txtGiamGia.Clear();
                    txtGiamGia.Text = "0";
                    cbMaHang.Focus(); // Đặt con trỏ lại vào ô nhập số lượng
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ.");
                }
            }
        }
        private void txtGiamGia_KeyDown(object sender, KeyEventArgs e)
        {
            // Lấy số lượng tồn kho của mặt hàng từ cơ sở dữ liệu
            string maHH = cbMaHang.SelectedValue.ToString();
            int soLuongTonKho = busHH.LaySoLuongSanPham(maHH);

            if (e.KeyCode == Keys.Enter)
            {
                // Kiểm tra dữ liệu hợp lệ trước khi tính toán
                if (int.TryParse(txtSoLuong.Text, out int soLuong) && decimal.TryParse(txtDonGia.Text, out decimal donGia))
                {
                    // Kiểm tra số lượng nhập không vượt quá tồn kho
                    if (soLuong > soLuongTonKho)
                    {
                        MessageBox.Show($"Số lượng bán không được vượt quá số lượng tồn kho ({soLuongTonKho}).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSoLuong.Text = soLuongTonKho.ToString();
                        txtSoLuong.Focus();
                        return;
                    }

                    // Kiểm tra giá trị giảm giá có hợp lệ hay không
                    decimal giamGia = string.IsNullOrEmpty(txtGiamGia.Text) ? 0 : decimal.Parse(txtGiamGia.Text);
                    decimal thanhTien = soLuong * donGia * (1 - giamGia / 100);

                    // Tìm chi tiết hóa đơn tương ứng với mã hàng được chọn
                    var selectedItem = chiTietHoaDonBanList.Find(item => item.MaHang == cbMaHang.SelectedValue.ToString());

                    if (selectedItem != null)
                    {
                        // Cập nhật số lượng, giảm giá và thành tiền của chi tiết hóa đơn
                        selectedItem.GiamGia = giamGia;
                        selectedItem.ThanhTien = thanhTien;
                    }
                    else
                    {
                        // Tạo chi tiết hóa đơn mới
                        DTO_ChiTietHoaDonBan chiTiet = new DTO_ChiTietHoaDonBan
                        {
                            MaHang = cbMaHang.SelectedValue.ToString(),
                            TenHang = txtTenHang.Text,
                            SoLuong = soLuong,
                            GiamGia = giamGia,
                            DonGiaBan = donGia,
                            ThanhTien = thanhTien
                        };

                        // Thêm vào danh sách chi tiết hóa đơn
                        chiTietHoaDonBanList.Add(chiTiet);
                    }

                    // Cập nhật DataGridView
                    bindingSource.DataSource = null; // Reset DataSource
                    bindingSource.DataSource = chiTietHoaDonBanList; // Gán lại DataSource
                    dgvDSMatHang.DataSource = bindingSource;

                    // Ẩn cột "SoHDB"
                    dgvDSMatHang.Columns["SoHDB"].Visible = false;
                    dgvDSMatHang.Columns["NgayBan"].Visible = false;
                    dgvDSMatHang.Columns["MaNV"].Visible = false;

                    // Đổi tên các cột
                    dgvDSMatHang.Columns["MaHang"].HeaderText = "Mã Hàng";
                    dgvDSMatHang.Columns["TenHang"].HeaderText = "Tên Hàng";
                    dgvDSMatHang.Columns["TenHang"].DisplayIndex = 2;
                    dgvDSMatHang.Columns["SoLuong"].HeaderText = "Số Lượng";
                    dgvDSMatHang.Columns["DonGiaBan"].HeaderText = "Đơn Giá";
                    dgvDSMatHang.Columns["GiamGia"].HeaderText = "Giảm Giá (%)";
                    dgvDSMatHang.Columns["ThanhTien"].HeaderText = "Thành Tiền";

                    dgvDSMatHang.RowTemplate.Height = 135;

                    // Cập nhật tổng tiền
                    CapNhatTongTien();

                    // Reset các trường nhập liệu
                    txtGiamGia.Clear();
                    cbMaHang.Focus(); // Đặt con trỏ lại vào ô nhập mã hàng
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số lượng và đơn giá hợp lệ.");
                }
            }
        }

        private Action updateDanhSachHoaDon; // Biến callback
        public GUI_TaoHoaDonBan(Action updateDanhSachHoaDon)
        {
            InitializeComponent();
            this.updateDanhSachHoaDon = updateDanhSachHoaDon;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string soHDB = txtMaHD.Text;
            // Kiểm tra các trường thông tin không được để trống
            if (string.IsNullOrEmpty(txtMaHD.Text) ||
                string.IsNullOrEmpty(cbMaKH.Text) ||
                string.IsNullOrEmpty(cbMaMV.Text) ||
                chiTietHoaDonBanList.Count == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hóa đơn và ít nhất một chi tiết hóa đơn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu có trường không hợp lệ
            }

            // Kiểm tra giá trị số lượng và giảm giá
            foreach (var chiTiet in chiTietHoaDonBanList)
            {
                if (chiTiet.SoLuong < 1)
                {
                    MessageBox.Show("Số lượng không được nhỏ hơn 1.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (chiTiet.GiamGia < 0 || chiTiet.GiamGia >= 100)
                {
                    MessageBox.Show("Giảm giá phải lớn hơn hoặc bằng 0 và nhỏ hơn 100.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var sodt = txtSDT.Text.Trim();

            // Nếu khách hàng chưa tồn tại
            if (busKH.TimKiemKhachHangTheoSDT(sodt) == null)
            {
                var newCustomer = new DTO_KhachHang
                {
                    MaKhach = cbMaKH.Text.Trim(),
                    TenKhach = txtTenKH.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    DienThoai = sodt
                };

                busKH.themKhachHang(newCustomer); // Lưu khách hàng mới
            }

            decimal tongTienGiamGia = 0;

            foreach (var chiTiet in chiTietHoaDonBanList)
            {
                tongTienGiamGia += chiTiet.SoLuong * chiTiet.DonGiaBan * chiTiet.GiamGia/100;
            }

            DTO_HoaDonBan hoaDon = new DTO_HoaDonBan
            {
                SoHDB = txtMaHD.Text,
                NgayBan = dtpNgayBan.Value,
                MaNV = cbMaMV.Text,
                MaKhach = cbMaKH.Text,
                // Tính và cập nhật tổng giảm giá
                GiamGia = tongTienGiamGia,
                TongTien = decimal.Parse(txtTongTien.Text)
            };

            // Thêm hóa đơn mới
            busHDB.ThemHoaDon(hoaDon);

            // Lấy lại SoHDB vừa thêm (nếu mã tự động sinh ra)
            hoaDon.SoHDB = busHDB.LaySoHDBCuoi();

            // Thêm chi tiết hóa đơn
            foreach (var chiTiet in chiTietHoaDonBanList)
            {
                chiTiet.SoHDB = hoaDon.SoHDB;
                busCT.ThemChiTietHoaDon(chiTiet);

                // Cập nhật số lượng tồn kho sau khi bán
                busHH.CapNhatSoLuongConLai(chiTiet.MaHang, chiTiet.SoLuong); // Trừ số lượng đã bán
            }

            MessageBox.Show("Hóa đơn đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            bindingSource.ResetBindings(false);

            // Kích hoạt nút xóa sau khi lưu thành công
            btnXoa.Enabled = true;
            btnIn.Enabled = true;

            // Sau khi thêm hóa đơn thành công, gọi callback
            updateDanhSachHoaDon?.Invoke(); // Thông báo form chính cập nhật
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                busHDB.XoaHoaDon(txtMaHD.Text);
                MessageBox.Show("Xóa hóa đơn thành công!");
                this.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GUI_TaoHoaDonBan_Load(object sender, EventArgs e)
        {
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string soHDB = txtMaHD.Text;
            //busCT.InChiTietHoaDon(soHDB); // In chi tiết hóa đơn
            GUI_InHoaDonBan frmReport = new GUI_InHoaDonBan()
            {
                SoHDB = soHDB
            };
            frmReport.ShowDialog();
        }

        private void dgvDSMatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sodt = txtSDT.Text.Trim();

                // Tìm kiếm thông tin khách hàng theo số điện thoại
                var customer = busKH.TimKiemKhachHangTheoSDT(sodt);

                if (customer != null)
                {
                    // Nếu thông tin khách hàng đã tồn tại
                    cbMaKH.Text = customer.MaKhach;
                    txtTenKH.Text = customer.TenKhach;
                    txtDiaChi.Text = customer.DiaChi;

                    // Đặt trạng thái readonly
                    cbMaKH.Enabled = true;
                    txtTenKH.ReadOnly = true;
                    txtDiaChi.ReadOnly = true;

                    MessageBox.Show("Thông tin khách hàng đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Nếu khách hàng chưa tồn tại
                    cbMaKH.Text = busKH.SinhMaKhachHangTuDong();
                    txtTenKH.Text = string.Empty;
                    txtDiaChi.Text = string.Empty;

                    // Đặt trạng thái readonly
                    cbMaKH.Enabled = true;
                    txtTenKH.ReadOnly = false;
                    txtDiaChi.ReadOnly = false;

                    // Đưa con trỏ vào ô Tên khách hàng để nhập
                    txtTenKH.Focus();
                }
            }
        }
    }
}