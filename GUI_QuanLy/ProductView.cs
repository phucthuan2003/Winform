using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class ProductView : UserControl
    {
        public event EventHandler onSelect = null;
        private readonly DAL_HangHoa dalHangHoa;
        public ProductView()
        {
            InitializeComponent();
            dalHangHoa = new DAL_HangHoa();
        }

        private void pbProduct_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this,e);
        }
        public int id {  get; set; }
        public string Pcost { get; set; }
        public string Pname
        {
            get
            {
                return lblName.Text;
            }
            set
            {
                lblName.Text = value;
            }
        }
        public string Price
        { get { return lblPrice.Text; } set { lblPrice.Text = value; } }
        public Image Pimage {
            get { return pbProduct.Image; } set { pbProduct.Image = value; }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            string tenHang = Pname;

            // Kiểm tra nếu ProductData có dữ liệu
            DTO_HangHoa hangHoa = dalHangHoa.GetHangHoaByTenHang(tenHang);

            if (hangHoa != null)
            {
                // Truyền chế độ "Sửa sản phẩm"
                Edit showForm = new Edit(hangHoa, this, "Thông tin");
                if (showForm.ShowDialog() == DialogResult.OK)
                {
                   
                }
                else if (showForm.DialogResult == DialogResult.Cancel)
                {
                    // Bạn có thể thêm logic ở đây nếu cần
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
