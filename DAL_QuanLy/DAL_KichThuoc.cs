using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_KichThuoc : DBConnect
    {
        public DataTable GetKichThuocData()
        {
            string query = "SELECT * FROM KichThuoc";
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
                    throw new Exception("Có lỗi xảy ra khi lấy dữ liệu từ bảng KichThuoc: " + ex.Message);
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
            string query = "SELECT MaKichThuoc AS iD FROM KichThuoc";
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
        public void AddKichThuoc(string maKichThuoc, string tenKichThuoc)
        {
            string query = "INSERT INTO KichThuoc (MaKichThuoc, TenKichThuoc) VALUES (@MaKichThuoc, @TenKichThuoc)";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaKichThuoc", maKichThuoc);
                command.Parameters.AddWithValue("@TenKichThuoc", tenKichThuoc);
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

        public void UpdateKichThuoc(string maKichThuoc, string tenKichThuoc)
        {
            string query = "UPDATE KichThuoc SET TenKichThuoc = @TenKichThuoc WHERE MaKichThuoc = @MaKichThuoc";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaKichThuoc", maKichThuoc);
                command.Parameters.AddWithValue("@TenKichThuoc", tenKichThuoc);
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

        public void DeleteKichThuoc(string maKichThuoc)
        {
            string query = "DELETE FROM KichThuoc WHERE MaKichThuoc = @MaKichThuoc";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaKichThuoc", maKichThuoc);
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
