using DTO_QuanLy;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_ReportNhanVien : DBConnect
    {
        //private string connectionString = "Data Source=LAPTOP-L4E28I51\\SQLEXPRESS;Initial Catalog=BTL_TQ3;Integrated Security=True;TrustServerCertificate=True";

        public List<DTO_NhanVien> GetNhanVienData()
        {
            List<DTO_NhanVien> nhanVienList = new List<DTO_NhanVien>();

            try
            {
                // Mở kết nối kế thừa từ DBConnect
                OpenConnection();

                string query = @"
                    SELECT MaNV, TenNV, MaCV, GioiTinh, NgaySinh, DienThoai, NgayTuyen
                    FROM NhanVien"
                ;

                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var nhanVien = new DTO_NhanVien
                            {
                                MaNV = reader["MaNV"].ToString(),
                                TenNV = reader["TenNV"].ToString(),
                                MaCV = reader["MaCV"].ToString(),
                                GioiTinh = reader["GioiTinh"].ToString(),
                                NgaySinh = reader["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["NgaySinh"]) : DateTime.MinValue,
                                DienThoai = reader["DienThoai"].ToString(),
                                NgayTuyen = reader["NgayTuyen"] != DBNull.Value ? Convert.ToDateTime(reader["NgayTuyen"]) : DateTime.MinValue
                            };

                            nhanVienList.Add(nhanVien);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc thông báo nếu có
                Console.WriteLine("Lỗi khi lấy thông tin: " + ex.Message);
            }
            finally
            {
                // Đảm bảo luôn đóng kết nối
                CloseConnection();
            }

            return nhanVienList;
        }

        public DataTable ConvertNhanVienListToDataTable(List<DTO_NhanVien> list)
        {
            var table = new DataTable();
            table.Columns.Add("MaNV", typeof(string));
            table.Columns.Add("TenNV", typeof(string));
            table.Columns.Add("MaCV", typeof(string));
            table.Columns.Add("GioiTinh", typeof(string));
            table.Columns.Add("NgaySinh", typeof(DateTime));
            table.Columns.Add("DienThoai", typeof(string));
            table.Columns.Add("NgayTuyen", typeof(DateTime));

            foreach (var item in list)
            {
                table.Rows.Add(item.MaNV, item.TenNV, item.MaCV, item.GioiTinh, item.NgaySinh, item.DienThoai, item.NgayTuyen);
            }

            return table;
        }
    }
}
