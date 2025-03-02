using BUS_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class GUI_TaoHoaDonNhap : Form
    {
        BUS_HangHoa busHH = new BUS_HangHoa();
        BUS_NhanVien busNV = new BUS_NhanVien();
        BUS_TaiKhoan busTK = new BUS_TaiKhoan();
        BUS_NhaCungCap busNCC = new BUS_NhaCungCap();
        BUS_HoaDonNhap busHDN = new BUS_HoaDonNhap();
        BUS_ChiTietHoaDonNhap busCT = new BUS_ChiTietHoaDonNhap();

        BindingSource bindingSource = new BindingSource();
        private List<DTO_ChiTietHoaDonNhap> chiTietHoaDonNhapList = new List<DTO_ChiTietHoaDonNhap>();

        public GUI_TaoHoaDonNhap()
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
            txtTenNCC.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtTongTien.Text = "0";

            LoadDataComboBox();

            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                txtMaHD.Text = busHDN.TaoMaHoaDon();
                cbMaMV.Text = Global.MaNV;
                txtTenNV.Text = busTK.GetEmployeeNameByAccount(Global.MaNV);
            }
        }

        private void LoadDataComboBox()
        {
            cbMaNCC.DataSource = busNCC.LayDanhSachNhaCungCap();
            cbMaNCC.DisplayMember = "MaNCC";
            cbMaNCC.ValueMember = "MaNCC";

            cbMaHang.DataSource = busHH.LayDanhSachHangHoa();
            cbMaHang.DisplayMember = "MaHang";
            cbMaHang.ValueMember = "MaHang";
        }

        private void CapNhatTongTien()
        {
            decimal tongTien = 0;
            foreach (var row in chiTietHoaDonNhapList)
            {
                tongTien += row.ThanhTien;
            }
            txtTongTien.Text = tongTien.ToString("N0");
        }

        private void cbMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaHang.SelectedIndex >= 0)
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

        private void cbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaNCC.SelectedIndex >= 0)
            {
                string maNCC = cbMaNCC.SelectedValue.ToString();
                // Lấy thông tin nhà cung cấp
                var nhaCungCap = busNCC.LayThongTinNhaCungCap(maNCC);
                if (nhaCungCap != null)
                {
                    txtTenNCC.Text = nhaCungCap.TenNCC;
                    txtDiaChi.Text = nhaCungCap.DiaChi;
                    txtSDT.Text = nhaCungCap.DienThoai;

                    // Lấy danh sách hàng hóa theo mã nhà cung cấp
                    var danhSachHangHoa = busHH.LayDanhSachHangHoaTheoNCC(maNCC);
                    // Kiểm tra và cập nhật combobox MaHang
                    if (danhSachHangHoa.Count == 0)
                    {
                        cbMaHang.DataSource = null;
                        MessageBox.Show("Không có hàng hóa nào thuộc nhà cung cấp này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        cbMaHang.DataSource = danhSachHangHoa;
                        cbMaHang.DisplayMember = "MaHang"; // Tên cột hiển thị
                        cbMaHang.ValueMember = "MaHang";      // Tên cột giá trị
                    }
                }
            }
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(txtSoLuong.Text, out int soLuong) && decimal.TryParse(txtDonGia.Text, out decimal donGia))
                {
                    decimal thanhTien = soLuong * donGia;

                    var selectedItem = chiTietHoaDonNhapList.Find(item => item.MaHang == cbMaHang.SelectedValue.ToString());

                    if (selectedItem != null)
                    {
                        selectedItem.SoLuong = soLuong;
                        selectedItem.ThanhTien = thanhTien;
                    }
                    else
                    {
                        DTO_ChiTietHoaDonNhap chiTiet = new DTO_ChiTietHoaDonNhap
                        {
                            MaHang = cbMaHang.SelectedValue.ToString(),
                            TenHang = txtTenHang.Text,
                            SoLuong = soLuong,
                            DonGia = donGia,
                            ThanhTien = thanhTien
                        };

                        chiTietHoaDonNhapList.Add(chiTiet);
                    }

                    bindingSource.DataSource = null;
                    bindingSource.DataSource = chiTietHoaDonNhapList;
                    dgvDSMatHang.DataSource = bindingSource;
                    dgvDSMatHang.Columns["SoHDN"].Visible = false;
                    dgvDSMatHang.Columns["MaNV"].Visible = false;
                    dgvDSMatHang.Columns["NgayNhap"].Visible = false;

                    dgvDSMatHang.Columns["MaHang"].HeaderText = "Mã Hàng";
                    dgvDSMatHang.Columns["TenHang"].HeaderText = "Tên Hàng";
                    dgvDSMatHang.Columns["SoLuong"].HeaderText = "Số Lượng";
                    dgvDSMatHang.Columns["DonGia"].HeaderText = "Đơn Giá";
                    dgvDSMatHang.Columns["ThanhTien"].HeaderText = "Thành Tiền";

                    dgvDSMatHang.RowTemplate.Height = 135;
                    CapNhatTongTien();

                    txtSoLuong.Clear();
                    cbMaHang.Focus();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ.");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text) ||
                string.IsNullOrEmpty(cbMaNCC.Text) ||
                string.IsNullOrEmpty(cbMaMV.Text) ||
                chiTietHoaDonNhapList.Count == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hóa đơn và ít nhất một chi tiết hóa đơn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var chiTiet in chiTietHoaDonNhapList)
            {
                if (chiTiet.SoLuong < 1)
                {
                    MessageBox.Show("Số lượng không được nhỏ hơn 1.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DTO_HoaDonNhap hoaDon = new DTO_HoaDonNhap
            {
                SoHDN = txtMaHD.Text,
                NgayNhap = dtpNgayNhap.Value,
                MaNV = cbMaMV.Text,
                MaNCC = cbMaNCC.Text,
                TongTien = decimal.Parse(txtTongTien.Text)
            };

            busHDN.ThemHoaDon(hoaDon);

            hoaDon.SoHDN = busHDN.LaySoHDNCuoi();

            foreach (var chiTiet in chiTietHoaDonNhapList)
            {
                chiTiet.SoHDN = hoaDon.SoHDN;
                busCT.ThemChiTietHoaDon(chiTiet);

                // Cập nhật số lượng tồn kho sau khi nhập
                busHH.CapNhatSoLuongTrongKho(chiTiet.MaHang, chiTiet.SoLuong); 
            }

            MessageBox.Show("Hóa đơn đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            bindingSource.ResetBindings(false);

            btnXoa.Enabled = true;
            btnIn.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                busHDN.XoaHoaDon(txtMaHD.Text);
                MessageBox.Show("Xóa hóa đơn thành công!");
                this.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string soHDN = txtMaHD.Text;
            //busCT.InChiTietHoaDon(soHDB); // In chi tiết hóa đơn
            GUI_InHoaDonNhap frmReport = new GUI_InHoaDonNhap()
            {
                SoHDN = soHDN
            };
            frmReport.ShowDialog();
        }
    }
}
