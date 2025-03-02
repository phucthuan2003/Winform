using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_Report_DoanhThu
    {
        private DAL_Report_DoanhThu dAL_Report;
        public BUS_Report_DoanhThu() 
        {
            dAL_Report = new DAL_Report_DoanhThu();
        }  
        //public List<DTO_ReportDoanhThu> GetReportData()
        //{
        //    return dAL_Report.GetReportData();
        //}


    }
}
