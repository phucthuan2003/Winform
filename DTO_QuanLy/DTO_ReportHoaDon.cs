using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_ReportHoaDon
    {
        public string LoaiHoaDon { get; set; }  // "Bán" hoặc "Nhập"
        public string SoHD { get; set; }
        public DateTime Ngay { get; set; }
        public string MaDoiTac { get; set; }   // Mã khách hàng hoặc mã nhà cung cấp
        public string TenDoiTac { get; set; }  // Tên khách hàng hoặc tên nhà cung cấp
        public decimal TongTien { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiamGia { get; set; }
    }
}
