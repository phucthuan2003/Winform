CREATE DATABASE DB_LTTQ
GO
USE [DB_LTTQ]
GO


------- TẠO BẢNG
-- Kích thước
CREATE TABLE KichThuoc (
    MaKichThuoc VARCHAR(50) PRIMARY KEY,
    TenKichThuoc NVARCHAR(100) NOT NULL
);
GO

-- Loại
CREATE TABLE Loai (
    MaLoai VARCHAR(50) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL
);
GO

-- CÔNG DỤNG
CREATE TABLE CongDung (
    MaCongDung VARCHAR(50) PRIMARY KEY,
    TenCongDung NVARCHAR(100) NOT NULL
);

-- MEN
CREATE TABLE LoaiMen (
    MaLoaiMen VARCHAR(50) PRIMARY KEY,
    TenLoaiMen NVARCHAR(100) NOT NULL
);
GO

-- NƯỚC SẢN XUẤT
CREATE TABLE NuocSanXuat (
    MaNuocSX VARCHAR(50) PRIMARY KEY,
    TenNuocSX NVARCHAR(100) NOT NULL
);
GO

-- MÀU SẮC
CREATE TABLE MauSac (
    MaMau VARCHAR(50) PRIMARY KEY,
    TenMau NVARCHAR(100) NOT NULL
);
GO

-- HÌNH KHỐI
CREATE TABLE HinhKhoi (
    MaHinhKhoi VARCHAR(50) PRIMARY KEY,
    TenHinhKhoi NVARCHAR(100) NOT NULL
);
GO

-- HOA VĂN
CREATE TABLE HoaVan (
    MaHoaVan VARCHAR(50) PRIMARY KEY,
    TenHoaVan NVARCHAR(100) NOT NULL
);
GO

-- CÔNG VIỆC
CREATE TABLE CongViec (
    MaCV VARCHAR(50) PRIMARY KEY,
    TenCV NVARCHAR(100) NOT NULL,
    MucLuong DECIMAL(18, 2) NULL
);
GO

-- NHÂN VIÊN
CREATE TABLE NhanVien (
    MaNV VARCHAR(50) PRIMARY KEY,
    TenNV NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL,
    NgaySinh DATE NOT NULL,
    DienThoai VARCHAR(15) NOT NULL,
    DiaChi NVARCHAR(255) NOT NULL,
    MaCV VARCHAR(50),
    SoNgayPhep INT NOT NULL DEFAULT 0,
    SoNgayNghi INT NOT NULL DEFAULT 0,
    NgayTuyen DATE NOT NULL,
    FOREIGN KEY (MaCV) REFERENCES CongViec(MaCV) 
);
GO

-- TÀI KHOẢN
CREATE TABLE TaiKhoan (
    MaTK VARCHAR(50) PRIMARY KEY,
    MaNV VARCHAR(50),
    TenDangNhap NVARCHAR(50) NOT NULL,
    MatKhau NVARCHAR(255) NOT NULL, -- Nên mã hóa mật khẩu
    QuyenHan NVARCHAR(50) NOT NULL,
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- KHÁCH HÀNG
CREATE TABLE KhachHang (
    MaKhach VARCHAR(50) PRIMARY KEY,
    TenKhach NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(255) NOT NULL,
    DienThoai VARCHAR(15) NOT NULL
);
GO

-- NHÀ CUNG CẤP
CREATE TABLE NhaCungCap (
    MaNCC VARCHAR(50) PRIMARY KEY,
    TenNCC NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(255) NOT NULL,
    DienThoai VARCHAR(15) NOT NULL
);
GO

-- DM HÀNG HÓA
CREATE TABLE HangHoa (
    MaHang VARCHAR(50) PRIMARY KEY,
    TenHang NVARCHAR(100) NOT NULL,
    MaLoai VARCHAR(50),
    MaKichThuoc VARCHAR(50),
    MaCongDung VARCHAR(50),
    MaLoaiMen VARCHAR(50),
    MaHinhKhoi VARCHAR(50),
    MaHoaVan VARCHAR(50),
    MaMau VARCHAR(50),
    MaNuocSX VARCHAR(50),
    SoLuong INT NOT NULL,
    DonGiaNhap DECIMAL(18, 2) NOT NULL,
    DonGiaBan DECIMAL(18, 2) NOT NULL,
    Anh NVARCHAR(255), -- đường dẫn ảnh
    GhiChu NVARCHAR(255),
    FOREIGN KEY (MaLoai) REFERENCES Loai(MaLoai),
    FOREIGN KEY (MaKichThuoc) REFERENCES KichThuoc(MaKichThuoc),
    FOREIGN KEY (MaCongDung) REFERENCES CongDung(MaCongDung),
    FOREIGN KEY (MaLoaiMen) REFERENCES LoaiMen(MaLoaiMen),
    FOREIGN KEY (MaHinhKhoi) REFERENCES HinhKhoi(MaHinhKhoi),
    FOREIGN KEY (MaHoaVan) REFERENCES HoaVan(MaHoaVan),
    FOREIGN KEY (MaMau) REFERENCES MauSac(MaMau),
    FOREIGN KEY (MaNuocSX) REFERENCES NuocSanXuat(MaNuocSX)
);
GO

-- HÓA ĐƠN BÁN
CREATE TABLE HoaDonBan (
    SoHDB VARCHAR(50) PRIMARY KEY,
    MaNV VARCHAR(50),
    NgayBan DATE NOT NULL,
    MaKhach VARCHAR(50),
    TongTien DECIMAL(18, 2) NOT NULL,
    GiamGia DECIMAL(18, 2) NULL,
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV), 
    FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach) 
);
GO

