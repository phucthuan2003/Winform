using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_ReportDoanhThu
    {
        public string InvoiceNumber { get; set; }
        public decimal Revenue { get; set; }
        public DateTime SaleDate { get; set; }
        public int ProductCount { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}
