using DTO_QuanLy;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLy
{
    public class DAL_HangHoa : DBConnect
    {
        // Lấy số lượng sản phẩm trong kho
        public DataTable GetTotalProductsCount()
        {
            string query = "SELECT COUNT(MaHang) AS Bang3 FROM HangHoa";
            DataTable result = new DataTable();

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while getting total products count: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }

            return result;
        }

        // Lấy tổng số lượng sản phẩm tồn kho
        public DataTable GetTotalStockQuantity()
        {
            string query = "SELECT SUM(SoLuong) AS Bang3 FROM HangHoa";
            DataTable result = new DataTable();

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while getting total stock quantity: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }

            return result;
        }

        // Lấy dữ liệu hàng hóa
        public DataTable GetHangHoaData()
        {
            string query = "SELECT TenHang, SoLuong, DonGiaBan, GhiChu FROM HangHoa WHERE TrangThai = 1";
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
                    throw new Exception("An error occurred while fetching HangHoa data: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }

            return dataTable;
        }
        public DataTable SearchHangHoaData(string searchValue)
        {
            string query = @"
                SELECT TenHang, SoLuong, DonGiaBan, GhiChu 
                FROM HangHoa 
                WHERE MaHang LIKE @searchValue OR TenHang LIKE @searchValue";
            DataTable dataTable = new DataTable();

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%"); // Sử dụng tham số để ngăn chặn SQL Injection

                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while searching HangHoa data: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }

            return dataTable;
        }

        // Cập nhật thông tin hàng hóa
        public void UpdateHangHoa(DTO_HangHoa hangHoa)
        {
            string query = "UPDATE HangHoa SET " +
                           "SoLuong = @SoLuong, " +
                           "DonGiaBan = @DonGiaBan, " +
                           "DonGiaNhap = @DonGiaNhap, " +
                           "GhiChu = @GhiChu, " +
                           "Anh = @Anh, " +
                           "MaLoai = @MaLoai, " +
                           "MaKichThuoc = @MaKT, " +
                           "MaLoaiMen = @MaMen, " +
                           "MaMau = @MaMau, " +
                           "MaCongDung = @MaCD, " +
                           "MaHinhKhoi = @MaHK, " +
                           "MaNuocSX = @MaNuoc " +
                           "WHERE TenHang = @TenHang"; // Sử dụng TenHang làm điều kiện cập nhật

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@SoLuong", hangHoa.SoLuong);
                command.Parameters.AddWithValue("@DonGiaBan", hangHoa.DonGiaBan);
                command.Parameters.AddWithValue("@DonGiaNhap", hangHoa.DonGiaNhap);
                command.Parameters.AddWithValue("@GhiChu", hangHoa.GhiChu);
                command.Parameters.AddWithValue("@Anh", hangHoa.Anh ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@MaLoai", hangHoa.MaLoai);
                command.Parameters.AddWithValue("@MaKT", hangHoa.MaKichThuoc);
                command.Parameters.AddWithValue("@MaMen", hangHoa.MaLoaiMen);
                command.Parameters.AddWithValue("@MaMau", hangHoa.MaMau);
                command.Parameters.AddWithValue("@MaCD", hangHoa.MaCongDung);
                command.Parameters.AddWithValue("@MaHK", hangHoa.MaHinhKhoi);
                command.Parameters.AddWithValue("@MaNuoc", hangHoa.MaNuocSX);
                command.Parameters.AddWithValue("@TenHang", hangHoa.TenHangHoa); // Điều kiện để tìm bản ghi cần cập nhật

                try
                {
                    _conn.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while updating HangHoa: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }
        }

        // Thêm hàng hóa mới
        public void AddHangHoa(DTO_HangHoa hangHoa)
        {
            string query = "INSERT INTO HangHoa (MaHang, TenHang, MaLoai, MaKichThuoc, MaLoaiMen, MaMau, SoLuong, DonGiaBan, DonGiaNhap, Anh, GhiChu, MaCongDung, MaHinhKhoi, MaNuocSX, MaNCC) " +
                           "VALUES (@MaHang, @TenHang, @MaLoai, @MaKT, @MaMen, @MaMau, @SoLuong, @DGB, @DGN, @Anh, @GhiChu, @MaCD, @MaHK, @MaNuoc, @MaNCC)";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaHang", hangHoa.MaHang);
                command.Parameters.AddWithValue("@TenHang", hangHoa.TenHangHoa);
                command.Parameters.AddWithValue("@MaLoai", hangHoa.MaLoai);
                command.Parameters.AddWithValue("@MaKT", hangHoa.MaKichThuoc);
                command.Parameters.AddWithValue("@MaMen", hangHoa.MaLoaiMen);
                command.Parameters.AddWithValue("@MaMau", hangHoa.MaMau);
                command.Parameters.AddWithValue("@SoLuong", hangHoa.SoLuong);
                command.Parameters.AddWithValue("@DGB", hangHoa.DonGiaBan);
                command.Parameters.AddWithValue("@DGN", hangHoa.DonGiaNhap);
                command.Parameters.AddWithValue("@Anh", hangHoa.Anh ?? (object)DBNull.Value); // Nếu null thì gán DBNull
                command.Parameters.AddWithValue("@GhiChu", hangHoa.GhiChu ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@MaCD", hangHoa.MaCongDung);
                command.Parameters.AddWithValue("@MaHK", hangHoa.MaHinhKhoi);
                command.Parameters.AddWithValue("@MaNuoc", hangHoa.MaNuocSX);
                command.Parameters.AddWithValue("@MaNCC", hangHoa.MaNCC);

                try
                {
                    _conn.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while adding HangHoa: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }
        }

        // Kiểm tra mã hàng có tồn tại hay không
        public bool CheckMaHangExists(string maHang)
        {
            string checkQuery = "SELECT COUNT(*) FROM HangHoa WHERE MaHang = @MaHang";
            using (SqlCommand command = new SqlCommand(checkQuery, _conn))
            {
                command.Parameters.AddWithValue("@MaHang", maHang);

                try
                {
                    _conn.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while checking MaHang: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }
        }

        // Lấy thông tin hàng hóa theo tên
        public DTO_HangHoa GetHangHoaByTenHang(string tenHang)
        {
            string query = "SELECT * FROM HangHoa WHERE TenHang = @TenHang and TrangThai = 1";
            DTO_HangHoa hangHoa = null;

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@TenHang", tenHang);

                try
                {
                    _conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            hangHoa = new DTO_HangHoa
                            {
                                MaHang = reader["MaHang"].ToString(),
                                TenHangHoa = reader["TenHang"].ToString(),
                                MaLoai = reader["MaLoai"].ToString(),
                                MaKichThuoc = reader["MaKichThuoc"].ToString(),
                                MaLoaiMen = reader["MaLoaiMen"].ToString(),
                                MaMau = reader["MaMau"].ToString(),
                                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                DonGiaBan = Convert.ToDecimal(reader["DonGiaBan"]),
                                DonGiaNhap = Convert.ToDecimal(reader["DonGiaNhap"]),
                                GhiChu = reader["GhiChu"].ToString(),
                                Anh = reader["Anh"] != DBNull.Value ? (byte[])reader["Anh"] : null,
                                MaCongDung = reader["MaCongDung"].ToString(),
                                MaHinhKhoi = reader["MaHinhKhoi"].ToString(),
                                MaNuocSX = reader["MaNuocSX"].ToString()
                            };
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while fetching HangHoa data: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }

            return hangHoa;
        }

        // Xóa hàng hóa theo tên
        public bool DeleteHangHoa(string maHang)
        {
            string query = "UPDATE HangHoa SET TrangThai = 0 WHERE MaHang = @MaHang";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaHang", maHang);

                try
                {
                    _conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu cập nhật thành công
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while deleting HangHoa: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }
        }

        // Phương thức lấy tất cả hàng hóa
        public string GetMaHangByTenHang(string tenHang)
        {
            string query = "SELECT MaHang FROM HangHoa WHERE TenHang = @TenHang and  TrangThai = 1";
            string maHang = null;

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                // Thêm tham số @TenHang để ngăn chặn SQL Injection
                command.Parameters.AddWithValue("@TenHang", tenHang);

                try
                {
                    _conn.Open();
                    // Sử dụng ExecuteScalar để lấy giá trị đơn lẻ
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        maHang = result.ToString(); // Lấy mã hàng nếu tìm thấy
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while fetching MaHang: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }

            return maHang; // Trả về mã hàng hoặc null nếu không tìm thấy
        }


        // Phương thức lấy hàng hóa có trạng thái là 1
        public DataTable GetActiveHangHoaData()
        {
            string query = "SELECT TenHang, SoLuong, DonGiaBan, GhiChu FROM HangHoa WHERE TrangThai = 1";
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
                    throw new Exception("An error occurred while fetching active HangHoa data: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }

            return dataTable;
        }

        public bool UpdateHangHoaStatus(string maHang, int trangThai)
        {
            string query = "UPDATE HangHoa SET TrangThai = @TrangThai WHERE MaHang = @MaHang";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@TrangThai", trangThai);
                command.Parameters.AddWithValue("@MaHang", maHang);

                try
                {
                    _conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu cập nhật thành công
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while updating product status: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }
        }


        public DataTable GetInfo()
        {
            string query = "SELECT * FROM HangHoa";
            DataTable result = new DataTable();

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while getting total products count: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }
            return result;
        }
        public DataTable GetHangHoa(string searchColumn = "", string searchText = "")
        {
            string query = "SELECT * FROM HangHoa where TrangThai = 1";
            DataTable result = new DataTable();

            if (!string.IsNullOrEmpty(searchColumn) && !string.IsNullOrEmpty(searchText))
            {
                query += $" WHERE {searchColumn} LIKE @searchText";
            }

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                if (!string.IsNullOrEmpty(searchText))
                {
                    command.Parameters.AddWithValue("@searchText", $"%{searchText}%");
                }

                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while retrieving products: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }

            return result;
        }
        public DTO_HangHoa LayThongTinHangHoa(string maHang)
        {
            DTO_HangHoa hangHoa = null;
            string query = "SELECT * FROM HangHoa WHERE MaHang = @MaHang and TrangThai = 1";

            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@MaHang", maHang);

            try
            {
                OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    hangHoa = new DTO_HangHoa
                    {
                        MaHang = reader["MaHang"].ToString(),
                        TenHangHoa = reader["TenHang"].ToString(),
                        DonGiaBan = decimal.Parse(reader["DonGiaBan"].ToString())
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin hàng hóa: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return hangHoa;
        }

        public List<DTO_HangHoa> LayDanhSachHangHoa()
        {
            List<DTO_HangHoa> danhSachHangHoa = new List<DTO_HangHoa>();
            string query = "SELECT MaHang, TenHang, DonGiaBan FROM HangHoa where TrangThai = 1";

            SqlCommand cmd = new SqlCommand(query, _conn);
            OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DTO_HangHoa hangHoa = new DTO_HangHoa
                {
                    MaHang = reader["MaHang"].ToString(),
                    TenHangHoa = reader["TenHang"].ToString(),
                    DonGiaBan = Convert.ToDecimal(reader["DonGiaBan"])
                };
                danhSachHangHoa.Add(hangHoa);
            }
            CloseConnection();
            return danhSachHangHoa;
        }

        public void CapNhatSoLuongTonKho(string maHang, int soLuong)
        {
            string query = "UPDATE HangHoa SET SoLuong = SoLuong + @SoLuong WHERE MaHang = @MaHang";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
            cmd.Parameters.AddWithValue("@MaHang", maHang);

            OpenConnection();
            cmd.ExecuteNonQuery();
            CloseConnection();
        }

        public int LaySoLuongSanPham(string maHang)
        {
            string query = "SELECT SoLuong FROM HangHoa WHERE MaHang = @MaHang";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@MaHang", maHang);

            try
            {
                // Mở kết nối bằng phương thức OpenConnection
                OpenConnection();

                // Execute the query and get the result
                object result = cmd.ExecuteScalar();

                // Kiểm tra và chuyển đổi kết quả
                if (result != null && int.TryParse(result.ToString(), out int soLuong))
                {
                    return soLuong;
                }

                return 0; // Trả về 0 nếu không tìm thấy mã hàng
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                throw new Exception("Error while retrieving product quantity: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối bằng phương thức CloseConnection
                CloseConnection();
            }
        }
        public List<DTO_HangHoa> LayDanhSachHangHoaTheoNCC(string maNCC)
        {
            List<DTO_HangHoa> danhSachHangHoa = new List<DTO_HangHoa>();
            string query = "SELECT * FROM HangHoa WHERE MaNCC = @MaNCC";

            try
            {
                // Mở kết nối
                OpenConnection();

                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    // Thêm tham số
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                    // Thực thi truy vấn
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Duyệt qua từng dòng kết quả
                        while (reader.Read())
                        {
                            danhSachHangHoa.Add(new DTO_HangHoa
                            {
                                MaHang = reader["MaHang"].ToString(),
                                TenHangHoa = reader["TenHang"].ToString(),
                                DonGiaBan = reader["DonGiaBan"] != DBNull.Value
                                    ? Convert.ToDecimal(reader["DonGiaBan"])
                                    : 0,
                                MaNCC = reader["MaNCC"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                throw new Exception("Error while retrieving product list: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                CloseConnection();
            }

            return danhSachHangHoa;
        }


    }
}