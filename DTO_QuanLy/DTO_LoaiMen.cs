using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_LoaiMen
    {
        private string _MaLoaiMen;
        private string _TenLoaiMen;

        public string MaLoaiMen
        {
            get { return _MaLoaiMen; }
            set { _MaLoaiMen = value; }
        }

        public string TenLoaiMen
        {
            get { return _TenLoaiMen; }
            set { _TenLoaiMen = value; }
        }

        public DTO_LoaiMen() { }

        public DTO_LoaiMen(string maLoaiMen, string tenLoaiMen)
        {
            this.MaLoaiMen = maLoaiMen;
            this.TenLoaiMen = tenLoaiMen;
        }
    }

}
