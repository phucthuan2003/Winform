using DTO_QuanLy;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  // Add this line to access MessageBox

namespace DAL_QuanLy
{
    public class DAL_ReportHoaDon:DBConnect
    {
        //private string connectionString = "Data Source=LAPTOP-L4E28I51\\SQLEXPRESS;Initial Catalog=BTL_TQ3;Integrated Security=True;TrustServerCertificate=True";

        // Phương thức lấy dữ liệu gộp Hóa đơn bán và Hóa đơn nhập, bao gồm Tên đối tác
        public List<DTO_ReportHoaDon> GetHoaDonGopData(DateTime startDate, DateTime endDate)
        {
            List<DTO_ReportHoaDon> hoaDonGopList = new List<DTO_ReportHoaDon>();

            // Mở kết nối kế thừa từ DBConnect
            OpenConnection();

            string query = @"
                SELECT 'Bán' AS LoaiHoaDon, hb.SoHDB AS SoHD, hb.NgayBan AS Ngay, hb.MaKhach AS MaDoiTac, 
                       kh.TenKhach AS TenDoiTac, hh.TenHang, 
                       SUM(ct.SoLuong * ct.DonGiaBan * 0.01 * (100 - ISNULL(ct.GiamGia, 0))) AS TongTien, 
                       ct.MaHang, ct.SoLuong, ct.DonGiaBan AS DonGia, ct.GiamGia
                FROM HoaDonBan hb
                JOIN ChiTietHoaDonBan ct ON hb.SoHDB = ct.SoHDB
                JOIN KhachHang kh ON hb.MaKhach = kh.MaKhach
                JOIN HangHoa hh ON ct.MaHang = hh.MaHang
                WHERE hb.NgayBan BETWEEN @StartDate AND @EndDate
                GROUP BY hb.SoHDB, hb.NgayBan, hb.MaKhach, kh.TenKhach, hh.TenHang, ct.MaHang, ct.SoLuong, ct.DonGiaBan, ct.GiamGia
                UNION ALL
                SELECT N'Nhập' AS LoaiHoaDon, hn.SoHDN AS SoHD, hn.NgayNhap AS Ngay, hn.MaNCC AS MaDoiTac, 
                       ncc.TenNCC AS TenDoiTac, hh.TenHang, 
                       SUM(ct.SoLuong * ct.DonGia) AS TongTien, 
                       ct.MaHang, ct.SoLuong, ct.DonGia AS DonGia, NULL AS GiamGia
                FROM HoaDonNhap hn
                JOIN ChiTietHoaDonNhap ct ON hn.SoHDN = ct.SoHDN
                JOIN NhaCungCap ncc ON hn.MaNCC = ncc.MaNCC
                JOIN HangHoa hh ON ct.MaHang = hh.MaHang
                WHERE hn.NgayNhap BETWEEN @StartDate AND @EndDate
                GROUP BY hn.SoHDN, hn.NgayNhap, hn.MaNCC, ncc.TenNCC, hh.TenHang, ct.MaHang, ct.SoLuong, ct.DonGia"
            ;

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var hoaDonGop = new DTO_ReportHoaDon
                            {
                                LoaiHoaDon = reader["LoaiHoaDon"].ToString(),
                                SoHD = reader["SoHD"].ToString(),
                                Ngay = Convert.ToDateTime(reader["Ngay"]),
                                MaDoiTac = reader["MaDoiTac"].ToString(),
                                TenDoiTac = reader["TenDoiTac"].ToString(),
                                TenHang = reader["TenHang"].ToString(),
                                TongTien = Convert.ToDecimal(reader["TongTien"]),
                                MaHang = reader["MaHang"].ToString(),
                                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                DonGia = Convert.ToDecimal(reader["DonGia"]),
                                GiamGia = reader["GiamGia"] != DBNull.Value ? Convert.ToDecimal(reader["GiamGia"]) : 0
                            };

                            hoaDonGopList.Add(hoaDonGop);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log hoặc thông báo lỗi nếu có
                Console.WriteLine("Lỗi khi lấy thông tin hóa đơn: " + ex.Message);
            }
            finally
            {
                CloseConnection(); // Đảm bảo luôn đóng kết nối
            }

            return hoaDonGopList;
        }
        // Phương thức chuyển đổi danh sách hóa đơn thành DataTable
        public DataTable ConvertHoaDonListToDataTable(List<DTO_ReportHoaDon> list)
        {
            var table = new DataTable();

            // Thêm các cột vào DataTable, đặt Tên Hàng ngay sau Mã Hàng
            table.Columns.Add("LoaiHoaDon", typeof(string));
            table.Columns.Add("SoHD", typeof(string));
            table.Columns.Add("Ngay", typeof(DateTime));
            table.Columns.Add("MaDoiTac", typeof(string));
            table.Columns.Add("TenDoiTac", typeof(string));
            table.Columns.Add("MaHang", typeof(string));   // Mã Hàng trước
            table.Columns.Add("TenHang", typeof(string));  // Tên Hàng ngay sau Mã Hàng
            table.Columns.Add("SoLuong", typeof(int));
            table.Columns.Add("DonGia", typeof(decimal));
            table.Columns.Add("GiamGia", typeof(decimal));
            table.Columns.Add("TongTien", typeof(decimal));

            // Thêm dữ liệu từ danh sách vào DataTable
            foreach (var item in list)
            {
                table.Rows.Add(
                    item.LoaiHoaDon,
                    item.SoHD,
                    item.Ngay,
                    item.MaDoiTac,
                    item.TenDoiTac,
                    item.MaHang,     // Mã Hàng
                    item.TenHang,    // Tên Hàng ngay sau Mã Hàng
                    item.SoLuong,
                    item.DonGia,
                    item.GiamGia,
                    item.TongTien
                );
            }

            return table;
        }
    }
}
