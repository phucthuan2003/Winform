using DAL_QuanLy;
using DTO_QuanLy;
using System.Data;
using System;
using System.Collections.Generic;
using OfficeOpenXml;
using System.IO;

namespace BUS_QuanLy
{
    public class BUS_HoaDonBan
    {
        DAL_HoaDonBan dalHDB = new DAL_HoaDonBan();
        DAL_ChiTietHoaDonBan dalCT = new DAL_ChiTietHoaDonBan();

        // Phương thức lấy toàn bộ danh sách hóa đơn bán
        public DataTable LayDanhSachHoaDonBan()
        {
            return dalHDB.LayDanhSachHoaDonBan();
        }

        // Phương thức xóa hóa đơn bán (DONE)
        public bool XoaHoaDon(string soHDB)
        {
            // Đầu tiên, xóa các chi tiết hóa đơn liên quan
            bool xoaChiTietThanhCong = dalCT.XoaChiTietHoaDonTheoSoHDB(soHDB);

            if (xoaChiTietThanhCong)
            {
                // Nếu xóa chi tiết thành công, tiếp tục xóa hóa đơn
                return dalHDB.XoaHoaDonBan(soHDB);
            }
            else
            {
                Console.WriteLine("Không thể xóa chi tiết hóa đơn, hủy thao tác xóa hóa đơn.");
                return false;
            }
        }

        public DataTable TimKiemHoaDon(string keyword, string month, string year)
        {
            return dalHDB.TimKiemHoaDon(keyword, month, year);
        }

        public string TaoMaHoaDon()
        {
            int stt = dalHDB.LaySoThuTuHoaDonTrongNgay();
            string ngayHienTai = DateTime.Now.ToString("ddMMyyyy");
            return $"HDB{stt:D5}{ngayHienTai}"; // Tạo mã hóa đơn với định dạng HDBxxxxxDDMMYYYY
        }

        public void ThemHoaDon(DTO_HoaDonBan hd)
        {
            dalHDB.ThemHoaDon(hd);
        }

        public string LaySoHDBCuoi()
        {
            return dalHDB.LaySoHDBCuoi();
        }

        // Phương thức lấy thông tin hóa đơn
        public DTO_HoaDonBan LayThongTinHoaDon(string soHDB)
        {
            return dalHDB.LayThongTinHoaDon(soHDB);
        }

        // Phương thức in danh sách hóa đơn ra Excel

        public void InDanhSachHoaDon(DataTable dtHDB)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage excel = new ExcelPackage())
                {
                    var workSheet = excel.Workbook.Worksheets.Add("Danh Sách Hóa Đơn");

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

                    // Tự động điều chỉnh chiều cao các dòng
                    workSheet.Row(1).Height = 20; // Chiều cao dòng tiêu đề "Cửa hàng"
                    workSheet.Row(2).Height = 20; // Chiều cao dòng "Địa chỉ"
                    workSheet.Row(3).Height = 20; // Chiều cao dòng "SĐT"


                    // Tiêu đề lớn
                    workSheet.Cells[5, 1].Value = "DANH SÁCH HÓA ĐƠN BÁN";
                    workSheet.Cells[5, 1, 5, 6].Merge = true; // Gộp ô
                    workSheet.Cells[5, 1, 5, 6].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    workSheet.Cells[5, 1, 5, 6].Style.Font.Size = 16;
                    workSheet.Cells[5, 1, 5, 6].Style.Font.Bold = true;

                    // Đặt tiêu đề cột
                    var headers = new[] { "SoHDB", "NgayBan", "MaNV", "MaKhach", "GiamGia", "TongTien" }; // Tên cột đúng
                    var displayHeaders = new[] { "Số HDB", "Ngày Bán", "Mã NV", "Mã Khách", "Giảm Giá", "Tổng Tiền" }; // Tên cột hiển thị

                    for (int col = 1; col <= displayHeaders.Length; col++)
                    {
                        workSheet.Cells[7, col].Value = displayHeaders[col - 1];
                        workSheet.Cells[7, col].Style.Font.Bold = true;
                        workSheet.Cells[7, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        workSheet.Cells[7, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    }

                    // Ghi dữ liệu vào worksheet
                    for (int i = 0; i < dtHDB.Rows.Count; i++)
                    {
                        for (int j = 0; j < headers.Length; j++)
                        {
                            // Kiểm tra cột tồn tại
                            if (dtHDB.Columns.Contains(headers[j]))
                            {
                                workSheet.Cells[i + 8, j + 1].Value = dtHDB.Rows[i][headers[j]];
                                workSheet.Cells[i + 8, j + 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                workSheet.Cells[i + 8, j + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                            }
                        }
                    }

                    // Căn chỉnh kích thước cột
                    workSheet.Cells.AutoFitColumns();

                    // Footer: Người tạo báo cáo
                    int lastRow = dtHDB.Rows.Count + 9;

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
                    var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"DanhSachHoaDon_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
                    FileInfo excelFile = new FileInfo(filePath);
                    excel.SaveAs(excelFile);

                    // Thông báo cho người dùng
                    Console.WriteLine("Đã in danh sách hóa đơn ra file Excel tại: " + filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

    }
}