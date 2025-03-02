using DTO_QuanLy;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_SalesData : DBConnect
    {
        public (decimal DoanhThu, int SoSanPham) GetSalesDataForPeriod(DateTime startDate, DateTime endDate)
        {
            decimal doanhThu = 0;
            int soSanPham = 0;

            try
            {
                OpenConnection();

                string query = @"
                    SELECT 
                        SUM(ct.SoLuong * ct.DonGiaBan * 0.01*(100 - ISNULL(ct.GiamGia, 0))) AS TotalSales,   -- Tính doanh thu có giảm giá
                        SUM(ct.SoLuong) AS TotalProducts  
                    FROM HoaDonBan hb
                    JOIN ChiTietHoaDonBan ct ON hb.SoHDB = ct.SoHDB
                    WHERE hb.NgayBan BETWEEN @StartDate AND @EndDate";

                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            doanhThu = reader["TotalSales"] != DBNull.Value ? Convert.ToDecimal(reader["TotalSales"]) : 0;
                            soSanPham = reader["TotalProducts"] != DBNull.Value ? Convert.ToInt32(reader["TotalProducts"]) : 0;
                        }
                    }
                }
            }
            finally
            {
                CloseConnection();
            }

            return (doanhThu, soSanPham);
        }

        public List<DTO_Product> GetProductSalesDataForPeriod(DateTime startDate, DateTime endDate)
        {
            List<DTO_Product> productList = new List<DTO_Product>();

            try
            {
                OpenConnection();

                string query = @"
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY SUM(ct.SoLuong) DESC) AS Rank,
                        hh.TenHang AS ProductInfo,
                        SUM(ct.SoLuong * ct.DonGiaBan * 0.01*(100 - ISNULL(ct.GiamGia, 0))) AS Revenue,
                        SUM(ct.SoLuong) AS Quantity
                    FROM ChiTietHoaDonBan ct
                    JOIN HoaDonBan hb ON ct.SoHDB = hb.SoHDB
                    JOIN HangHoa hh ON ct.MaHang = hh.MaHang
                    WHERE hb.NgayBan BETWEEN @StartDate AND @EndDate
                    GROUP BY hh.TenHang
                    ORDER BY SUM(ct.SoLuong) DESC";

                using (SqlCommand command = new SqlCommand(query, _conn))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new DTO_Product
                            {
                                Rank = reader.IsDBNull(0) ? 0 : (int)reader.GetInt64(0),
                                ProductInfo = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                Revenue = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2),
                                Quantity = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
                            };
                            productList.Add(product);
                        }
                    }
                }
            }
            finally
            {
                CloseConnection();
            }

            return productList;
        }

        public List<(string WeekLabel, decimal DoanhThu, int SoSanPham)> GetSalesDataGroupedByWeek(DateTime startDate, DateTime endDate)
        {
            List<(string WeekLabel, decimal DoanhThu, int SoSanPham)> salesDataList = new List<(string WeekLabel, decimal DoanhThu, int SoSanPham)>();

            try
            {
                OpenConnection();

                string query = @"
                SELECT 
                    DATENAME(WEEK, hb.NgayBan) + '-' + DATENAME(YEAR, hb.NgayBan) AS WeekLabel,
                    SUM(hb.TongTien) AS DoanhThu,
                    SUM(ct.SoLuong) AS SoSanPham
                FROM HoaDonBan hb
                JOIN ChiTietHoaDonBan ct ON hb.SoHDB = ct.SoHDB
                WHERE hb.NgayBan BETWEEN @StartDate AND @EndDate
                GROUP BY DATENAME(WEEK, hb.NgayBan), DATENAME(YEAR, hb.NgayBan)
                ORDER BY DATENAME(YEAR, hb.NgayBan), DATENAME(WEEK, hb.NgayBan)";

                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string weekLabel = reader["WeekLabel"].ToString();
                            decimal doanhThu = reader["DoanhThu"] != DBNull.Value ? Convert.ToDecimal(reader["DoanhThu"]) : 0;
                            int soSanPham = reader["SoSanPham"] != DBNull.Value ? Convert.ToInt32(reader["SoSanPham"]) : 0;

                            salesDataList.Add((weekLabel, doanhThu, soSanPham));
                        }
                    }
                }
            }
            finally
            {
                CloseConnection();
            }

            return salesDataList;
        }
        // Lấy số lượng nhân viên hiện có trong hệ thống (dựa vào ngày vào làm)
        public int GetEmployeeCountForPeriod(DateTime startDate, DateTime endDate)
        {
            int employeeCount = 0;

            try
            {
                OpenConnection();

                string query = @"
                    SELECT COUNT(DISTINCT MaNV) AS EmployeeCount
                    FROM NhanVien
                    WHERE NgayVaoLam <= @EndDate";

                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employeeCount = reader["EmployeeCount"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeCount"]) : 0;
                        }
                    }
                }
            }
            finally
            {
                CloseConnection();
            }

            return employeeCount;
        }


        // Lấy số lượng đơn hàng trong khoảng thời gian
        public int GetOrderCountForPeriod(DateTime startDate, DateTime endDate)
        {
            int orderCount = 0;

            try
            {
                OpenConnection();

                string query = @"
                SELECT COUNT(DISTINCT SoHD) AS OrderCount
                FROM (
                    SELECT SoHDB AS SoHD, NgayBan AS Ngay FROM HoaDonBan
                    WHERE NgayBan BETWEEN @StartDate AND @EndDate
                    UNION ALL
                    SELECT SoHDN AS SoHD, NgayNhap AS Ngay FROM HoaDonNhap
                    WHERE NgayNhap BETWEEN @StartDate AND @EndDate
                ) AS CombinedOrders";

                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            orderCount = reader["OrderCount"] != DBNull.Value ? Convert.ToInt32(reader["OrderCount"]) : 0;
                        }
                    }
                }
            }
            finally
            {
                CloseConnection();
            }

            return orderCount;
        }

        // Lấy dữ liệu tổng quan về doanh thu, số lượng sản phẩm tồn kho, đơn hàng, nhân viên
        public (decimal DoanhThu, int SoSanPhamTonKho, int SoDonHang, int SoNhanVien) GetTotalSalesData()
        {
            decimal doanhThu = 0;
            int soSanPhamTonKho = 0;
            int soDonHang = 0;
            int soNhanVien = 0;

            try
            {
                OpenConnection();

                string query = @"
                SELECT 
                    SUM(ct.SoLuong * ct.DonGiaBan * 0.01*(100 - ISNULL(ct.GiamGia, 0))) AS TotalSales,
                    (SELECT SUM(ctn.SoLuong) FROM ChiTietHoaDonNhap ctn) - 
                    (SELECT SUM(ct.SoLuong) FROM ChiTietHoaDonBan ct) AS TotalProductsInStock,
                    (SELECT COUNT(DISTINCT SoHDB) FROM HoaDonBan) + 
                    (SELECT COUNT(DISTINCT SoHDN) FROM HoaDonNhap) AS TotalOrders,
                    (SELECT COUNT(DISTINCT MaNV) FROM NhanVien) AS TotalEmployees
                FROM ChiTietHoaDonBan ct";

                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            doanhThu = reader["TotalSales"] != DBNull.Value ? Convert.ToDecimal(reader["TotalSales"]) : 0;
                            soSanPhamTonKho = reader["TotalProductsInStock"] != DBNull.Value ? Convert.ToInt32(reader["TotalProductsInStock"]) : 0;
                            soDonHang = reader["TotalOrders"] != DBNull.Value ? Convert.ToInt32(reader["TotalOrders"]) : 0;
                            soNhanVien = reader["TotalEmployees"] != DBNull.Value ? Convert.ToInt32(reader["TotalEmployees"]) : 0;
                        }
                    }
                }
            }
            finally
            {
                CloseConnection();
            }

            return (doanhThu, soSanPhamTonKho, soDonHang, soNhanVien);
        }
    }
}
