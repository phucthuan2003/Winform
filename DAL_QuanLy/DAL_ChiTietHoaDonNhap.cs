using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_ChiTietHoaDonNhap : DBConnect
    {
        // Phương thức xóa chi tiết hóa đơn theo SoHDN
        public bool XoaChiTietHoaDonTheoSoHDN(string soHDN)
        {
            try
            {
                OpenConnection();

                string query = "DELETE FROM ChiTietHoaDonNhap WHERE SoHDN = @SoHDN";
                SqlCommand command = new SqlCommand(query, _conn);
                command.Parameters.AddWithValue("@SoHDN", soHDN);

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
        public List<DTO_ChiTietHoaDonNhap> LayChiTietHoaDon(string soHDN)
        {
            List<DTO_ChiTietHoaDonNhap> chiTietList = new List<DTO_ChiTietHoaDonNhap>();
            string query = "SELECT c.MaHang, h.TenHang, c.SoLuong, c.DonGia, c.ThanhTien " + // Thêm dấu cách sau 'ThanhTien'
                           "FROM ChiTietHoaDonNhap c " +
                           "JOIN HangHoa h ON c.MaHang = h.MaHang " +
                           "WHERE c.SoHDN = @SoHDN";


            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@SoHDN", soHDN);

                try
                {
                    OpenConnection(); // Mở kết nối
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_ChiTietHoaDonNhap chiTiet = new DTO_ChiTietHoaDonNhap
                            {
                                MaHang = reader["MaHang"].ToString(),
                                TenHang = reader["TenHang"].ToString(),
                                SoLuong = int.Parse(reader["SoLuong"].ToString()),
                                DonGia = decimal.Parse(reader["DonGia"].ToString()),
                                ThanhTien = decimal.Parse(reader["ThanhTien"].ToString())
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
                    CloseConnection(); // Đảm bảo đóng kết nối
                }
            }

            return chiTietList; // Trả về danh sách chi tiết hóa đơn
        }

        //Phương thức lấy thông tin chi tiết hóa đơn _ In
        public List<DTO_ChiTietHoaDonNhap> RP_LayChiTietHoaDon(string soHDN)
        {
            List<DTO_ChiTietHoaDonNhap> chiTietList = new List<DTO_ChiTietHoaDonNhap>();
            string query = @"
        SELECT c.SoHDN, c.MaHang, h.TenHang, c.SoLuong, c.DonGia, c.ThanhTien, hdn.MaNV, hdn.NgayNhap
        FROM ChiTietHoaDonNhap c
        JOIN HangHoa h ON c.MaHang = h.MaHang
        JOIN HoaDonNhap hdn ON c.SoHDN = hdn.SoHDN
        WHERE c.SoHDN = @SoHDN";

            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@SoHDN", soHDN);

                try
                {
                    OpenConnection();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_ChiTietHoaDonNhap chiTiet = new DTO_ChiTietHoaDonNhap
                            {
                                SoHDN = reader["SoHDN"].ToString(),
                                MaHang = reader["MaHang"].ToString(),
                                TenHang = reader["TenHang"].ToString(),
                                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                DonGia = Convert.ToDecimal(reader["DonGia"]),
                                ThanhTien = Convert.ToDecimal(reader["ThanhTien"]),
                                MaNV = reader["MaNV"].ToString(),
                                NgayNhap = Convert.ToDateTime(reader["NgayNhap"])
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
        public void ThemChiTietHoaDon(DTO_ChiTietHoaDonNhap chiTietHoaDon)
        {
            string query = "INSERT INTO ChiTietHoaDonNhap (SoHDN, MaHang, SoLuong, DonGia, ThanhTien) " +
               "VALUES (@SoHDN, @MaHang, @SoLuong, @DonGia, @ThanhTien)";
            SqlCommand cmd = new SqlCommand(query, _conn);

            cmd.Parameters.AddWithValue("@SoHDN", chiTietHoaDon.SoHDN);
            cmd.Parameters.AddWithValue("@MaHang", chiTietHoaDon.MaHang);
            cmd.Parameters.AddWithValue("@SoLuong", chiTietHoaDon.SoLuong);
            cmd.Parameters.AddWithValue("@DonGia", chiTietHoaDon.DonGia);
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

        public DataTable GetTotalImportedQuantity()
        {
            string query = "SELECT SUM(SoLuong) AS Bang4 FROM ChiTietHoaDonNhap";
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
                    throw new Exception("An error occurred while getting total imported quantity: " + ex.Message);
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
