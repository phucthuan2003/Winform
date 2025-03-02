using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_HinhKhoi
    {
        private string _MaHinhKhoi;
        private string _TenHinhKhoi;

        public string MaHinhKhoi
        {
            get { return _MaHinhKhoi; }
            set { _MaHinhKhoi = value; }
        }

        public string TenHinhKhoi
        {
            get { return _TenHinhKhoi; }
            set { _TenHinhKhoi = value; }
        }

        public DTO_HinhKhoi() { }

        public DTO_HinhKhoi(string maHinhKhoi, string tenHinhKhoi)
        {
            this.MaHinhKhoi = maHinhKhoi;
            this.TenHinhKhoi = tenHinhKhoi;
        }
    }

}
