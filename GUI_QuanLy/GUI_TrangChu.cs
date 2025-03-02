using BUS_QuanLy;
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
    public partial class GUI_TrangChu : Form
    {
        public GUI_TrangChu()
        {
            InitializeComponent();
            customizeDesing();
        }

        //sideBar
        private void customizeDesing()
        {
            panelSPSubmenu.Visible = false;
            panelHDSubmenu.Visible = false;
            panelNSSubmenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelSPSubmenu.Visible == true)
                panelSPSubmenu.Visible = false;
            if (panelHDSubmenu.Visible == true)
                panelHDSubmenu.Visible = false;
            if (panelNSSubmenu.Visible == true)
                panelNSSubmenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;

        }
        //subMenu
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSPSubmenu);
        }
        private void btnThongTinSanPham_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new InfoProduct());
            //hideSubMenu();
        }

        private void btnTraCuuTinhTrang_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new GUI_TatCaSanPham());
            //hideSubMenu();
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Category());
            //hideSubMenu();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            showSubMenu(panelHDSubmenu);
        }



        private void btnHoaDonBan_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new GUI_HoaDonBan());
            //hideSubMenu();
        }

        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new GUI_HoaDonNhap());
            //hideSubMenu();
        }

        private void btnNhanSu_Click(object sender, EventArgs e)
        {

            showSubMenu(panelNSSubmenu);
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new TKNhanVien());
            //hideSubMenu();
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new LuongNV());
            //hideSubMenu();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new TaiKhoan());
            //hideSubMenu();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void GUI_TrangChu_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            label1.Text = Global.TenNV;

            // Kiểm tra quyền hạn và ẩn nút btnTaiKhoan nếu người dùng là Nhân viên
            if (Global.QuyenHan == "NhanVien")
            {
                btnTaiKhoan.Enabled = false;
                btnTaiKhoan.BackColor = Color.Aqua;
                btnBaoCaoThongKe.Enabled = false;
                btnBaoCaoThongKe.BackColor = Color.Aqua;
                btnNhanSu.Enabled = false;
                btnNhanSu.BackColor = Color.Aqua;
            }
        }



        //Phuong thuc mo trang
        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new HomePage());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxAvatar_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Information());
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new TKNhaCC());
            hideSubMenu();
        }

        private void btnBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new BaoCaoThongKe());
            hideSubMenu();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new TkKhach());
            hideSubMenu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Kiểm tra lựa chọn của người dùng
            if (result == DialogResult.Yes)
            {
                // Ẩn form hiện tại
                this.Hide();

                // Hiển thị lại form đăng nhập
                Signin frmSignIn = new Signin();
                frmSignIn.Show();
            }
            // Nếu người dùng chọn No, không thực hiện gì
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}