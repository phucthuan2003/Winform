using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_CongDung : DBConnect
    {
        public DataTable GetCongDungData()
        {
            string query = "SELECT * FROM CongDung";
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
                    throw new Exception("Có lỗi xảy ra khi lấy dữ liệu từ bảng CongDung: " + ex.Message);
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
            string query = "SELECT MaCongDung AS iD FROM CongDung";
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
        public void AddCongDung(string maCongDung, string tenCongDung)
        {
            string query = "INSERT INTO CongDung (MaCongDung, TenCongDung) VALUES (@MaCongDung, @TenCongDung)";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaCongDung", maCongDung);
                command.Parameters.AddWithValue("@TenCongDung", tenCongDung);
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

        public void UpdateCongDung(string maCongDung, string tenCongDung)
        {
            string query = "UPDATE CongDung SET TenCongDung = @TenCongDung WHERE MaCongDung = @MaCongDung";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaCongDung", maCongDung);
                command.Parameters.AddWithValue("@TenCongDung", tenCongDung);
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

        public void DeleteCongDung(string maCongDung)
        {
            string query = "DELETE FROM CongDung WHERE MaCongDung = @MaCongDung";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaCongDung", maCongDung);
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
