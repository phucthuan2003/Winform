using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_ReportHD
    {
        public string MaSanPham { get; set; }  // Mã sản phẩm
        public string TenSanPham { get; set; }  // Tên sản phẩm
        public string MaKhachHang { get; set; }  // Mã khách hàng
        public string TenKhachHang { get; set; }  // Tên khách hàng
        public int SoLuong { get; set; }  // Số lượng sản phẩm mua
        public decimal DonGia { get; set; }  // Đơn giá bán của mỗi sản phẩm
        public decimal DoanhThu { get; set; }  // Doanh thu của mỗi sản phẩm
        public DateTime NgayBan { get; set; }  // Ngày lập hóa đơn
        public string NhanVienLapHoaDon { get; set; }  // Tên nhân viên lập hóa đơn
    }
}
