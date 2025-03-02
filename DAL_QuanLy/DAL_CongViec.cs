using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_CongViec : DBConnect
    {
        public DAL_CongViec() { }

        // Lấy toàn bộ danh sách công việc
        public DataTable getCongViec()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CongViec", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Thêm công việc mới
        public bool themCongViec(DTO_CongViec cv)
        {
            try
            {
                _conn.Open();
                string query = "INSERT INTO CongViec (MaCV, TenCV, MucLuong) VALUES (@MaCV, @TenCV, @Luong)";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaCV", cv.MaCV);
                cmd.Parameters.AddWithValue("@TenCV", cv.TenCV);
                cmd.Parameters.AddWithValue("@Luong", cv.MucLuong);

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

        // Sửa thông tin công việc
        public bool suaCongViec(DTO_CongViec cv)
        {
            try
            {
                _conn.Open();
                string query = "UPDATE CongViec SET TenCV = @TenCV, MucLuong = @Luong WHERE MaCV = @MaCV";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaCV", cv.MaCV);
                cmd.Parameters.AddWithValue("@TenCV", cv.TenCV);
                cmd.Parameters.AddWithValue("@Luong", cv.MucLuong);

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

        // Xóa công việc
        public bool xoaCongViec(string maCV)
        {
            try
            {
                _conn.Open();
                string query = "DELETE FROM CongViec WHERE MaCV = @MaCV";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaCV", maCV);

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

        public bool KiemTraCongViecTonTai(string maCV)
        {
            try
            {
                _conn.Open();
                string query = "SELECT COUNT(*) FROM CongViec WHERE MaCV = @MaCV";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaCV", maCV);

                int count = (int)cmd.ExecuteScalar(); // Đếm số lượng công việc với mã đã cho
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


    }
}