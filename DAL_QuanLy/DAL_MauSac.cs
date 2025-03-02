using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_MauSac : DBConnect
    {
        public DataTable GetMauSacData()
        {
            string query = "SELECT * FROM MauSac";
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
                    throw new Exception("Có lỗi xảy ra khi lấy dữ liệu từ bảng MauSac: " + ex.Message);
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
            string query = "SELECT MaMau AS iD FROM MauSac";
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
        public void AddMauSac(string MaMau, string TenMau)
        {
            string query = "INSERT INTO MauSac (MaMau, TenMau) VALUES (@MaMau, @TenMau)";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaMau", MaMau);
                command.Parameters.AddWithValue("@TenMau", TenMau);
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

        public void UpdateMauSac(string MaMau, string TenMau)
        {
            string query = "UPDATE MauSac SET TenMau = @TenMau WHERE MaMau = @MaMau";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaMau", MaMau);
                command.Parameters.AddWithValue("@TenMau", TenMau);
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

        public void DeleteMauSac(string MaMau)
        {
            string query = "DELETE FROM MauSac WHERE MaMau = @MaMau";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaMau", MaMau);
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
