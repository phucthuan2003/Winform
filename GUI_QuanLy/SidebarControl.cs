using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class SidebarControl : UserControl
    {
        private Timer timerSanPham;
        private Timer timerHoaDon;
        private Timer timerNhanSu;
        private bool menuSanPhamExpand = false;
        private bool menuHoaDonExpand = false;
        private bool menuNhanSuExpand = false;

        public SidebarControl()
        {
            InitializeComponent();
            InitializeTimers();
            ResetMenuHeights();
            resetButton();
        }

        private void SidebarControl_Load(object sender, EventArgs e)
        {
            ResetMenuHeights();
        }

        private void InitializeTimers()
        {
            timerSanPham = new Timer { Interval = 10 };
            timerHoaDon = new Timer { Interval = 10 };
            timerNhanSu = new Timer { Interval = 10 };
            timerSanPham.Tick += timerSanPham_Tick;
            timerHoaDon.Tick += timerHoaDon_Tick;
            timerNhanSu.Tick += timerNhanSu_Tick;
        }

        private void ResetMenuHeights()
        {
            panelSP.Height = 38;
            panelHoaDon.Height = 38;
            panelNhanSu.Height = 38;
            menuSanPhamExpand = false;
            menuHoaDonExpand = false;
            menuNhanSuExpand = false;
        }

        private void timerSanPham_Tick(object sender, EventArgs e)
        {
            ToggleMenu(timerSanPham, panelSP, ref menuSanPhamExpand, 160, 38, MoveButtons1, 110);
        }

        private void timerHoaDon_Tick(object sender, EventArgs e)
        {
            ToggleMenu(timerHoaDon, panelHoaDon, ref menuHoaDonExpand, 120, 38, MoveButtons, 80);
        }

        private void timerNhanSu_Tick(object sender, EventArgs e)
        {
            ToggleMenu(timerNhanSu, panelNhanSu, ref menuNhanSuExpand, 160, 38, MoveButtons2, 110);
        }

        private void ToggleMenu(Timer timer, Panel panel, ref bool isExpanded, int expandedHeight, int collapsedHeight, Action<int> moveButtons, int offsetY)
        {
            int expandSpeed = 10;

            if (!isExpanded)
            {
                if (panel.Height < expandedHeight)
                {
                    panel.Height += expandSpeed;
                    if (panel.Height >= expandedHeight)
                    {
                        panel.Height = expandedHeight;
                        timer.Stop();
                        isExpanded = true;
                        moveButtons(offsetY);
                    }
                }
            }
            else
            {
                if (panel.Height > collapsedHeight)
                {
                    panel.Height -= expandSpeed;
                    if (panel.Height <= collapsedHeight)
                    {
                        panel.Height = collapsedHeight;
                        timer.Stop();
                        isExpanded = false;
                        moveButtons(-offsetY);
                    }
                }
            }
        }


        private void btnSanPham_Click(object sender, EventArgs e)
        {
            timerSanPham.Start();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            timerHoaDon.Start();
        }

        private void btnNhanSu_Click(object sender, EventArgs e)
        {
            timerNhanSu.Start();
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            LoadForm(new InfoProduct());
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            LoadForm(new HomePage());
        }
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            LoadForm(new Lookup());
        }
        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            LoadForm(new Category());
        }
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            LoadForm(new TkKhach());
        }
        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            LoadForm(new TKNhanVien());
        }
        private void btnLuong_Click(object sender, EventArgs e)
        {
            LoadForm(new LuongNV());
        }
        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            LoadForm(new TaiKhoan());
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            LoadForm(new TKNhaCC());
        }
        private void LoadForm(Form childForm)
        {
            Form1 parentForm = (Form1)this.FindForm();
            if (parentForm != null)
            {
                parentForm.LoadFormIntoPanel(childForm);
            }
        }


        private void MoveButtons(int offsetY)
        {
            AdjustButtonPositions(offsetY, btnKhachHang, panelNhanSu, btnNhaCungCap, btnThongKe, picTK, picKH, picNCC, btnThoat);
        }

        private void MoveButtons1(int offsetY)
        {
            AdjustButtonPositions(offsetY, panelHoaDon, btnKhachHang, panelNhanSu, btnNhaCungCap, btnThongKe, picTK, picKH, picNCC, btnThoat);
        }

        private void MoveButtons2(int offsetY)
        {
            AdjustButtonPositions(offsetY, btnNhaCungCap, picNCC, btnThongKe, picTK, btnThoat);
        }

        private void AdjustButtonPositions(int offsetY, params Control[] controls)
        {
            foreach (var control in controls)
            {
                control.Location = new Point(control.Location.X, control.Location.Y + offsetY);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void resetButton()
        {
            btnTrangChu.Refresh();
            btnNhanSu.Refresh();
            btnSanPham.Refresh();
            btnThongTin.Refresh();
            btnDanhMuc.Refresh();
            btnTraCuu.Refresh();
            btnHoaDon.Refresh();
            btnNhaCungCap.Refresh();
            btnKhachHang.Refresh();
            btnHoaDonBan.Refresh();
            btnHoaDonNhap.Refresh();
            btnLuong.Refresh();
            btnDanhSach.Refresh();
            btnTaiKhoan.Refresh();
            btnThongKe.Refresh();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadForm(new Statistics_Report());
        }
    }
}