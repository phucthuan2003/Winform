using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_HoaDonBan : DBConnect
    {
        public DAL_HoaDonBan() { }
        // Phương thức trả về toàn bộ danh sách hóa đơn bán 
        public DataTable LayDanhSachHoaDonBan()
        {
            DataTable dtHDB = new DataTable();
            OpenConnection(); // Mở kết nối
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HoaDonBan", _conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtHDB);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách hóa đơn bán: " + ex.Message);
            }
            finally
            {
                CloseConnection(); // Đảm bảo đóng kết nối
            }
            return dtHDB;
        }

        // Phương thức lấy thông tin hóa đơn (Chi tiết)
        public DTO_HoaDonBan LayThongTinHoaDon(string soHDB)
        {
            DTO_HoaDonBan hoaDon = null;
            string query = "SELECT * FROM HoaDonBan WHERE SoHDB = @SoHDB";

            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@SoHDB", soHDB);

                try
                {
                    OpenConnection(); // Mở kết nối
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            hoaDon = new DTO_HoaDonBan
                            {
                                SoHDB = reader["SoHDB"].ToString(),
                                NgayBan = reader["NgayBan"] != DBNull.Value ? (DateTime)reader["NgayBan"] : default(DateTime),
                                MaNV = reader["MaNV"].ToString(),
                                MaKhach = reader["MaKhach"].ToString(),
                                GiamGia = reader["GiamGia"] != DBNull.Value ? reader.GetDecimal(reader.GetOrdinal("GiamGia")) : 0,
                                TongTien = reader["TongTien"] != DBNull.Value ? reader.GetDecimal(reader.GetOrdinal("TongTien")) : 0

                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy thông tin hóa đơn: " + ex.Message);
                }
                finally
                {
                    CloseConnection(); // Đảm bảo đóng kết nối
                }
            }

            return hoaDon;
        }

        //Phương thức tìm kiếm(Done)
        public DataTable TimKiemHoaDon(string keyword, string month, string year)
        {
            DataTable dt = new DataTable();
            OpenConnection();
            try
            {
                // Xây dựng câu truy vấn động
                string query = "SELECT * FROM HoaDonBan WHERE 1=1";

                // Thêm điều kiện tìm kiếm theo keyword nếu có
                if (!string.IsNullOrEmpty(keyword))
                {
                    query += " AND (SoHDB LIKE @keyword OR MaKhach LIKE @keyword)";
                }

                // Thêm điều kiện tìm kiếm theo tháng nếu có
                if (!string.IsNullOrEmpty(month))
                {
                    query += " AND MONTH(NgayBan) = @month";
                }

                // Thêm điều kiện tìm kiếm theo năm nếu có
                if (!string.IsNullOrEmpty(year))
                {
                    query += " AND YEAR(NgayBan) = @year";
                }

                using (SqlCommand command = new SqlCommand(query, _conn))
                {
                    // Thêm tham số cho keyword nếu có
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    }
                    // Thêm tham số cho month nếu có
                    if (!string.IsNullOrEmpty(month))
                    {
                        command.Parameters.AddWithValue("@month", month);
                    }
                    // Thêm tham số cho year nếu có
                    if (!string.IsNullOrEmpty(year))
                    {
                        command.Parameters.AddWithValue("@year", year);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return dt;
        }

        // Phương thức xóa hóa đơn bán (DONE)
        public bool XoaHoaDonBan(string soHDB)
        {
            try
            {
                OpenConnection(); // Gọi phương thức từ DBConnect
                string query = "DELETE FROM HoaDonBan WHERE SoHDB = @SoHDB";
                SqlCommand command = new SqlCommand(query, _conn);
                command.Parameters.AddWithValue("@SoHDB", soHDB);

                int result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa hóa đơn: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection(); // Đảm bảo kết nối được đóng
            }
        }

        //Phương thức tạo mã hóa đơn bán
        public int LaySoThuTuHoaDonTrongNgay()
        {
            int soThuTu = 1;
            string query = "SELECT COUNT(*) FROM HoaDonBan WHERE CONVERT(DATE, NgayBan) = CONVERT(DATE, GETDATE())";

            SqlCommand cmd = new SqlCommand(query, _conn);
            try
            {
                OpenConnection();
                soThuTu += (int)cmd.ExecuteScalar(); // Lấy số hóa đơn đã tạo trong ngày
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy số thứ tự hóa đơn: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return soThuTu;
        }

        //Phương thức thêm hóa đơn bán
        public void ThemHoaDon(DTO_HoaDonBan hdb)
        {
            string query = "INSERT INTO HoaDonBan(SoHDB, NgayBan, MaNV, MaKhach, GiamGia, TongTien)" +
                             "VALUES (@SoHDB, @NgayBan, @MaNV, @MaKhach, @GiamGia, @TongTien)";
            SqlCommand cmd = new SqlCommand(query, _conn);

            cmd.Parameters.AddWithValue("@SoHDB", hdb.SoHDB);
            cmd.Parameters.AddWithValue("@NgayBan", hdb.NgayBan);
            cmd.Parameters.AddWithValue("@MaNV", hdb.MaNV);
            cmd.Parameters.AddWithValue("@MaKhach", hdb.MaKhach);
            cmd.Parameters.AddWithValue("@GiamGia", hdb.GiamGia);
            cmd.Parameters.AddWithValue("@TongTien", hdb.TongTien);
            try
            {
                OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm hóa đơn: " + ex.Message);
            }
            finally
            {
                CloseConnection(); // Đảm bảo đóng kết nối
            }
        }

        // Phương thức lấy mã hóa đơn gần nhất
        public string LaySoHDBCuoi()
        {
            string soHDBCuoi = string.Empty;
            string query = @"
        SELECT TOP 1 SoHDB 
        FROM HoaDonBan 
        WHERE CONVERT(DATE, NgayBan) = CONVERT(DATE, GETDATE()) 
        ORDER BY NgayBan DESC, SoHDB DESC"; // Lấy mã hóa đơn gần nhất trong ngày hôm nay

            try
            {
                OpenConnection(); // Mở kết nối
                SqlCommand cmd = new SqlCommand(query, _conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    soHDBCuoi = result.ToString(); // Lấy giá trị của SoHDB
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy mã hóa đơn gần nhất: " + ex.Message);
            }
            finally
            {
                CloseConnection(); // Đảm bảo đóng kết nối
            }

            return soHDBCuoi;
        }

        private string ExecuteScalar(string sql, string maHDBan)
        {
            string result = string.Empty;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@SoHDB", maHDBan);
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        result = obj.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin hóa đơn: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
        public DataTable GetTotalRevenue()
        {
            string query = "SELECT SUM(TongTien) AS Bang3 FROM HoaDonBan";
            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                DataTable result = new DataTable();
                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while getting total revenue: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
                return result;
            }
        }
        public DataTable GetTotalDiscount()
        {
            string query = "SELECT SUM(GiamGia) AS Bang3 FROM HoaDonBan";
            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                DataTable result = new DataTable();
                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while getting total discount: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
                return result;
            }
        }
    }

}
