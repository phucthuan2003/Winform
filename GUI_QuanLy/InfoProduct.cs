using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class InfoProduct : Form
    {
        private readonly DAL_HangHoa dalHangHoa;

        public InfoProduct()
        {
            InitializeComponent();
            dalHangHoa = new DAL_HangHoa();
            LoadData();
        }

        public void LoadData() // Phương thức để tải dữ liệu
        {
            DataTable dataTable = dalHangHoa.GetHangHoaData();
            dtDanhSach.DataSource = dataTable;

            // Đánh số thứ tự cho hàng
            for (int i = 0; i < dtDanhSach.Rows.Count; i++)
            {
                dtDanhSach.Rows[i].Cells[0].Value = i + 1; // Cột thứ tự
            }

            // Hiển thị các cột ChiTiet, Sua, Xoa nếu có
            SetColumnVisibility("ChiTiet");
            SetColumnVisibility("Xoa");
            Sua.Visible = true;

            dtDanhSach.AllowUserToAddRows = false;
            ThongKe.Visible = false; // Ẩn điều này nếu không cần thiết
        }

        private void SetColumnVisibility(string columnName)
        {
            if (dtDanhSach.Columns.Contains(columnName))
            {
                dtDanhSach.Columns[columnName].Visible = true;
            }
        }


        private void dtDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Kiểm tra nếu hàng là header
            if (e.ColumnIndex == dtDanhSach.Columns["ChiTiet"].Index)
            {
                ShowInfoProduct(e.RowIndex);
            }
            else if (e.ColumnIndex == dtDanhSach.Columns["Sua"].Index)
            {
                EditProduct(e.RowIndex);
            }
            else if (e.ColumnIndex == dtDanhSach.Columns["Xoa"].Index)
            {
                DeleteProduct(e.RowIndex);
            }
        }

        private void EditProduct(int rowIndex)
        {
            string tenHang = dtDanhSach.Rows[rowIndex].Cells["TenHang"].Value.ToString();
            DTO_HangHoa hangHoa = dalHangHoa.GetHangHoaByTenHang(tenHang);

            if (hangHoa != null)
            {
                Edit editForm = new Edit(hangHoa, this, "Sửa");
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Tải lại dữ liệu sau khi sửa
                }
                else if (editForm.DialogResult == DialogResult.Cancel)
                {
                    // Bạn có thể thêm logic ở đây nếu cần
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowInfoProduct(int rowIndex)
        {
            string tenHang = dtDanhSach.Rows[rowIndex].Cells["TenHang"].Value.ToString();
            DTO_HangHoa hangHoa = dalHangHoa.GetHangHoaByTenHang(tenHang);

            if (hangHoa != null)
            {
                // Truyền chế độ "Sửa sản phẩm"
                Edit showForm = new Edit(hangHoa, this, "Thông tin");
                if (showForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Tải lại dữ liệu sau khi sửa
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

        // Khi thêm sản phẩm
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            Edit addForm = new Edit(null, this, "Thêm");
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Tải lại dữ liệu sau khi sửa
            }
            else if (addForm.DialogResult == DialogResult.Cancel)
            {
               
            }
        }

        private void DeleteProduct(int rowIndex)
        {
            // Lấy tên hàng từ dòng được chọn
            string tenHang = dtDanhSach.Rows[rowIndex].Cells["TenHang"].Value.ToString();
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn ngừng kinh doanh sản phẩm '{tenHang}'?", "Xác nhận ngừng kinh doanh", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                // Lấy mã hàng từ tên hàng
                string maHang = dalHangHoa.GetMaHangByTenHang(tenHang); // Gọi phương thức đã tạo trước đó

                if (maHang != null) // Nếu mã hàng được tìm thấy
                {
                    // Gọi phương thức cập nhật trạng thái trong DAL bằng mã hàng
                    if (dalHangHoa.UpdateHangHoaStatus(maHang, 0)) // Giả định bạn có phương thức UpdateHangHoaStatus trong DAL
                    {
                        LoadData(); // Tải lại dữ liệu sau khi cập nhật
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi ngừng kinh doanh sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy sản phẩm với tên '{tenHang}'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void InfoProduct_Load(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}
