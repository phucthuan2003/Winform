using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DBConnect
    {
		//protected SqlConnection _conn = new SqlConnection("Data Source=Chanh\\SQLEXPRESS;Initial Catalog=BTL_TQ5;Integrated Security=True");
		//protected SqlConnection _conn = new SqlConnection("Data Source=DESKTOP-S8N7JNH\\SQLEXPRESS;Initial Catalog=DB_LTTQ;Integrated Security=True;TrustServerCertificate=True");
        //protected SqlConnection _conn = new SqlConnection("Data Source=DESKTOP-S8N7JNH\\SQLEXPRESS;Initial Catalog=BTL_TQ3;Integrated Security=True;TrustServerCertificate=True");
        //protected SqlConnection _conn = new SqlConnection("Data Source=LAPTOP-L4E28I51\\SQLEXPRESS;Initial Catalog=BTL_TQ3;Integrated Security=True;TrustServerCertificate=True");

        //protected SqlConnection _conn = new SqlConnection("Data Source=DUA;Initial Catalog=a;Integrated Security=True;TrustServerCertificate=True");
        protected SqlConnection _conn = new SqlConnection("Data Source=DESKTOP-R4RPQKD;Initial Catalog=LTTQ_12;Integrated Security=True;Encrypt=True");
        public void OpenConnection()
        {
            try
            {
                // Kiểm tra nếu kết nối đang đóng, thì mở kết nối
                if (_conn != null && _conn.State == System.Data.ConnectionState.Closed)
                {
                    _conn.Open();
                    Console.WriteLine("Kết nối thành công");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi mở kết nối: " + ex.Message);
            }
        }

        // Phương thức đóng kết nối
        public void CloseConnection()
        {
            try
            {
                // Kiểm tra nếu kết nối đang mở, thì đóng kết nối
                if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
                {
                    _conn.Close();
                    Console.WriteLine("Đóng kết nối thành công");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đóng kết nối: " + ex.Message);
            }
        }
    }
}
