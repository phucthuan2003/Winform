using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
using DAL_QuanLy;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.IO;

namespace BUS_QuanLy
{
    public class BUS_ChiTietHoaDonNhap
    {
        DAL_ChiTietHoaDonNhap dalCT = new DAL_ChiTietHoaDonNhap();
        // Phương thức xóa chi tiết hóa đơn theo SoHDN
        public bool XoaChiTietHoaDonTheoSoHDN(string soHDN)
        {
            return dalCT.XoaChiTietHoaDonTheoSoHDN(soHDN);
        }

        //Phương thức lấy thông tin chi tiết hóa đơn (done)
        public List<DTO_ChiTietHoaDonNhap> LayChiTietHoaDon(string soHDN)
        {
            return dalCT.LayChiTietHoaDon(soHDN);
        }

        public List<DTO_ChiTietHoaDonNhap> RP_LayChiTietHoaDon(string soHDN)
        {
            return dalCT.RP_LayChiTietHoaDon(soHDN);
        }

        //Phương thức thêm mới chi tiết hóa đơn bán
        public void ThemChiTietHoaDon(DTO_ChiTietHoaDonNhap chiTietHoaDon)
        {
            dalCT.ThemChiTietHoaDon(chiTietHoaDon);
        }


        // Phương thức in chi tiết hóa đơn ra Excel
        public void InChiTietHoaDon(string soHDN)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            BUS_ChiTietHoaDonNhap busCT = new BUS_ChiTietHoaDonNhap();
            BUS_NhaCungCap busNCC = new BUS_NhaCungCap();

            List<DTO_ChiTietHoaDonNhap> chiTietList = busCT.LayChiTietHoaDon(soHDN);
            DTO_NhaCungCap nhaCC = busNCC.ThongTinNhaCungCapTheoSoHoaDon(soHDN);


            using (ExcelPackage excel = new ExcelPackage())
            {
                var workSheet = excel.Workbook.Worksheets.Add("Chi Tiết Hóa Đơn");

                workSheet.Cells[1, 1].Value = "Thông Tin Nhà Cung Cấp:";
                workSheet.Cells[2, 1].Value = "Tên Nhà Cung Cấp: " + nhaCC.TenNCC;
                workSheet.Cells[3, 1].Value = "Địa Chỉ: " + nhaCC.DiaChi;
                workSheet.Cells[4, 1].Value = "Số Điện Thoại: " + nhaCC.DienThoai;

                workSheet.Cells[1, 4].Value = "Thông Tin Cửa Hàng:";
                workSheet.Cells[2, 4].Value = "Tên Cửa Hàng:  Đồ Gốm CNTT4";
                workSheet.Cells[3, 4].Value = "Địa Chỉ: Số 3 đường Cầu Giấy, quận Đống Đa, thành phố Hà Nội. ";
                workSheet.Cells[4, 4].Value = "Số Điện Thoại : 0987654321";

                // Đặt tiêu đề cột cho chi tiết hóa đơn
                workSheet.Cells[9, 1].Value = "Mã Hàng";
                workSheet.Cells[9, 2].Value = "Tên Hàng";
                workSheet.Cells[9, 3].Value = "Số Lượng";
                workSheet.Cells[9, 4].Value = "Giảm Giá";
                workSheet.Cells[9, 5].Value = "Thành Tiền";

                // Định dạng tiêu đề cột
                using (var range = workSheet.Cells[9, 1, 9, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                }

                // Ghi dữ liệu vào worksheet
                for (int i = 0; i < chiTietList.Count; i++)
                {
                    workSheet.Cells[i + 10, 1].Value = chiTietList[i].MaHang;
                    workSheet.Cells[i + 10, 2].Value = chiTietList[i].TenHang;
                    workSheet.Cells[i + 10, 3].Value = chiTietList[i].SoLuong;
                    workSheet.Cells[i + 10, 5].Value = chiTietList[i].DonGia;
                    workSheet.Cells[i + 10, 6].Value = chiTietList[i].ThanhTien;
                }

                // Tính toán tổng tiền
                decimal tongTien = chiTietList.Sum(item => item.ThanhTien);
                workSheet.Cells[chiTietList.Count + 10, 5].Value = "Tổng Tiền:";
                workSheet.Cells[chiTietList.Count + 10, 6].Value = tongTien;

                // Định dạng dòng tổng tiền (in đậm, căn giữa)
                using (var range = workSheet.Cells[chiTietList.Count + 10, 5, chiTietList.Count + 10, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // Lưu file Excel
                var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"ChiTietHoaDon_{soHDN}.xlsx");
                FileInfo excelFile = new FileInfo(filePath);
                excel.SaveAs(excelFile);

                // Thông báo cho người dùng
                Console.WriteLine("Đã in chi tiết hóa đơn ra file Excel tại: " + filePath);
            }
        }

    }
}
