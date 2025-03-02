using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_HoaVan
    {
        private string _MaHoaVan;
        private string _TenHoaVan;

        public string MaHoaVan
        {
            get { return _MaHoaVan; }
            set { _MaHoaVan = value; }
        }

        public string TenHoaVan
        {
            get { return _TenHoaVan; }
            set { _TenHoaVan = value; }
        }

        public DTO_HoaVan() { }

        public DTO_HoaVan(string maHoaVan, string tenHoaVan)
        {
            this.MaHoaVan = maHoaVan;
            this.TenHoaVan = tenHoaVan;
        }
    }
}
