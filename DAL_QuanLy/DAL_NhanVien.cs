using DTO_QuanLy;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DAL_QuanLy
{
    public class DAL_NhanVien : DBConnect
    {
        public string LayTenNhanVien(string maNV)
        {
            string sql = "SELECT TenNV FROM NhanVien WHERE MaNV = @MaNV";
            return ExecuteScalar(sql, maNV);
        }

        // Phương thức thực thi câu lệnh SQL và trả về giá trị đầu tiên
        private string ExecuteScalar(string sql, string parameterValue)
        {
            string result = string.Empty;
            try
            {
                OpenConnection(); // Mở kết nối
                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", parameterValue);
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        result = obj.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin: " + ex.Message);
            }
            finally
            {
                CloseConnection(); // Đảm bảo đóng kết nối
            }
            return result;
        }

        // Phương thức lấy danh sách nhân viên
        public DataTable GetNhanVien()
        {
            DataTable dt = new DataTable();
            OpenConnection();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT MaNV, TenNV FROM NhanVien", _conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu nhân viên: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }
        public DataTable getNhanVien()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM NhanVien where TrangThai = 1", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Thêm nhân viên
        public bool themNhanVien(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                string query = "INSERT INTO NhanVien (MaNV, TenNV, MaCV, CCCD, GioiTinh, NgaySinh, DienThoai, DiaChi, SoNgayPhep, SoNgayNghi, NgayTuyen, HinhAnh) VALUES (@MaNV, @TenNV, @MaCV, @CCCD, @GioiTinh, @NgaySinh, @DienThoai, @DiaChi, @SoNgayPhep, @SoNgayNghi, @NgayTuyen, @HinhAnh )";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@DienThoai", nv.DienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@MaCV", nv.MaCV);
                cmd.Parameters.AddWithValue("@SoNgayPhep", nv.SoNgayPhep);
                cmd.Parameters.AddWithValue("@SoNgayNghi", nv.SoNgayNghi);
                cmd.Parameters.AddWithValue("@NgayTuyen", nv.NgayTuyen);
                cmd.Parameters.AddWithValue("@CCCD", nv.CCCD);
                // cmd.Parameters.AddWithValue("@HinhAnh", nv.HinhAnh);
                cmd.Parameters.AddWithValue("@HinhAnh", (object)nv.HinhAnh ?? DBNull.Value);
                //if (nv.HinhAnh == null || nv.HinhAnh.Length == 0)
                //{
                //    cmd.Parameters.Add("@HinhAnh", SqlDbType.VarBinary).Value = new byte[0]; // Truyền một mảng byte trống
                //}
                //else
                //{
                //    cmd.Parameters.Add("@HinhAnh", SqlDbType.VarBinary).Value = nv.HinhAnh;
                //}
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                //  throw new Exception("Có lỗi khi thêm nhân viên: " + sqlEx.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
                return false;
            }
            finally
            {
                _conn.Close();
            }
        }

        public bool CapNhatNhanVien(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                string query = "UPDATE NhanVien SET TenNV = @TenNV, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, DienThoai = @DienThoai, DiaChi = @DiaChi, MaCV = @MaCV, SoNgayPhep = @SoNgayPhep, SoNgayNghi = @SoNgayNghi, NgayTuyen = @NgayTuyen, CCCD = @CCCD, HinhAnh = @HinhAnh WHERE MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@DienThoai", nv.DienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@MaCV", nv.MaCV);
                cmd.Parameters.AddWithValue("@SoNgayPhep", nv.SoNgayPhep);
                cmd.Parameters.AddWithValue("@SoNgayNghi", nv.SoNgayNghi);
                cmd.Parameters.AddWithValue("@NgayTuyen", nv.NgayTuyen);
                cmd.Parameters.AddWithValue("@CCCD", nv.CCCD);
                //    cmd.Parameters.AddWithValue("@HinhAnh", nv.HinhAnh);
                cmd.Parameters.AddWithValue("@HinhAnh", (object)nv.HinhAnh ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi cập nhật nhân viên: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        public bool xoaNhanVien(string maNV)
        {
            try
            {
                _conn.Open();
                //string query1 = "DELETE FROM TaiKhoan WHERE MaNV = @MaNV";
                //SqlCommand cmd1 = new SqlCommand(query1, _conn);
                //cmd1.Parameters.AddWithValue("@MaNV", maNV);
                //cmd1.ExecuteNonQuery();

                //string selectHoaDonBanQuery = "SELECT SoHDB FROM HoaDonBan WHERE MaNV = @MaNV";
                //SqlCommand selectHoaDonBanCmd = new SqlCommand(selectHoaDonBanQuery, _conn);
                //selectHoaDonBanCmd.Parameters.AddWithValue("@MaNV", maNV);

                //List<string> soHDBs = new List<string>();
                //using (SqlDataReader reader = selectHoaDonBanCmd.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        soHDBs.Add(reader["SoHDB"].ToString());
                //    }
                //}

                //// Bước 3: Xóa các chi tiết hóa đơn bán liên quan đến SoHDB
                //foreach (string soHDB in soHDBs)
                //{
                //    string deleteChiTietHoaDonBanQuery = "DELETE FROM ChiTietHoaDonBan WHERE SoHDB = @SoHDB";
                //    SqlCommand deleteChiTietHoaDonBanCmd = new SqlCommand(deleteChiTietHoaDonBanQuery, _conn);
                //    deleteChiTietHoaDonBanCmd.Parameters.AddWithValue("@SoHDB", soHDB);
                //    deleteChiTietHoaDonBanCmd.ExecuteNonQuery();
                //}

                //string deleteHoaDonBanQuery = "DELETE FROM HoaDonBan WHERE MaNV = @MaNV";
                //SqlCommand deleteHoaDonBanCmd = new SqlCommand(deleteHoaDonBanQuery, _conn);
                //deleteHoaDonBanCmd.Parameters.AddWithValue("@MaNV", maNV);
                //deleteHoaDonBanCmd.ExecuteNonQuery();

                //string selectHoaDonQuery = "SELECT SoHDN FROM HoaDonNhap WHERE MaNV = @MaNV";
                //SqlCommand selectHoaDonCmd = new SqlCommand(selectHoaDonQuery, _conn);
                //selectHoaDonCmd.Parameters.AddWithValue("@MaNV", maNV);


                //List<string> soHDNs = new List<string>();
                //using (SqlDataReader reader = selectHoaDonCmd.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        soHDNs.Add(reader["SoHDN"].ToString());
                //    }
                //}

                //foreach (string soHDN in soHDNs)
                //{
                //    string deleteChiTietQuery = "DELETE FROM ChiTietHoaDonNhap WHERE SoHDN = @SoHDN";
                //    SqlCommand deleteChiTietCmd = new SqlCommand(deleteChiTietQuery, _conn);
                //    deleteChiTietCmd.Parameters.AddWithValue("@SoHDN", soHDN);
                //    deleteChiTietCmd.ExecuteNonQuery();
                //}

                //string query2 = "DELETE FROM HoaDonNhap WHERE MaNV = @MaNV";
                //SqlCommand cmd2 = new SqlCommand(query2, _conn);
                //cmd2.Parameters.AddWithValue("@MaNV", maNV);
                //cmd2.ExecuteNonQuery();

                string query = "UPDATE NhanVien SET TrangThai = 0 WHERE MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("lỗi: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Phương thức lấy vai trò từ mã công việc
        public string GetVaiTroByMaCV(string maCV)
        {
            string vaiTro = string.Empty;
            string query = "SELECT TenCV FROM CongViec WHERE MaCV = @MaCV";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaCV", maCV);

                try
                {
                    _conn.Open();
                    object result = command.ExecuteScalar(); // Thực hiện truy vấn và lấy giá trị đầu tiên

                    if (result != null)
                    {
                        vaiTro = result.ToString(); // Gán vai trò nếu tìm thấy
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                finally
                {
                    _conn.Close(); // Đóng kết nối
                }
            }

            return vaiTro; // Trả về vai trò (có thể là chuỗi rỗng nếu không tìm thấy)
        }

        public bool KiemTraMaNV(string maNV)
        {
            try
            {
                _conn.Open();
                string query = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
                return false;
            }
            finally
            {
                _conn.Close();
            }
        }

        public bool KiemTraMaCV(string maCV)
        {
            try
            {
                _conn.Open();
                string query = "SELECT COUNT(*) FROM CongViec WHERE MaCV = @MaCV";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaCV", maCV);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
                return false;
            }
            finally
            {
                _conn.Close();
            }
        }

        public DataTable TimKiemNV(string searchTerm, string searchField)
        {

            // Sử dụng `COLLATE` để thực hiện so sánh không phân biệt dấu và không phân biệt hoa thường.
            string query = $@"SELECT * FROM NhanVien WHERE {searchField} COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @searchTerm + '%'";


            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@searchTerm", searchTerm);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable GetUserInfo(string maNV)
        {
            string query = "SELECT NhanVien.*, TaiKhoan.* FROM NhanVien JOIN TaiKhoan ON NhanVien.MaNV = TaiKhoan.MaNV WHERE NhanVien.MaNV = @maNV";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@maNV", maNV);
                DataTable result = new DataTable();

                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while retrieving user info: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }

                return result;
            }
        }
        public DataTable GetEmployData()
        {
            string query = "SELECT MaNV AS iD, TenNV as name FROM NhanVien";
            DataTable dataTable = new DataTable();

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                catch (SqlException ex)
                {
                    throw new Exception("Có lỗi xảy ra khi lấy dữ liệu từ bảng Customer: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }

            return dataTable;
        }
    }
}
