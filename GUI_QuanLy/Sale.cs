using DAL_QuanLy;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class Sale : Form
    {
        private readonly DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
        private readonly DAL_NhanVien dal_NhanVien = new DAL_NhanVien();
        private readonly DAL_HangHoa dal_HangHoa = new DAL_HangHoa();

        public Sale()
        {
            InitializeComponent();
        }

        public int id = 0;
        public int cusID = 0;
        public int emId = 0;

        private void Sale_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu khách hàng từ lớp DAL_KhachHang
                DataTable customerData = dal_KhachHang.GetCustomerData();
                cbCusID.DataSource = customerData;
                cbCusID.DisplayMember = "name";
                cbCusID.ValueMember = "id";
                if (cusID > 0)
                {
                    cbCusID.SelectedValue = cusID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                // Lấy dữ liệu nhân viên từ lớp DAL_NhanVien
                DataTable employData = dal_NhanVien.GetEmployData();
                cbEmId.DataSource = employData;
                cbEmId.DisplayMember = "name";
                cbEmId.ValueMember = "id";
                if (emId > 0)
                {
                    cbEmId.SelectedValue = emId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Gọi LoadProduct để tải danh sách sản phẩm
            LoadProduct();
        }

        private Image ConvertByteArrayToImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;

            try
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                // In ra thông tin lỗi để biết chi tiết hơn
                Console.WriteLine($"Lỗi khi tạo hình ảnh từ byte array: {ex.Message}");
                return null;
            }
        }

        public void AddItems(string ten, string gia, byte[] anh)
        {
            // Chuyển đổi byte[] sang Image
            var productImage = ConvertByteArrayToImage(anh);

            // Tạo một ProductView mới
            var w = new ProductView()
            {
                Pname = ten,
                Price = gia,
                Pimage = productImage
            };

            // Thêm ProductView vào layoutSP (Panel hoặc Container)
            layoutSP.Controls.Add(w);

            // Xử lý sự kiện khi người dùng chọn sản phẩm
            w.onSelect += (ss, ee) =>
            {
                var selectedProduct = (ProductView)ss;

                bool isProductInGrid = false;
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                {
                    if (item.Cells["TenHang"].Value != null && item.Cells["TenHang"].Value.ToString() == selectedProduct.Pname)
                    {
                        int currentQuantity = Convert.ToInt32(item.Cells["SoLuong"].Value ?? "0");
                        currentQuantity++;
                        item.Cells["SoLuong"].Value = currentQuantity;

                        double price = Convert.ToDouble(selectedProduct.Price);
                        item.Cells["Gia"].Value = price;
                        item.Cells["ThanhTien"].Value = price * currentQuantity;
                        GrandTotal();
                        isProductInGrid = true;
                        break;
                        
                    }
                }
                

                if (!isProductInGrid)
                {
                    double priceValue = Convert.ToDouble(selectedProduct.Price);
                    dgvHoaDon.Rows.Add(new object[]
                    {
                        selectedProduct.Pname,
                        1, 
                        priceValue,
                        priceValue 
                    });
                }
            };
        }

        public void GrandTotal()
        {
            double total = 0;
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
            {
                if (item.Cells["ThanhTien"].Value != null)
                {
                    total += Convert.ToDouble(item.Cells["ThanhTien"].Value);
                }
            }
            lblTotal.Text = total.ToString("F2"); 
        }

        private void LoadProduct()
        {
            DataTable dt = dal_HangHoa.GetInfo();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // Lấy dữ liệu từ từng hàng
                    string ten = row["TenHang"].ToString();
                    string gia = row["DonGiaBan"].ToString();
                    byte[] imageArray = (byte[])row["Anh"];

                    // Gọi hàm AddItems để thêm sản phẩm vào giao diện
                    AddItems(ten, gia, imageArray);
                }
            }
        }
        public void clearData()
        {
            cbCusID.Text = "";
            cbEmId.Text = "";
        }
    }
}
