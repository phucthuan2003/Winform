using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_HinhKhoi : DBConnect
    {
        public DataTable GetHinhKhoiData()
        {
            string query = "SELECT * FROM HinhKhoi";
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
                    throw new Exception("Có lỗi xảy ra khi lấy dữ liệu từ bảng HinhKhoi: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }

            return dataTable;
        }
        public DataTable GetTypeData()
        {
            string query = "SELECT MaHinhKhoi AS iD FROM HinhKhoi";
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
        public void AddHinhKhoi(string maHinhKhoi, string tenHinhKhoi)
        {
            string query = "INSERT INTO HinhKhoi (MaHinhKhoi, TenHinhKhoi) VALUES (@MaHinhKhoi, @TenHinhKhoi)";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaHinhKhoi", maHinhKhoi);
                command.Parameters.AddWithValue("@TenHinhKhoi", tenHinhKhoi);
                try
                {
                    _conn.Open(); // Mở kết nối
                    command.ExecuteNonQuery(); // Thực hiện lệnh
                }
                catch (SqlException ex)
                {
                    throw new Exception("Có lỗi xảy ra khi thêm dữ liệu: " + ex.Message);
                }
                finally
                {
                    _conn.Close(); // Đảm bảo rằng kết nối được đóng
                }
            }
        }

        public void UpdateHinhKhoi(string maHinhKhoi, string tenHinhKhoi)
        {
            string query = "UPDATE HinhKhoi SET TenHinhKhoi = @TenHinhKhoi WHERE MaHinhKhoi = @MaHinhKhoi";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaHinhKhoi", maHinhKhoi);
                command.Parameters.AddWithValue("@TenHinhKhoi", tenHinhKhoi);
                try
                {
                    _conn.Open(); // Mở kết nối
                    command.ExecuteNonQuery(); // Thực hiện lệnh
                }
                catch (SqlException ex)
                {
                    throw new Exception("Có lỗi xảy ra khi cập nhật dữ liệu: " + ex.Message);
                }
                finally
                {
                    _conn.Close(); // Đảm bảo rằng kết nối được đóng
                }
            }
        }

        public void DeleteHinhKhoi(string maHinhKhoi)
        {
            string query = "DELETE FROM HinhKhoi WHERE MaHinhKhoi = @MaHinhKhoi";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaHinhKhoi", maHinhKhoi);
                try
                {
                    _conn.Open(); // Mở kết nối
                    command.ExecuteNonQuery(); // Thực hiện lệnh
                }
                catch (SqlException ex)
                {
                    throw new Exception("Có lỗi xảy ra khi xóa dữ liệu: " + ex.Message);
                }
                finally
                {
                    _conn.Close(); // Đảm bảo rằng kết nối được đóng
                }
            }
        }
    }
}
