using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_SalesData
    {
        private DAL_SalesData salesDataDAL;
        public BUS_SalesData()
        {
            salesDataDAL = new DAL_SalesData();
        }
        //public (decimal DoanhThu, int SoSanPham) GetSalesData(DateTime date)
        //{
        //    return salesDataDAL.GetSalesData(date);
        //}

        // Phương thức lấy dữ liệu bán hàng cho một khoảng thời gian (ví dụ 7 ngày)
        //public List<(DateTime Date, decimal DoanhThu, int SoSanPham)> GetSalesDataForPeriod(DateTime startDate, int numberOfDays)
        //{
        //    List<(DateTime Date, decimal DoanhThu, int SoSanPham)> salesDataList = new List<(DateTime Date, decimal DoanhThu, int SoSanPham)>();

        //    for (int i = 0; i < numberOfDays; i++)
        //    {
        //        DateTime date = startDate.AddDays(-i); // Lấy ngày từ hôm nay ngược về quá khứ
        //        var salesData = salesDataDAL.GetSalesData(date);
        //        salesDataList.Add((date, salesData.DoanhThu, salesData.SoSanPham));
        //    }

        //    return salesDataList;
        //}

        //public List<DTO_Product> GetProductRankingData()
        //{
        //    return salesDataDAL.GetProductRanking();
        //}

        public (decimal DoanhThu, int SoSanPham) GetSalesDataForPeriod(DateTime startDate, DateTime endDate)
        {
            return salesDataDAL.GetSalesDataForPeriod(startDate, endDate);
        }

        public List<DTO_Product> GetProductSalesDataForPeriod(DateTime startDate, DateTime endDate)
        {
            return salesDataDAL.GetProductSalesDataForPeriod(startDate, endDate);
        }

        public List<(string WeekLabel, decimal DoanhThu, int SoSanPham)> GetSalesDataGroupedByWeek(DateTime startDate, DateTime endDate)
        {
            // Gọi phương thức từ DAL để lấy dữ liệu đã nhóm
            return salesDataDAL.GetSalesDataGroupedByWeek(startDate, endDate);
        }
        public int GetEmployeeCountForPeriod(DateTime startDate, DateTime endDate)
        {
            return salesDataDAL.GetEmployeeCountForPeriod(startDate, endDate);
        }
        public int GetOrderCountForPeriod(DateTime startDate, DateTime endDate)
        {
            return salesDataDAL.GetOrderCountForPeriod(startDate, endDate);
        }
        public (decimal DoanhThu, int SoSanPham, int SoDonHang, int SoNhanVien) GetTotalSalesData()
        {
            return salesDataDAL.GetTotalSalesData();
        }


    }
}
