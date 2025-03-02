using DTO_QuanLy;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLy
{
    public class DAL_TaiKhoan : DBConnect
    {
        public DAL_TaiKhoan() { }

        // Lấy toàn bộ danh sách tài khoản
        public DataTable getTaiKhoan()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TaiKhoan", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Thêm tài khoản mới
        public bool themTaiKhoan(DTO_TaiKhoan tk)
        {
            try
            {
                _conn.Open();
                string query = "INSERT INTO TaiKhoan (MaTK, MaNV, TenDangNhap, MatKhau, QuyenHan) VALUES (@MaTK, @MaNV, @TenDangNhap, @MatKhau, @QuyenHan)";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaTK", tk.MaTK);
                cmd.Parameters.AddWithValue("@MaNV", tk.MaNV);
                cmd.Parameters.AddWithValue("@TenDangNhap", tk.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
                cmd.Parameters.AddWithValue("@QuyenHan", tk.QuyenHan);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Sửa thông tin tài khoản
        public bool suaTaiKhoan(DTO_TaiKhoan tk)
        {
            try
            {
                _conn.Open();
                string query = "UPDATE TaiKhoan SET MaNV = @MaNV, TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, QuyenHan = @QuyenHan WHERE MaTK = @MaTK";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaTK", tk.MaTK);
                cmd.Parameters.AddWithValue("@MaNV", tk.MaNV);
                cmd.Parameters.AddWithValue("@TenDangNhap", tk.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
                cmd.Parameters.AddWithValue("@QuyenHan", tk.QuyenHan);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Xóa tài khoản
        public bool xoaTaiKhoan(string maTK)
        {
            try
            {
                _conn.Open();
                string query = "DELETE FROM TaiKhoan WHERE MaTK = @MaTK";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaTK", maTK);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Kiểm tra tài khoản tồn tại
        public bool KiemTraTaiKhoanTonTai(string maTK)
        {
            try
            {
                _conn.Open();
                string query = "SELECT COUNT(*) FROM TaiKhoan WHERE MaTK = @MaTK";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaTK", maTK);

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

        public bool KiemTraMaNVTonTai(string maNV)
        {
            try
            {
                _conn.Open();
                string query = "SELECT COUNT(*) FROM TaiKhoan WHERE MaNV = @MaNV";
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
        public string VerifyUser(string username, string password)
        {
            string query = "SELECT MaNV FROM TaiKhoan WHERE TenDangNhap = @username AND MatKhau = @password";
            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                DataTable result = new DataTable();

                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    // Xử lý lỗi kết nối hoặc truy vấn tại đây
                    throw new Exception("An error occurred while verifying user: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }

                if (result.Rows.Count > 0)
                {
                    return result.Rows[0]["MaNV"].ToString();
                }

                return null; 
            }
        }
        public string VerifyUser1(string username, string password)
        {
            string query = "SELECT NhanVien.TenNV FROM TaiKhoan " +
                           "JOIN NhanVien ON TaiKhoan.MaNV = NhanVien.MaNV " +
                           "WHERE TaiKhoan.TenDangNhap = @username AND TaiKhoan.MatKhau = @password";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                DataTable result = new DataTable();

                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while verifying user: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }

                if (result.Rows.Count > 0)
                {
                    return result.Rows[0]["TenNV"].ToString();
                }

                return null;
            }
        }
        public string VerifyUser2(string username, string password)
        {
            string query = "SELECT TaiKhoan.QuyenHan FROM TaiKhoan " +
                           "WHERE TaiKhoan.TenDangNhap = @username AND TaiKhoan.MatKhau = @password";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                DataTable result = new DataTable();

                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while verifying user: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }

                if (result.Rows.Count > 0)
                {
                    return result.Rows[0]["QuyenHan"].ToString();
                }

                return null;
            }
        }
        public DataTable GetEmployeeCount()
        {
            string query = "SELECT COUNT(*) AS Bang1 FROM TaiKhoan";
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
                    throw new Exception("An error occurred while getting employee count: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
                return result;
            }
        }

        public DataTable GetEmployeeByRole()
        {
            string query = "SELECT QuyenHan, COUNT(*) AS Count FROM TaiKhoan GROUP BY QuyenHan";
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
                    throw new Exception("An error occurred while getting employee by role: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
                return result;
            }
        }
        public string GetEmployeeNameByAccount(string maNV)
        {
            string query = "SELECT TenNV FROM NhanVien WHERE MaNV = @maNV";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.Add("@maNV", SqlDbType.NVarChar).Value = maNV; // Sử dụng mã nhân viên làm tham số

                try
                {
                    _conn.Open();
                    object result = command.ExecuteScalar(); // Lấy một giá trị (TenNV)
                    if (result != null)
                    {
                        return result.ToString(); // Trả về tên nhân viên
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi trong quá trình tìm tên nhân viên: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }

                return null; // Trả về null nếu không tìm thấy
            }
        }
        public string GetEmployeeIdByLogin(string username, string password)
        {
            string query = "SELECT MaNV FROM TaiKhoan WHERE TenDangNhap = @username AND MatKhau = @password";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                try
                {
                    _conn.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString(); // Trả về mã nhân viên
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi trong quá trình lấy mã nhân viên: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }

            return null; // Trả về null nếu không tìm thấy
        }
    }
}
