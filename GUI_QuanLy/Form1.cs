using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadHomePage();
        }

        private void LoadHomePage()
        {
            HomePage homePage = new HomePage();
            LoadFormIntoPanel(homePage);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        public void LoadFormIntoPanel(Form childForm)
        {
            // Xóa các control hiện tại trong panel
            panelAll.Controls.Clear();

            // Thiết lập form con
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelAll.Controls.Add(childForm);
            childForm.Show();
        }

        
    }
}