using DAL_QuanLy;
using DTO_QuanLy;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Drawing;


namespace BUS_QuanLy
{
    public class BUS_ChiTietHoaDonBan
    {
        DAL_ChiTietHoaDonBan dalCT = new DAL_ChiTietHoaDonBan();

        // Phương thức lấy chi tiết hóa đơn từ mã hóa đơn
        public List<DTO_ChiTietHoaDonBan> LayChiTietHoaDon(string soHDB)
        {
            return dalCT.LayChiTietHoaDon(soHDB);
        }

        public List<DTO_ChiTietHoaDonBan> RP_LayChiTietHoaDonBan(string soHDB)
        {
            return dalCT.RP_LayChiTietHoaDon(soHDB);
        }

        public void ThemChiTietHoaDon(DTO_ChiTietHoaDonBan ct)
        {
            dalCT.ThemChiTietHoaDon(ct);
        }

        public bool XoaChiTietHoaDonTheoSoHDB(string soHDB)
        {
            return dalCT.XoaChiTietHoaDonTheoSoHDB(soHDB);
        }

        // Phương thức in chi tiết hóa đơn ra Excel
        public void InChiTietHoaDon(string soHDB)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Lấy thông tin chi tiết hóa đơn và khách hàng
            BUS_ChiTietHoaDonBan busCT = new BUS_ChiTietHoaDonBan();
            BUS_KhachHang busKH = new BUS_KhachHang();
            List<DTO_ChiTietHoaDonBan> chiTietList = busCT.LayChiTietHoaDon(soHDB);
            DTO_KhachHang khachHang = busKH.ThongTinKhachHangTheoSoHoaDon(soHDB);

            using (ExcelPackage excel = new ExcelPackage())
            {
                // Tạo worksheet
                var workSheet = excel.Workbook.Worksheets.Add("Chi Tiết Hóa Đơn");

                // Thêm tiêu đề
                workSheet.Cells[1, 1].Value = "Chi Tiết Hóa Đơn";
                workSheet.Cells[1, 1].Style.Font.Bold = true;
                workSheet.Cells[1, 1].Style.Font.Size = 16;
                workSheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Thêm thông tin khách hàng
                workSheet.Cells[3, 1].Value = "Thông Tin Khách Hàng:";
                workSheet.Cells[4, 1].Value = "Tên Khách Hàng:";
                workSheet.Cells[4, 2].Value = khachHang.TenKhach;
                workSheet.Cells[5, 1].Value = "Địa Chỉ:";
                workSheet.Cells[5, 2].Value = khachHang.DiaChi;
                workSheet.Cells[6, 1].Value = "Số Điện Thoại:";
                workSheet.Cells[6, 2].Value = khachHang.DienThoai;

                // Thêm thông tin cửa hàng
                workSheet.Cells[8, 1].Value = "Thông Tin Cửa Hàng:";
                workSheet.Cells[9, 1].Value = "Tên Cửa Hàng:";
                workSheet.Cells[9, 2].Value = "Đồ Gốm CNTT4";
                workSheet.Cells[10, 1].Value = "Địa Chỉ:";
                workSheet.Cells[10, 2].Value = "Số 3 đường Cầu Giấy, quận Đống Đa, Hà Nội.";
                workSheet.Cells[11, 1].Value = "Số Điện Thoại:";
                workSheet.Cells[11, 2].Value = "0987654321";

                // Đặt tiêu đề bảng chi tiết hóa đơn
                string[] headers = { "Mã Hàng", "Tên Hàng", "Số Lượng", "Giảm Giá", "Đơn Giá", "Thành Tiền" };
                int startRow = 13;
                for (int i = 0; i < headers.Length; i++)
                {
                    workSheet.Cells[startRow, i + 1].Value = headers[i];
                }

                // Định dạng tiêu đề bảng
                using (var range = workSheet.Cells[startRow, 1, startRow, headers.Length])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                   // range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                // Ghi dữ liệu chi tiết hóa đơn vào bảng
                for (int i = 0; i < chiTietList.Count; i++)
                {
                    var item = chiTietList[i];
                    workSheet.Cells[i + startRow + 1, 1].Value = item.MaHang;
                    workSheet.Cells[i + startRow + 1, 2].Value = item.TenHang;
                    workSheet.Cells[i + startRow + 1, 3].Value = item.SoLuong;
                    workSheet.Cells[i + startRow + 1, 4].Value = item.GiamGia;
                    workSheet.Cells[i + startRow + 1, 5].Value = item.DonGiaBan;
                    workSheet.Cells[i + startRow + 1, 6].Value = item.ThanhTien;
                }

                // Tính tổng tiền và hiển thị cuối bảng
                decimal tongTien = chiTietList.Sum(item => item.ThanhTien);
                int footerRow = chiTietList.Count + startRow + 1;
                workSheet.Cells[footerRow, 5].Value = "Tổng Tiền:";
                workSheet.Cells[footerRow, 6].Value = tongTien;

                using (var range = workSheet.Cells[footerRow, 5, footerRow, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 12;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                // Định dạng tổng thể cho bảng
                using (var range = workSheet.Cells[startRow + 1, 1, footerRow, 6])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                // Điều chỉnh độ rộng cột
                workSheet.Column(1).Width = 15;
                workSheet.Column(2).Width = 30;
                workSheet.Column(3).Width = 15;
                workSheet.Column(4).Width = 15;
                workSheet.Column(5).Width = 15;
                workSheet.Column(6).Width = 15;

                // Lưu file Excel ra Desktop
                var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"ChiTietHoaDon_{soHDB}.xlsx");
                FileInfo excelFile = new FileInfo(filePath);
                excel.SaveAs(excelFile);

                // Thông báo cho người dùng
                Console.WriteLine("Đã in chi tiết hóa đơn ra file Excel tại: " + filePath);
            }
        }


    }
}