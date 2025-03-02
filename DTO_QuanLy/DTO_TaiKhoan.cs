using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_TaiKhoan
    {
        public string MaTK { get; set; } // Mã tài khoản
        public string MaNV { get; set; } // Mã nhân viên
        public string TenDangNhap { get; set; } // Tên đăng nhập
        public string MatKhau { get; set; } // Mật khẩu
        public string QuyenHan { get; set; } // Quyền hạn

        // Constructor
        public DTO_TaiKhoan(string maTK, string maNV, string tenDangNhap, string matKhau, string quyenHan)
        {
            this.MaTK = maTK;
            this.MaNV = maNV;
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
            this.QuyenHan = quyenHan;
        }
    }

}