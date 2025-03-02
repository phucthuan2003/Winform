using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_HoaDonBan
    {
        private string _SoHDB;
        private string _MaNV;
        private string _MaKhach;
        private DateTime _NgayBan;
        private decimal _TongTien;
        private decimal _GiamGia;

        public string SoHDB { get; set; }
        public string MaNV { get; set; }
        public string MaKhach { get; set; }
        public DateTime NgayBan { get; set; }
        public decimal TongTien { get; set; }
        public decimal GiamGia { get; set; }

        public DTO_HoaDonBan() { }

        public DTO_HoaDonBan(string soHDB, string maNV, string maKH, DateTime ngayBan, decimal tongTien, decimal giamGia)
        {
            this.SoHDB = soHDB;
            this.MaNV = maNV;
            this.MaKhach = maKH;
            this.NgayBan = ngayBan;
            this.TongTien = tongTien;
            this.GiamGia = giamGia;
        }
    }
}