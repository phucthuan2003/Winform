using System;
using System.Windows.Forms;
using DAL_QuanLy;
using DTO_QuanLy;

namespace GUI_QuanLy
{
    public partial class Signin : Form
    {
        private DAL_TaiKhoan dalTaiKhoan;
        private bool isPasswordVisible = false;

        public Signin()
        {
            InitializeComponent();
            dalTaiKhoan = new DAL_TaiKhoan();
            this.Shown += new System.EventHandler(this.Signin_Shown);

        }
        private void Signin_Shown(object sender, EventArgs e)
        {
            txtUser.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Uname = txtUser.Text;
            string pass = txtPassword.Text;

            if (Uname.Trim() == "")
            {
                MessageBox.Show("Required enter username!", "Announce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (pass.Trim() == "")
            {
                MessageBox.Show("Required enter password!", "Announce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string maNV = dalTaiKhoan.VerifyUser(Uname, pass);
                string tenNV = dalTaiKhoan.VerifyUser1(Uname, pass);
                string quyenHan = dalTaiKhoan.VerifyUser2(Uname, pass);
                if (maNV != null)
                {
                    Success.Show();
                    Global.MaNV = maNV;
                    Global.TenNV = tenNV;
                    Global.QuyenHan = quyenHan;
                    GUI_TrangChu a = new GUI_TrangChu();
                    a.Show();
                }
                else
                {
                    Failed.Show();
                }
            }
        }

        private void Signin_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '•';
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            isPasswordVisible = true;
            txtPassword.PasswordChar = '\0';
            btnShow.Visible = false;
            btnHide.Visible = true;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            isPasswordVisible = false;
            txtPassword.PasswordChar = '•';
            btnHide.Visible = false;
            btnShow.Visible = true;
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

