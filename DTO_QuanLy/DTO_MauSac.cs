using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_MauSac
    {
        private string _MaMau;
        private string _TenMau;

        public string MaMau
        {
            get { return _MaMau; }
            set { _MaMau = value; }
        }

        public string TenMau
        {
            get { return _TenMau; }
            set { _TenMau = value; }
        }

        public DTO_MauSac() { }

        public DTO_MauSac(string maMau, string tenMau)
        {
            this.MaMau = maMau;
            this.TenMau = tenMau;
        }
    }

}
