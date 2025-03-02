using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLy
{
    public class DAL_ChiTietHoaDonBan : DBConnect
    {
        // Lấy tổng số lượng sản phẩm đã bán
        public DataTable GetTotalSoldQuantity()
        {
            string query = "SELECT SUM(SoLuong) AS Bang3 FROM ChiTietHoaDonBan";
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
                    throw new Exception("An error occurred while getting total sold quantity: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
                return result;
            }
        }
        public DataTable GetTotalCustomerCount()
        {
            string query = "SELECT COUNT(MaKhach) AS Bang4 FROM HoaDonBan";
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
                    throw new Exception("An error occurred while getting customer count: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
                return result;
            }
        }
        // Phương thức xóa chi tiết hóa đơn theo SoHDB (DONE)
        public bool XoaChiTietHoaDonTheoSoHDB(string soHDB)
        {
            try
            {
                OpenConnection(); // Mở kết nối từ DBConnect

                string query = "DELETE FROM ChiTietHoaDonBan WHERE SoHDB = @SoHDB";
                SqlCommand command = new SqlCommand(query, _conn);
                command.Parameters.AddWithValue("@SoHDB", soHDB);

                int result = command.ExecuteNonQuery(); // Thực hiện lệnh xóa
                return result > 0; // Trả về true nếu có ít nhất một dòng được xóa
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chi tiết hóa đơn: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection(); // Đóng kết nối từ DBConnect
            }
        }

        //Phương thức lấy thông tin chi tiết hóa đơn (done)
        public List<DTO_ChiTietHoaDonBan> LayChiTietHoaDon(string soHDB)
        {
            List<DTO_ChiTietHoaDonBan> chiTietList = new List<DTO_ChiTietHoaDonBan>();
            string query = @"
        SELECT c.MaHang, h.TenHang, c.SoLuong, c.GiamGia, c.DonGiaBan, c.ThanhTien
        FROM ChiTietHoaDonBan c
        JOIN HangHoa h ON c.MaHang = h.MaHang
        WHERE c.SoHDB = @SoHDB";

            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@SoHDB", soHDB);

                try
                {
                    OpenConnection();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_ChiTietHoaDonBan chiTiet = new DTO_ChiTietHoaDonBan
                            {
                                MaHang = reader["MaHang"].ToString(),
                                TenHang = reader["TenHang"].ToString(),
                                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                GiamGia = Convert.ToDecimal(reader["GiamGia"]),
                                DonGiaBan = Convert.ToDecimal(reader["DonGiaBan"]),
                                ThanhTien = Convert.ToDecimal(reader["ThanhTien"])
                            };
                            chiTietList.Add(chiTiet);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy chi tiết hóa đơn: " + ex.Message);
                }
                finally
                {
                    CloseConnection();
                }
            }

            return chiTietList;
        }

        public List<DTO_ChiTietHoaDonBan> RP_LayChiTietHoaDon(string soHDB)
        {
            List<DTO_ChiTietHoaDonBan> chiTietList = new List<DTO_ChiTietHoaDonBan>();
            string query = @"
        SELECT c.SoHDB, c.MaHang, h.TenHang, c.SoLuong, c.GiamGia, c.DonGiaBan, c.ThanhTien, hdb.MaNV, hdb.NgayBan
        FROM ChiTietHoaDonBan c
        JOIN HangHoa h ON c.MaHang = h.MaHang
        JOIN HoaDonBan hdb ON c.SoHDB = hdb.SoHDB
        WHERE c.SoHDB = @SoHDB";

            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@SoHDB", soHDB);

                try
                {
                    OpenConnection();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_ChiTietHoaDonBan chiTiet = new DTO_ChiTietHoaDonBan
                            {
                                SoHDB = reader["SoHDB"].ToString(),
                                MaHang = reader["MaHang"].ToString(),
                                TenHang = reader["TenHang"].ToString(),
                                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                GiamGia = Convert.ToDecimal(reader["GiamGia"]),
                                DonGiaBan = Convert.ToDecimal(reader["DonGiaBan"]),
                                ThanhTien = Convert.ToDecimal(reader["ThanhTien"]),
                                MaNV = reader["MaNV"].ToString(),
                                NgayBan = Convert.ToDateTime(reader["NgayBan"])
                            };
                            chiTietList.Add(chiTiet);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy chi tiết hóa đơn: " + ex.Message);
                }
                finally
                {
                    CloseConnection();
                }
            }

            return chiTietList;
        }

        //Phương thức thêm mới chi tiết hóa đơn bán
        public void ThemChiTietHoaDon(DTO_ChiTietHoaDonBan chiTietHoaDon)
        {
            string query = "INSERT INTO ChiTietHoaDonBan (SoHDB, MaHang, SoLuong, DonGiaBan, GiamGia, ThanhTien) " +
               "VALUES (@SoHDB, @MaHang, @SoLuong, @DonGiaBan, @GiamGia, @ThanhTien)";
            SqlCommand cmd = new SqlCommand(query, _conn);

            cmd.Parameters.AddWithValue("@SoHDB", chiTietHoaDon.SoHDB);
            cmd.Parameters.AddWithValue("@MaHang", chiTietHoaDon.MaHang);
            cmd.Parameters.AddWithValue("@SoLuong", chiTietHoaDon.SoLuong);
            cmd.Parameters.AddWithValue("@DonGiaBan", chiTietHoaDon.DonGiaBan);
            cmd.Parameters.AddWithValue("@GiamGia", chiTietHoaDon.GiamGia);
            cmd.Parameters.AddWithValue("@ThanhTien", chiTietHoaDon.ThanhTien);
            try
            {
                OpenConnection(); // Mở kết nối từ DBConnect
                int result = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
            }
            finally
            {
                CloseConnection(); // Đảm bảo đóng kết nối
            }
        }


    }
}
