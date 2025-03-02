using DAL_QuanLy;
using DTO_QuanLy;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_HoaDonNhap
    {
        DAL_HoaDonNhap dalHDN = new DAL_HoaDonNhap();
        DAL_ChiTietHoaDonNhap dalCT = new DAL_ChiTietHoaDonNhap();


        // Phương thức lấy toàn bộ danh sách hóa đơn bán
        public DataTable LayDanhSachHoaDonNhap()
        {
            return dalHDN.LayDanhSachHoaDonNhap();
        }

        // Phương thức xóa hóa đơn 
        public bool XoaHoaDon(string soHDN)
        {
            // Đầu tiên, xóa các chi tiết hóa đơn liên quan
            bool xoaChiTietThanhCong = dalCT.XoaChiTietHoaDonTheoSoHDN(soHDN);

            if (xoaChiTietThanhCong)
            {
                // Nếu xóa chi tiết thành công, tiếp tục xóa hóa đơn
                return dalHDN.XoaHoaDonBan(soHDN);
            }
            else
            {
                Console.WriteLine("Không thể xóa chi tiết hóa đơn, hủy thao tác xóa hóa đơn.");
                return false;
            }
        }

        public DataTable TimKiemHoaDon(string keyword, string month, string year)
        {
            return dalHDN.TimKiemHoaDon(keyword, month, year);
        }

        public string TaoMaHoaDon()
        {
            int stt = dalHDN.LaySoThuTuHoaDonTrongNgay();
            string ngayHienTai = DateTime.Now.ToString("ddMMyyyy");
            return $"HDN{stt:D5}{ngayHienTai}";
        }

        public bool ThemHoaDon(DTO_HoaDonNhap hd)
        {
            return dalHDN.ThemHoaDon(hd);
        }

        public string LaySoHDNCuoi()
        {
            return dalHDN.LaySoHDNCuoi();
        }

        // Phương thức lấy thông tin hóa đơn
        public DTO_HoaDonNhap LayThongTinHoaDon(string soHDN)
        {
            return dalHDN.LayThongTinHoaDon(soHDN);
        }

        // Phương thức in danh sách hóa đơn ra Excel

        public void InDanhSachHoaDon(DataTable dtHDN)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage excel = new ExcelPackage())
                {
                    var workSheet = excel.Workbook.Worksheets.Add("Danh Sách Hóa Đơn Nhập");

                    // Thông tin cửa hàng
                    workSheet.Cells[1, 1].Value = "Cửa hàng Đồ Gốm CNTT4K63";
                    workSheet.Cells[2, 1].Value = "Địa chỉ: Số 3 đường Cầu Giấy, Đống Đa, Hà Nội";
                    workSheet.Cells[3, 1].Value = "SĐT: 0123 456 789";

                    // Gộp các ô thông tin
                    workSheet.Cells[1, 1, 1, 6].Merge = true; // Gộp dòng tiêu đề "Cửa hàng"
                    workSheet.Cells[2, 1, 2, 6].Merge = true; // Gộp dòng "Địa chỉ"
                    workSheet.Cells[3, 1, 3, 6].Merge = true; // Gộp dòng "SĐT"

                    // Căn giữa và định dạng
                    for (int row = 1; row <= 3; row++)
                    {
                        workSheet.Cells[row, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        workSheet.Cells[row, 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        workSheet.Cells[row, 1].Style.Font.Size = 14; // Kích thước chữ
                        workSheet.Cells[row, 1].Style.Font.Bold = true; // In đậm
                    }

                    // Tiêu đề lớn
                    workSheet.Cells[5, 1].Value = "DANH SÁCH HÓA ĐƠN NHẬP";
                    workSheet.Cells[5, 1, 5, 6].Merge = true; // Gộp ô
                    workSheet.Cells[5, 1, 5, 6].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    workSheet.Cells[5, 1, 5, 6].Style.Font.Size = 16;
                    workSheet.Cells[5, 1, 5, 6].Style.Font.Bold = true;

                    // Đặt tiêu đề cột
                    var headers = new[] { "SoHDN", "NgayNhap", "MaNV", "MaNCC", "TongTien" }; // Tên cột đúng
                    var displayHeaders = new[] { "Số HDN", "Ngày Nhập", "Mã NV", "Mã NCC", "Tổng Tiền" }; // Tên cột hiển thị

                    for (int col = 1; col <= displayHeaders.Length; col++)
                    {
                        workSheet.Cells[7, col].Value = displayHeaders[col - 1];
                        workSheet.Cells[7, col].Style.Font.Bold = true;
                        workSheet.Cells[7, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        workSheet.Cells[7, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    }

                    // Ghi dữ liệu vào worksheet
                    for (int i = 0; i < dtHDN.Rows.Count; i++)
                    {
                        for (int j = 0; j < headers.Length; j++)
                        {
                            // Kiểm tra cột tồn tại
                            if (dtHDN.Columns.Contains(headers[j]))
                            {
                                workSheet.Cells[i + 8, j + 1].Value = dtHDN.Rows[i][headers[j]];
                                workSheet.Cells[i + 8, j + 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                workSheet.Cells[i + 8, j + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                            }
                        }
                    }

                    // Căn chỉnh kích thước cột
                    workSheet.Cells.AutoFitColumns();

                    // Footer: Người tạo báo cáo
                    int lastRow = dtHDN.Rows.Count + 9;

                    // Dòng 1: Người tạo báo cáo
                    workSheet.Cells[lastRow, 1].Value = "Người tạo báo cáo:";
                    workSheet.Cells[lastRow, 1, lastRow, 3].Merge = true; // Gộp ô dòng này
                    workSheet.Cells[lastRow, 1, lastRow, 3].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    workSheet.Cells[lastRow, 1, lastRow, 3].Style.Font.Italic = true; // In nghiêng
                    workSheet.Cells[lastRow, 1, lastRow, 3].Style.Font.Size = 12; // Kích thước chữ

                    // Dòng 2: Ký và ghi rõ họ tên
                    workSheet.Cells[lastRow + 1, 1].Value = "(Ký và ghi rõ họ tên)";
                    workSheet.Cells[lastRow + 1, 1, lastRow + 1, 3].Merge = true; // Gộp ô dòng này
                    workSheet.Cells[lastRow + 1, 1, lastRow + 1, 3].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    workSheet.Cells[lastRow + 1, 1, lastRow + 1, 3].Style.Font.Italic = true; // In nghiêng
                    workSheet.Cells[lastRow + 1, 1, lastRow + 1, 3].Style.Font.Size = 12; // Kích thước chữ

                    // Lưu file Excel
                    var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"DanhSachHoaDonNhap_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
                    FileInfo excelFile = new FileInfo(filePath);
                    excel.SaveAs(excelFile);

                    // Thông báo cho người dùng
                    Console.WriteLine("Đã in danh sách hóa đơn nhập ra file Excel tại: " + filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }
        }


    }
}