-- CT HDB
CREATE TABLE ChiTietHoaDonBan (
    SoHDB VARCHAR(50),
    MaHang VARCHAR(50),
    SoLuong INT NOT NULL,
    GiamGia DECIMAL(18, 2) NULL,
    DonGiaBan DECIMAL(18, 2) NOT NULL, -- Thêm cột này
    ThanhTien AS (SoLuong * DonGiaBan * (1 - (ISNULL(GiamGia, 0) / 100))) PERSISTED, -- Sử dụng ISNULL để xử lý giá trị NULL
    PRIMARY KEY (SoHDB, MaHang),
    FOREIGN KEY (SoHDB) REFERENCES HoaDonBan(SoHDB),
    FOREIGN KEY (MaHang) REFERENCES HangHoa(MaHang)
);
GO

-- HDN
CREATE TABLE HoaDonNhap (
    SoHDN VARCHAR(50) PRIMARY KEY,
    MaNV VARCHAR(50),
    NgayNhap DATE NOT NULL,
    MaNCC VARCHAR(50), -- Mã nhà cung cấp
    TongTien DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV), 
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC) 
);
GO

-- CT HDN
CREATE TABLE ChiTietHoaDonNhap (
    SoHDN VARCHAR(50),
    MaHang VARCHAR(50),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18, 2) NOT NULL,
    ThanhTien AS (SoLuong * DonGia) PERSISTED, 
    PRIMARY KEY (SoHDN, MaHang),
    FOREIGN KEY (SoHDN) REFERENCES HoaDonNhap(SoHDN),
    FOREIGN KEY (MaHang) REFERENCES HangHoa(MaHang)
);
GO


--- THÊM DỮ LIỆU
-- Kích thước
INSERT INTO KichThuoc (MaKichThuoc, TenKichThuoc) VALUES 
('KT01', N'Nhỏ'),
('KT02', N'Vừa'),
('KT03', N'Lớn');
GO

-- Loại
INSERT INTO Loai (MaLoai, TenLoai) VALUES 
('LO01', N'ĐỒ THỜ BÁT TRÀNG'),
('LO02', N'QUÀ TẶNG GỐM SỨ'),
('LO03', N'BÌNH HÚT TÀI LỘC'),
('LO04', N'ẤM CHÉN BÁT TRÀNG'),
('LO05', N'GỐM SỨ GIA DỤNG'),
('LO06', N'BÁT ĐĨA BÁT TRÀNG'),
('LO07', N'ĐỒ GỐM TRANG TRÍ');
GO

-- Công dụng
INSERT INTO CongDung (MaCongDung, TenCongDung) VALUES 
('CD01', N'Thờ cúng'),
('CD02', N'Phong thủy và trang trí'),
('CD03', N'Gia dụng và tiêu dùng hàng ngày'),
('CD04', N'Quà tặng');
GO

