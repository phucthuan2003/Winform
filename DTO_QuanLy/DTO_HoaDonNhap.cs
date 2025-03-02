using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_HoaDonNhap
    {
        private string _SoHDN;
        private string _MaNCC;
        private string _MaNV;
        private DateTime _NgayNhap;
        private decimal _TongTien;

        public string SoHDN { get; set; }
        public string MaNCC { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }

        public DTO_HoaDonNhap() { }

        public DTO_HoaDonNhap(string maHDN, string maNCC, string maNV, DateTime ngayNhap, decimal tongTien)
        {
            this.SoHDN = maHDN;
            this._MaNV = maNV;
            this.MaNCC = maNCC;
            this.NgayNhap = ngayNhap;
            this.TongTien = tongTien;
        }
    }

}
