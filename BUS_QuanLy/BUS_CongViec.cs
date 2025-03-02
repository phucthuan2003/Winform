using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;
using DTO_QuanLy;
using System.Data;

namespace BUS_QuanLy
{
    public class BUS_CongViec
    {
        DAL_CongViec dalCongViec = new DAL_CongViec();

        // Lấy danh sách công việc
        public DataTable getCongViec()
        {
            return dalCongViec.getCongViec();
        }

        // Thêm công việc
        public bool themCongViec(DTO_CongViec cv)
        {
            return dalCongViec.themCongViec(cv);
        }

        // Sửa công việc
        public bool suaCongViec(DTO_CongViec cv)
        {
            return dalCongViec.suaCongViec(cv);
        }

        // Xóa công việc
        public bool xoaCongViec(string maCV)
        {
            return dalCongViec.xoaCongViec(maCV);
        }
        // kiem tra tồn tại
        public bool KiemTraCongViecTonTai(string maCV)
        {
            return dalCongViec.KiemTraCongViecTonTai(maCV);
        }

    }
}