-- MEN
INSERT INTO LoaiMen (MaLoaiMen, TenLoaiMen) VALUES 
('MM01', N'Men lam'),
('MM02', N'Men trắng ngọc'),
('MM03', N'Men rạn'),
('MM04', N'Men nâu'),
('MM05', N'Men rêu xanh'),
('MM06', N'Men hỏa biến');
GO

-- NƯỚC SX
INSERT INTO NuocSanXuat (MaNuocSX, TenNuocSX) VALUES 
('NSX01', N'Việt Nam'),
('NSX02', N'Trung Quốc'),
('NSX03', N'Nhật Bản');
GO

-- MÀU
INSERT INTO MauSac(MaMau, TenMau) VALUES 
('MA01', N'Trắng'),
('MA02', N'Xanh'),
('MA03', N'Đỏ'),
('MA04', N'Vàng');
GO

-- HÌNH KHỐI
INSERT INTO HinhKhoi (MaHinhKhoi, TenHinhKhoi) VALUES 
('HK01', N'Trụ tròn'),
('HK02', N'Vuông'),
('HK03', N'Chữ nhật');
GO

-- HOA VĂN
INSERT INTO HoaVan (MaHoaVan, TenHoaVan) VALUES 
('HV01', N'Hoa sen'),
('HV02', N'Hoa cúc'),
('HV03', N'Hoa mai'),
('HV04', N'Hoa đào'),
('HV05', N'Long phụng'),
('HV06', N'Phúc lộc thọ'),
('HV07', N'Hoa văn Rồng'),
('HV08', N'Hoa văn Chim hạc'),
('HV09', N'Hoa văn Tứ quý (Tùng, Cúc, Trúc, Mai)'),
('HV10', N'Hoa văn Sóng nước'),
('HV11', N'Hoa văn Gấm hoa'),
('HV12', N'Hoa văn Lưỡng long chầu nguyệt'),
('HV13', N'Hoa văn Mây'),
('HV14', N'Hoa văn Trúc lâm'),
('HV15', N'Hoa văn Khổng Tước (Chim công)');
GO

-- CÔNG VIỆC
INSERT INTO CongViec (MaCV, TenCV, MucLuong) VALUES 
('CV01', N'Bán hàng', 7000000),
('CV02', N'Quản lý kho', 12000000),
('CV03', N'Tạp vụ', 8000000),
('CV04', N'Admin', null);
GO

-- NHÂN VIÊN
INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, NgaySinh, DienThoai, DiaChi, MaCV, SoNgayPhep, SoNgayNghi, NgayTuyen) VALUES 
('NV01', N'Nguyễn Văn A', N'Nam', CONVERT(DATE, '15/01/1990', 103), '0901234567', N'123 Đường 1, Hà Nội', 'CV04', 5, 2, CONVERT(DATE, '01/05/2020', 103)),
('NV02', N'Trần Thị B', N'Nữ', CONVERT(DATE, '20/03/1995',103), '0907654321', N'456 Đường 2, Đà Nẵng', 'CV02', 5, 3, CONVERT(DATE, '15/06/2021', 103)),
('NV03', 'Lê Văn C', 'Nam', CONVERT(DATE, '11/10/1996', 103), '0912345678', N'789 Đường 3, Hồ Chí Minh', 'CV01', 5, 1, CONVERT(DATE, '20/02/2019', 103)),
('NV04', 'Phạm Thị D', 'Nữ', CONVERT(DATE, '10/09/2004', 103), '0987654321', N'321 Đường 4, Hải Phòng', 'CV03', 5, 0, CONVERT(DATE, '10/01/2022', 103));
GO

