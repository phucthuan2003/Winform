using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_NuocSanXuat
    {
        private string _MaNuocSX;
        private string _TenNuocSX;

        public string MaNuocSX
        {
            get { return _MaNuocSX; }
            set { _MaNuocSX = value; }
        }

        public string TenNuocSX
        {
            get { return _TenNuocSX; }
            set { _TenNuocSX = value; }
        }

        public DTO_NuocSanXuat() { }

        public DTO_NuocSanXuat(string maNuocSX, string tenNuocSX)
        {
            this.MaNuocSX = maNuocSX;
            this.TenNuocSX = tenNuocSX;
        }
    }

}
