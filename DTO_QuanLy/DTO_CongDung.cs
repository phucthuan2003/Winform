using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_CongDung
    {
        private string _MaCongDung;
        private string _TenCongDung;

        /* ======== GETTER/SETTER ======== */
        public string MaCongDung
        {
            get { return _MaCongDung; }
            set { _MaCongDung = value; }
        }

        public string TenCongDung
        {
            get { return _TenCongDung; }
            set { _TenCongDung = value; }
        }

        /* === Constructor === */
        public DTO_CongDung()
        {
            // Constructor không tham số
        }

        public DTO_CongDung(string maCongDung, string tenCongDung)
        {
            this.MaCongDung = maCongDung;
            this.TenCongDung = tenCongDung;
        }
    }

}