-- TÀI KHOẢN
INSERT INTO TaiKhoan (MaTK, MaNV, TenDangNhap, MatKhau, QuyenHan) VALUES 
('TK01', 'NV01', 'le_d', 'pass123', 'Admin'),
('TK02', 'NV02', 'nguyen_e', 'pass456', 'NhanVien');
GO
-- KHÁCH HÀNG
INSERT INTO KhachHang (MaKhach, TenKhach, DiaChi, DienThoai) VALUES 
('KH01', N'Nguyễn Văn A', N'123 Lê Lợi, Hà Nội', '0912345678'),
('KH02', N'Trần Thị B', N'45 Trần Hưng Đạo, HCM', '0987654321'),
('KH03', N'Phạm Văn C', N'78 Nguyễn Huệ, Đà Nẵng', '0908765432');
GO
--NHÀ CUNG CẤP
INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, DienThoai) VALUES 
('NCC01', N'Công ty A', N'12 Hai Bà Trưng', '0911223344'),
('NCC02', N'Công ty B', N'56 Nguyễn Du', '0922334455'),
('NCC03', N'Công ty C', N'89 Trần Phú', '0933445566');
GO

-- DM HÀNG HÓA
INSERT INTO HangHoa (MaHang, TenHang, MaLoai, MaKichThuoc, MaCongDung, MaLoaiMen, MaHinhKhoi, MaMau, MaNuocSX, SoLuong, DonGiaNhap, DonGiaBan, Anh, GhiChu)
VALUES 
    ('MH01', N'Bình hoa sen', 'LO01', 'KT02', 'CD02', 'MM01', 'HK01', 'MA01', 'NSX01', 100, 200000, 250000, 'sen.jpg', N'Bình trang trí');
GO

-- HÓA ĐƠN BÁN
INSERT INTO HoaDonBan (SoHDB, MaNV, NgayBan, MaKhach, TongTien, GiamGia) VALUES 
('HDB001', 'NV01', CONVERT(DATE, '01/10/2024', 103), 'KH01', 270000, 30000);
GO

-- CT HDB
INSERT INTO ChiTietHoaDonBan (SoHDB, MaHang, SoLuong, DonGiaBan, GiamGia) VALUES 
('HDB001', 'MH01', 2, 150000, 10);
GO

-- HDN
INSERT INTO HoaDonNhap (SoHDN, MaNV, NgayNhap, MaNCC, TongTien) VALUES 
('HDN001', 'NV01', CONVERT(DATE, '01/10/2024', 103), 'NCC01', 500000),
('HDN002', 'NV02', CONVERT(DATE, '05/10/2024', 103), 'NCC02', 750000),
('HDN003', 'NV03', CONVERT(DATE, '07/10/2024', 103), 'NCC01', 600000);

GO

-- CT HDN
INSERT INTO ChiTietHoaDonNhap (SoHDN, MaHang, SoLuong, DonGia) VALUES 
('HDN001', 'MH01', 5, 100000);
GO

--SELECT * FROM NhanVien
--inner join CongViec on NhanVien.MaCV = CongViec.MaCV
--where MucLuong IS NULL;
--GO

--SELECT 
--    L.TenLoai AS Loai,
--    SUM(HH.SoLuong) AS TongSoLuong
--FROM HangHoa HH
--JOIN Loai L ON HH.MaLoai = L.MaLoai
--GROUP BY L.TenLoai;

--SELECT 
--    HH.MaHang,
--    HH.TenHang,
--    L.TenLoai AS Loai,
--    CD.TenCongDung AS CongDung,
--    HV.TenHoaVan AS HoaVan,
--    MS.TenMau AS MauSac,
--    NSX.TenNuocSX AS NuocSanXuat,
--    HH.SoLuong,
--    HH.DonGiaNhap,
--    HH.DonGiaBan,
--    HH.Anh,
--    HH.GhiChu
--FROM HangHoa HH
--JOIN Loai L ON HH.MaLoai = L.MaLoai
--JOIN CongDung CD ON HH.MaCongDung = CD.MaCongDung
--JOIN HoaVan HV ON HH.MaHoaVan = HV.MaHoaVan
--JOIN MauSac MS ON HH.MaMau = MS.MaMau
--JOIN NuocSanXuat NSX ON HH.MaNuocSX = NSX.MaNuocSX;

--SELECT 
--    HH.MaHang,
--    HH.TenHang,
--    CD.TenCongDung AS CongDung
--FROM HangHoa HH
--INNER JOIN CongDung CD ON HH.MaCongDung = CD.MaCongDung
--WHERE CD.TenCongDung = 'Phong thủy và trang trí';





