using System;
using System.Data.SqlClient;
using System.Data;

namespace DAL_QuanLy
{
    public class DAL_HoaVan : DBConnect
    {
        // Lấy dữ liệu từ bảng HoaVan
        public DataTable GetLoaiData()
        {
            string query = "SELECT * FROM HoaVan";
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
                    throw new Exception("Có lỗi xảy ra khi lấy dữ liệu từ bảng HoaVan: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }

            return dataTable;
        }

        // Thêm một HoaVan mới
        public void AddHoaVan(string maHoaVan, string tenHoaVan)
        {
            string query = "INSERT INTO HoaVan (MaHoaVan, TenHoaVan) VALUES (@MaHoaVan, @TenHoaVan)";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaHoaVan", maHoaVan);
                command.Parameters.AddWithValue("@TenHoaVan", tenHoaVan);
                try
                {
                    _conn.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Có lỗi xảy ra khi thêm dữ liệu vào bảng HoaVan: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }
        }

        // Cập nhật thông tin một HoaVan
        public void UpdateHoaVan(string maHoaVan, string tenHoaVan)
        {
            string query = "UPDATE HoaVan SET TenHoaVan = @TenHoaVan WHERE MaHoaVan = @MaHoaVan";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaHoaVan", maHoaVan);
                command.Parameters.AddWithValue("@TenHoaVan", tenHoaVan);
                try
                {
                    _conn.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Có lỗi xảy ra khi cập nhật dữ liệu trong bảng HoaVan: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }
        }

        // Xóa một HoaVan theo mã
        public void DeleteHoaVan(string maHoaVan)
        {
            string query = "DELETE FROM HoaVan WHERE MaHoaVan = @MaHoaVan";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaHoaVan", maHoaVan);
                try
                {
                    _conn.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Có lỗi xảy ra khi xóa dữ liệu trong bảng HoaVan: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }
        }
    }
}
