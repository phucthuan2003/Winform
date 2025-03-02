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
    public class BUS_NhanVien
    {
        DAL_NhanVien dalNhanVien = new DAL_NhanVien();
        private DAL_NhanVien dalNV = new DAL_NhanVien();

        // Phương thức lấy tên nhân viên từ mã nhân viên
        public string LayTenNhanVien(string maNV)
        {
            return dalNV.LayTenNhanVien(maNV);
        }

        // Lấy danh sách nhân viên
        public DataTable getNhanVien()
        {
            return dalNhanVien.getNhanVien();
        }

        // Thêm nhân viên
        public bool themNhanVien(DTO_NhanVien nv)
        {
            return dalNhanVien.themNhanVien(nv);
        }

        public bool CapNhatNhanVien(DTO_NhanVien nv)
        {
            return dalNhanVien.CapNhatNhanVien(nv);
        }
        public bool xoaNhanVien(string maNV)
        {
            return dalNhanVien.xoaNhanVien(maNV);
        }

        // Lấy vai trò từ mã công việc
        public string GetVaiTroByMaCV(string maCV)
        {
            return dalNhanVien.GetVaiTroByMaCV(maCV);
        }

        public bool KiemTraMaNV(string maNV)
        {
            return dalNhanVien.KiemTraMaNV(maNV); // giả sử bạn đã tạo đối tượng DAL để truy cập
        }

        public bool KiemTraMaCV(string maCV)
        {
            return dalNhanVien.KiemTraMaCV(maCV); // giả sử bạn đã tạo đối tượng DAL để truy cập
        }

        public DataTable TimKiemNV(string searchTerm, string searchField)
        {
            return dalNhanVien.TimKiemNV(searchTerm, searchField);
        }
    }
}