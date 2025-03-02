using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_ReportSanPham
    {
        public string IDSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuongBan { get; set; }
        public int SoLuongConLai { get; set; }
    }
}
