using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_KichThuoc
    {
        private string _MaKichThuoc;
        private string _TenKichThuoc;

        /* ======== GETTER/SETTER ======== */
        public string MaKichThuoc
        {
            get { return _MaKichThuoc; }
            set { _MaKichThuoc = value; }
        }

        public string TenKichThuoc
        {
            get { return _TenKichThuoc; }
            set { _TenKichThuoc = value; }
        }

        /* === Constructor === */
        public DTO_KichThuoc()
        {
            // Constructor không tham số
        }

        public DTO_KichThuoc(string maKichThuoc, string tenKichThuoc)
        {
            this.MaKichThuoc = maKichThuoc;
            this.TenKichThuoc = tenKichThuoc;
        }
    }

}
