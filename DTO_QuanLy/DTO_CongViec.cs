using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_CongViec
    {
        private string _MaCV;
        private string _TenCV;
        private decimal? _MucLuong;

        public string MaCV
        {
            get { return _MaCV; }
            set { _MaCV = value; }
        }

        public string TenCV
        {
            get { return _TenCV; }
            set { _TenCV = value; }
        }

        public decimal? MucLuong
        {
            get { return _MucLuong; }
            set { _MucLuong = value; }
        }

        public DTO_CongViec() { }

        public DTO_CongViec(string maCV, string tenCV, decimal? mucLuong)
        {
            this.MaCV = maCV;
            this.TenCV = tenCV;
            this.MucLuong = mucLuong;
        }
    }
}
