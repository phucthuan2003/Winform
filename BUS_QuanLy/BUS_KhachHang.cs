using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dalKhachHang = new DAL_KhachHang();
        DAL_KhachHang dalKH = new DAL_KhachHang();

        //Phương thức lấy thông tin khách hàng
        public DTO_KhachHang LayThongTinKhachHang(string maKH)
        {
            return dalKH.LayThongTinKhachHang(maKH);
        }

        public List<DTO_KhachHang> LayDanhSachKhachHang()
        {
            return dalKH.LayDanhSachKhachHang();
        }
        public DTO_KhachHang ThongTinKhachHangTheoSoHoaDon(string soHoaDon)
        {
            return dalKH.ThongTinKhachHangTheoSoHoaDon(soHoaDon);
        }
        public DTO_KhachHang TimKiemKhachHangTheoSDT(string sdt)
        {
            return dalKH.TimKiemKhachHangTheoSDT(sdt);
        }
        public string SinhMaKhachHangTuDong()
        {
            return dalKH.SinhMaKhachHangTuDong();
        }
        // Lấy danh sách khách hàng
        public DataTable getKhachHang()
        {
            return dalKhachHang.getKhachHang();
        }

        // Thêm khách hàng
        public bool themKhachHang(DTO_KhachHang kh)
        {
            return dalKhachHang.themKhachHang(kh);
        }

        // Sửa khách hàng
        public bool suaKhachHang(DTO_KhachHang kh)
        {
            return dalKhachHang.suaKhachHang(kh);
        }

        // Xóa khách hàng
        public bool xoaKhachHang(string maKhach)
        {
            return dalKhachHang.xoaKhachHang(maKhach);
        }

        // Kiểm tra khách hàng tồn tại
        public bool KiemTraKhachHangTonTai(string maKhach)
        {
            return dalKhachHang.KiemTraKhachHangTonTai(maKhach);
        }

        public DataTable TimKiemKhachHang(string searchTerm, string searchField)
        {
            return dalKhachHang.TimKiemKhachHang(searchTerm, searchField);
        }
    }
}