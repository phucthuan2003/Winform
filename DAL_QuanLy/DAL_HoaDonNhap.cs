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
    public class DAL_HoaDonNhap : DBConnect
    {
        public DAL_HoaDonNhap() { }

        // Phương thức trả về toàn bộ danh sách hóa đơn nhập - 1
        public DataTable LayDanhSachHoaDonNhap()
        {
            DataTable dtHDN = new DataTable();
            OpenConnection(); // Mở kết nối
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HoaDonNhap", _conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtHDN);
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
            return dtHDN;
        }

        // Phương thức lấy thông tin hóa đơn (Chi tiết)
        public DTO_HoaDonNhap LayThongTinHoaDon(string soHDN)
        {
            DTO_HoaDonNhap hoaDon = null;
            string query = "SELECT * FROM HoaDonNhap WHERE SoHDN = @SoHDN";

            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@SoHDN", soHDN);

                try
                {
                    OpenConnection(); // Mở kết nối
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            hoaDon = new DTO_HoaDonNhap
                            {
                                SoHDN = reader["SoHDN"].ToString(),
                                NgayNhap = reader["NgayNhap"] != DBNull.Value ? (DateTime)reader["NgayNhap"] : default(DateTime),
                                MaNV = reader["MaNV"].ToString(),
                                MaNCC = reader["MaNCC"].ToString(),
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
                string query = "SELECT * FROM HoaDonNhap WHERE 1=1";

                // Thêm điều kiện tìm kiếm theo keyword nếu có
                if (!string.IsNullOrEmpty(keyword))
                {
                    query += " AND (SoHDN LIKE @keyword OR MaNCC LIKE @keyword)";
                }

                // Thêm điều kiện tìm kiếm theo tháng nếu có
                if (!string.IsNullOrEmpty(month))
                {
                    query += " AND MONTH(NgayNhap) = @month";
                }

                // Thêm điều kiện tìm kiếm theo năm nếu có
                if (!string.IsNullOrEmpty(year))
                {
                    query += " AND YEAR(NgayNhap) = @year";
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

        // Phương thức xóa hóa đơn nhập 
        public bool XoaHoaDonBan(string soHDN)
        {
            try
            {
                OpenConnection();
                string query = "DELETE FROM HoaDonNhap WHERE SoHDN = @SoHDN";
                SqlCommand command = new SqlCommand(query, _conn);
                command.Parameters.AddWithValue("@SoHDN", soHDN);

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

        //Phương thức tạo mã hóa đơn 
        public int LaySoThuTuHoaDonTrongNgay()
        {
            int soThuTu = 1;
            string query = "SELECT COUNT(*) FROM HoaDonNhap WHERE CONVERT(DATE, NgayNhap) = CONVERT(DATE, GETDATE())";

            SqlCommand cmd = new SqlCommand(query, _conn);
            try
            {
                OpenConnection();
                soThuTu += (int)cmd.ExecuteScalar();
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

        //Phương thức thêm hóa đơn 
        public bool ThemHoaDon(DTO_HoaDonNhap hdn)
        {
            string query = "INSERT INTO HoaDonNhap(SoHDN, NgayNhap, MaNV, MaNCC, TongTien) " +
                           "VALUES (@SoHDN, @NgayNhap, @MaNV, @MaNCC, @TongTien)";

            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@SoHDN", hdn.SoHDN);
                cmd.Parameters.AddWithValue("@NgayNhap", hdn.NgayNhap);
                cmd.Parameters.AddWithValue("@MaNV", hdn.MaNV);
                cmd.Parameters.AddWithValue("@MaNCC", hdn.MaNCC);
                cmd.Parameters.AddWithValue("@TongTien", hdn.TongTien);

                try
                {
                    OpenConnection();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0; // Trả về true nếu có ít nhất một dòng được thêm
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi thêm hóa đơn: " + ex.Message);
                    return false; // Trả về false nếu có lỗi xảy ra
                }
                finally
                {
                    CloseConnection(); // Đảm bảo đóng kết nối
                }
            }
        }


        public string LaySoHDNCuoi()
        {
            string soHDNCuoi = string.Empty;
            string query = @"
                SELECT TOP 1 SoHDN 
                FROM HoaDonNhap 
                WHERE CONVERT(DATE, NgayNhap) = CONVERT(DATE, GETDATE()) 
                ORDER BY NgayNhap DESC, SoHDN DESC";

            try
            {
                OpenConnection(); // Mở kết nối
                SqlCommand cmd = new SqlCommand(query, _conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    soHDNCuoi = result.ToString(); // Lấy giá trị của SoHDN
                }
                else
                {
                    Console.WriteLine("Không có hóa đơn nào trong ngày hôm nay.");
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

            return soHDNCuoi;
        }


        private string ExecuteScalar(string sql, string maHDN)
        {
            string result = string.Empty;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@SoHDN", maHDN);
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
    }

}
