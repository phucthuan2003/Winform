using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_NhaCungCap
    {
        private string _MaNCC;
        private string _TenNCC;
        private string _DiaChi;
        private string _DienThoai;

        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public DTO_NhaCungCap() { }

        public DTO_NhaCungCap(string maNCC, string tenNCC, string diaChi, string dienThoai)
        {
            this.MaNCC = maNCC;
            this.TenNCC = tenNCC;
            this.DiaChi = diaChi;
            this.DienThoai = dienThoai;
        }
    }
}
