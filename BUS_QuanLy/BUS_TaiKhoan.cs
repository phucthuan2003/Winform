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
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan dalTaiKhoan = new DAL_TaiKhoan();


        // Lấy danh sách tài khoản
        public DataTable getTaiKhoan()
        {
            return dalTaiKhoan.getTaiKhoan();
        }

        // Thêm tài khoản
        public bool themTaiKhoan(DTO_TaiKhoan tk)
        {
            return dalTaiKhoan.themTaiKhoan(tk);
        }

        // Sửa tài khoản
        public bool suaTaiKhoan(DTO_TaiKhoan tk)
        {
            return dalTaiKhoan.suaTaiKhoan(tk);
        }

        // Xóa tài khoản
        public bool xoaTaiKhoan(string maTK)
        {
            return dalTaiKhoan.xoaTaiKhoan(maTK);
        }

        // Kiểm tra tài khoản tồn tại
        public bool KiemTraTaiKhoanTonTai(string maTK)
        {
            return dalTaiKhoan.KiemTraTaiKhoanTonTai(maTK);
        }

        public bool KiemTraMaNV(string maNV)
        {
            return dalTaiKhoan.KiemTraMaNVTonTai(maNV); // giả sử bạn đã tạo đối tượng DAL để truy cập
        }
        public string VerifyUser(string username, string password)
        {
            // Có thể thêm các logic kiểm tra trước khi gọi DAL
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null; // Tên đăng nhập hoặc mật khẩu không hợp lệ
            }

            // Gọi phương thức DAL để xác thực người dùng
            return dalTaiKhoan.VerifyUser(username, password);
        }

        // Phương thức lấy số lượng nhân viên
        public int GetEmployeeCount()
        {
            DataTable dataTable = dalTaiKhoan.GetEmployeeCount();
            if (dataTable.Rows.Count > 0)
            {
                return int.Parse(dataTable.Rows[0]["Bang1"].ToString());
            }
            return 0;
        }

        // Phương thức lấy danh sách nhân viên theo quyền
        public DataTable GetEmployeeByRole()
        {
            return dalTaiKhoan.GetEmployeeByRole();
        }

        // Phương thức lấy tên nhân viên từ mã nhân viên
        public string GetEmployeeNameByAccount(string maNV)
        {
            return dalTaiKhoan.GetEmployeeNameByAccount(maNV); // Gọi DAL để lấy tên nhân viên
        }
        public string GetEmployeeIdByLogin(string username, string password)
        {
            return dalTaiKhoan.GetEmployeeIdByLogin(username, password);
        }  
    }
}