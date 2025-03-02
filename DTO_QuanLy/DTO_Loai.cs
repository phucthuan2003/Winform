using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_Loai
    {
        private string _MaLoai;
        private string _TenLoai;

        /* ======== GETTER/SETTER ======== */
        public string MaKichThuoc
        {
            get { return _MaLoai; }
            set { _MaLoai = value; }
        }

        public string TenKichThuoc
        {
            get { return _TenLoai; }
            set { _TenLoai = value; }
        }

        /* === Constructor === */
        public DTO_Loai()
        {
            // Constructor không tham số
        }

        public DTO_Loai(string maLoai, string tenLoai)
        {
            this._MaLoai = maLoai;
            this._MaLoai = maLoai;
        }
    }

}
