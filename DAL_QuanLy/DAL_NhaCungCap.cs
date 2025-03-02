using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
using System.Data.SqlClient;
using System.Data;

namespace DAL_QuanLy
{
    public class DAL_NhaCungCap : DBConnect
    {
        public DAL_NhaCungCap() { }

        // Lấy toàn bộ danh sách nhà cung cấp
        //DƯƠNG
        public DTO_NhaCungCap LayThongTinNhaCungCap(string nCC)
        {
            DTO_NhaCungCap ncc = null;
            string query = "SELECT * FROM NhaCungCap WHERE MaNCC = @MaNCC";

            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@MaNCC", nCC);

            try
            {
                OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ncc = new DTO_NhaCungCap
                    {
                        MaNCC = reader["MaNCC"].ToString(),
                        TenNCC = reader["TenNCC"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        DienThoai = reader["DienThoai"].ToString()
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin khách hàng: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return ncc;
        }

        public DTO_NhaCungCap ThongTinNhaCungCapTheoSoHoaDon(string soHoaDon)
        {
            DTO_NhaCungCap ncc = null;
            string query = @"
        SELECT ncc.MaNCC, ncc.TenNCC, ncc.DiaChi, ncc.DienThoai
        FROM NhaCungCap ncc
        INNER JOIN HoaDonNhap dh ON dh.MaNCC = ncc.MaNCC
        WHERE dh.SoHDN = @SoHDN"; // Sửa lại tên bảng cho chính xác

            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@SoHDN", soHoaDon);

            try
            {
                OpenConnection(); // Mở kết nối
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) // Nếu có kết quả
                {
                    ncc = new DTO_NhaCungCap
                    {
                        MaNCC = reader["MaNCC"].ToString(),
                        TenNCC = reader["TenNCC"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        DienThoai = reader["DienThoai"].ToString()
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin nhà cung cấp qua số hóa đơn: " + ex.Message);
            }
            finally
            {
                CloseConnection(); // Đảm bảo đóng kết nối
            }

            return ncc;
        }



        public List<DTO_NhaCungCap> LayDanhSachNhaCungCap()
        {
            List<DTO_NhaCungCap> danhSachNCC = new List<DTO_NhaCungCap>();
            string query = "SELECT MaNCC, TenNCC, DiaChi, DienThoai FROM NhaCungCap";

            SqlCommand cmd = new SqlCommand(query, _conn);
            OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DTO_NhaCungCap ncc = new DTO_NhaCungCap
                {
                    MaNCC = reader["MaNCC"].ToString(),
                    TenNCC = reader["TenNCC"].ToString(),
                    DiaChi = reader["DiaChi"].ToString(),
                    DienThoai = reader["DienThoai"].ToString()
                };
                danhSachNCC.Add(ncc);
            }
            CloseConnection();
            return danhSachNCC;
        }
        public DataTable getNhaCungCap()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM NhaCungCap WHERE TrangThai = 1", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetTypeData()
        {
            string query = "SELECT MaNCC AS iD FROM NhaCungCap";
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

        // Thêm nhà cung cấp mới
        public bool themNhaCungCap(DTO_NhaCungCap ncc)
        {
            try
            {
                _conn.Open();
                string query = "INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, DienThoai) VALUES (@MaNCC, @TenNCC, @DiaChi, @DienThoai)";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNCC", ncc.MaNCC);
                cmd.Parameters.AddWithValue("@TenNCC", ncc.TenNCC);
                cmd.Parameters.AddWithValue("@DiaChi", ncc.DiaChi);
                cmd.Parameters.AddWithValue("@DienThoai", ncc.DienThoai);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Sửa thông tin nhà cung cấp
        public bool suaNhaCungCap(DTO_NhaCungCap ncc)
        {
            try
            {
                _conn.Open();
                string query = "UPDATE NhaCungCap SET TenNCC = @TenNCC, DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaNCC = @MaNCC";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNCC", ncc.MaNCC);
                cmd.Parameters.AddWithValue("@TenNCC", ncc.TenNCC);
                cmd.Parameters.AddWithValue("@DiaChi", ncc.DiaChi);
                cmd.Parameters.AddWithValue("@DienThoai", ncc.DienThoai);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Xóa nhà cung cấp
        public bool xoaNhaCungCap(string maNCC)
        {
            try
            {
                _conn.Open();
                //string deleteInvoiceDetailsQuery = @"DELETE FROM ChiTietHoaDonNhap WHERE SoHDN IN (SELECT SoHDN FROM HoaDonNhap WHERE MaNCC = @MaNCC)";
                //SqlCommand deleteInvoiceDetailsCmd = new SqlCommand(deleteInvoiceDetailsQuery, _conn);
                //deleteInvoiceDetailsCmd.Parameters.AddWithValue("@MaNCC", maNCC);
                //deleteInvoiceDetailsCmd.ExecuteNonQuery();

                //string deleteInvoicesQuery = "DELETE FROM HoaDonNhap WHERE MaNCC = @MaNCC";
                //SqlCommand deleteInvoicesCmd = new SqlCommand(deleteInvoicesQuery, _conn);
                //deleteInvoicesCmd.Parameters.AddWithValue("@MaNCC", maNCC);
                //deleteInvoicesCmd.ExecuteNonQuery();
                string query = "UPDATE NhaCungCap SET TrangThai = 0 WHERE MaNCC = @MaNCC";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Kiểm tra nhà cung cấp tồn tại
        public bool KiemTraNhaCungCapTonTai(string maNCC)
        {
            try
            {
                _conn.Open();
                string query = "SELECT COUNT(*) FROM NhaCungCap WHERE MaNCC = @MaNCC";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                int count = (int)cmd.ExecuteScalar(); // Đếm số lượng nhà cung cấp với mã đã cho
                return count > 0; // Trả về true nếu tồn tại
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

        public DataTable TimKiemNCC(string searchTerm, string searchField)
        {

            // Sử dụng `COLLATE` để thực hiện so sánh không phân biệt dấu và không phân biệt hoa thường.
            string query = $@"SELECT * FROM NhaCungCap WHERE {searchField} COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @searchTerm + '%'";


            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@searchTerm", searchTerm);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

    }
}