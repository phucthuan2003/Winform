using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DAL_QuanLy;

namespace GUI_QuanLy
{
    public partial class GUI_TatCaSanPham : Form
    {
        private DAL_HangHoa db = new DAL_HangHoa();

        public GUI_TatCaSanPham()
        {
            InitializeComponent();
        }

        private void GUI_TatCaSanPham_Load(object sender, EventArgs e)
        {
            LoadSanPhamFromDatabase();
        }

        public void AddItems(string id, string name, string price, Image image)
        {
            var productControl = new urSanPham()
            {
                Pname = name,
                Price = price,
                PImage = image,
                id = id,
                Margin = new Padding(10)
            };

            flowLayoutPanel1.Controls.Add(productControl);
        }

        private void LoadSanPhamFromDatabase(string searchColumn = "", string searchText = "")
        {
            flowLayoutPanel1.Controls.Clear();

            try
            {
                DataTable dt = db.GetHangHoa(searchColumn, searchText);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string id = row["MaHang"].ToString();
                        string name = row["TenHang"].ToString();
                        string price = row["DonGiaBan"].ToString();

                        Image productImage = null;
                        if (row["Anh"] != DBNull.Value)
                        {
                            byte[] imgData = (byte[])row["Anh"];
                            productImage = ConvertByteArrayToImage(imgData);
                        }
                        else
                        {
                            // Đặt ảnh mặc định nếu không có ảnh
                            //productImage = Image.FromFile(@"C:\Users\ninhc\OneDrive\Hình ảnh\Mat.jpg");
                        }

                        AddItems(id, name, price, productImage);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchColumn = "";
            string searchText = txtSearch.Text.Trim();

            if (cbSearch.SelectedItem?.ToString() == "Mã hàng")
            {
                searchColumn = "MaHang";
            }
            else if (cbSearch.SelectedItem?.ToString() == "Tên hàng")
            {
                searchColumn = "TenHang";
            }

            if (!string.IsNullOrEmpty(searchColumn))
            {
                LoadSanPhamFromDatabase(searchColumn, searchText);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một loại tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            foreach (Control item in flowLayoutPanel1.Controls)
            {
                if (item is urSanPham pro)
                {
                    if (cbSearch.SelectedItem?.ToString() == "Mã hàng")
                    {
                        pro.Visible = pro.id.ToLower().Contains(txtSearch.Text.Trim().ToLower());
                    }
                    else if (cbSearch.SelectedItem?.ToString() == "Tên hàng")
                    {
                        pro.Visible = pro.Pname.ToLower().Contains(txtSearch.Text.Trim().ToLower());
                    }
                }
            }
        }

        //private void btnTim_Click(object sender, EventArgs e)
        //{
        //    string searchColumn = "";
        //    string searchText = txtSearch.Text.Trim();

        //    if (string.IsNullOrEmpty(searchText))
        //    {
        //        MessageBox.Show("Vui lòng nhập nội dung cần tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // Xác định cột tìm kiếm dựa trên lựa chọn trong ComboBox
        //    if (cbSearch.SelectedItem?.ToString() == "Mã hàng")
        //    {
        //        searchColumn = "MaHang";
        //    }
        //    else if (cbSearch.SelectedItem?.ToString() == "Tên hàng")
        //    {
        //        searchColumn = "TenHang";
        //    }

        //    if (!string.IsNullOrEmpty(searchColumn))
        //    {
        //        // Gọi hàm để tải dữ liệu sản phẩm từ cơ sở dữ liệu với cột và từ khóa tìm kiếm
        //        LoadSanPhamFromDatabase(searchColumn, searchText);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Vui lòng chọn một loại tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

    }
}
