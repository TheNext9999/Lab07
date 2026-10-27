-- ============================================================================
-- PHẦN 1 & BÀI 1: TẠO VÀ CHUYỂN NGỮ CẢNH CSDL QLSinhVien
-- ============================================================================
DROP DATABASE IF EXISTS QLSinhVien;
CREATE DATABASE QLSinhVien DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE QLSinhVien;

-- ============================================================================
-- PHẦN 2, BÀI 2, BÀI 3 & BÀI 6: TẠO BẢNG VỚI RÀNG BUỘC CHUẨN MYSQL
-- ============================================================================

-- 1. Bảng Khoa
CREATE TABLE Khoa
(
    MaKhoa VARCHAR(10) PRIMARY KEY,
    TenKhoa VARCHAR(100) NOT NULL UNIQUE
) ENGINE=InnoDB;

-- 2. Bảng SinhVien (Bổ sung UNIQUE Email & CHECK Điểm)
CREATE TABLE SinhVien
(
    MaSV VARCHAR(15) PRIMARY KEY,
    HoTen VARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh TINYINT(1) NOT NULL, -- 1: Nam, 0: Nữ
    MaKhoa VARCHAR(10) NOT NULL,
    DiemTB DECIMAL(4,2) NOT NULL DEFAULT 0.00,
    Email VARCHAR(100) NULL,
    
    CONSTRAINT UQ_SinhVien_Email UNIQUE (Email),
    CONSTRAINT CK_SinhVien_Diem CHECK (DiemTB BETWEEN 0 AND 10),
    CONSTRAINT FK_SinhVien_Khoa FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa) 
        ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB;

-- 3. Bảng HocPhan
CREATE TABLE HocPhan
(
    MaHP VARCHAR(10) PRIMARY KEY,
    TenHP VARCHAR(120) NOT NULL,
    SoTinChi INT NOT NULL CONSTRAINT CK_HocPhan_STC CHECK (SoTinChi BETWEEN 1 AND 6)
) ENGINE=InnoDB;

-- 4. Bảng DangKy (DEFAULT NgayDangKy & CHECK HocKy)
CREATE TABLE DangKy
(
    MaSV VARCHAR(15) NOT NULL,
    MaHP VARCHAR(10) NOT NULL,
    HocKy INT NOT NULL,
    Diem DECIMAL(4,2) NULL,
    NgayDangKy DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP, -- Bài 6: Default thời gian
    
    PRIMARY KEY (MaSV, MaHP),
    CONSTRAINT CK_DangKy_HocKy CHECK (HocKy BETWEEN 1 AND 3),
    CONSTRAINT CK_DangKy_Diem CHECK (Diem IS NULL OR (Diem BETWEEN 0 AND 10)),
    CONSTRAINT FK_DangKy_SinhVien FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV) 
        ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT FK_DangKy_HocPhan FOREIGN KEY (MaHP) REFERENCES HocPhan(MaHP) 
        ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB;

-- ============================================================================
-- PHẦN 3 & BÀI 4: THÊM DỮ LIỆU MẪU UNICODE
-- ============================================================================

-- Chèn dữ liệu Khoa
INSERT INTO Khoa(MaKhoa, TenKhoa) VALUES
('CNTT', 'Công nghệ Thông tin'),
('OTO', 'Công nghệ Kỹ thuật Ô tô'),
('KT', 'Kinh tế');

-- Chèn dữ liệu SinhVien
INSERT INTO SinhVien(MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email) VALUES
('SV001', 'Nguyễn Văn An', '2005-02-15', 1, 'CNTT', 8.20, 'an.nv@eaut.edu.vn'),
('SV002', 'Trần Thị Bình', '2005-07-21', 0, 'CNTT', 7.40, 'binh.tt@eaut.edu.vn'),
('SV003', 'Lê Văn Cường', '2004-12-03', 1, 'OTO', 6.80, 'cuong.lv@eaut.edu.vn'),
('SV004', 'Phạm Minh Dung', '2005-05-10', 0, 'KT', 9.10, 'dung.pm@eaut.edu.vn'),
('SV005', 'Hoàng Anh Tuấn', '2004-09-18', 1, 'CNTT', 5.50, 'tuan.ha@eaut.edu.vn'),
('SV006', 'Đỗ Hải Yến', '2005-11-30', 0, 'CNTT', 8.75, 'yen.dh@eaut.edu.vn'),
('SV007', 'Vũ Quốc Anh', '2004-03-25', 1, 'OTO', 7.20, 'anh.vq@eaut.edu.vn'),
('SV008', 'Ngô Bảo Ngọc', '2005-08-14', 0, 'KT', 6.90, 'ngoc.nb@eaut.edu.vn'),
('SV009', 'Đặng Hoàng Long', '2004-01-05', 1, 'CNTT', 4.80, 'long.dh@eaut.edu.vn'),
('SV010', 'Bùi Phương Thảo', '2005-10-12', 0, 'KT', 8.00, 'thao.bp@eaut.edu.vn');

-- Chèn dữ liệu HocPhan
INSERT INTO HocPhan(MaHP, TenHP, SoTinChi) VALUES
('IT3212', 'Lập trình .NET', 3),
('IT2001', 'Cơ sở dữ liệu', 3),
('IT1002', 'Lập trình C# cơ bản', 2),
('BS1005', 'Toán cao cấp', 4),
('GE1001', 'Tiếng Anh chuyên ngành', 3);

-- Chèn dữ liệu DangKy
INSERT INTO DangKy(MaSV, MaHP, HocKy, Diem) VALUES
('SV001', 'IT3212', 1, 8.50),
('SV001', 'IT2001', 1, 8.00),
('SV002', 'IT3212', 1, 7.50),
('SV002', 'IT1002', 2, 7.00),
('SV003', 'BS1005', 1, 6.50),
('SV004', 'GE1001', 1, 9.50),
('SV005', 'IT3212', 2, 5.00),
('SV006', 'IT3212', 1, 9.00),
('SV006', 'IT2001', 1, 8.50);

-- ============================================================================
-- PHẦN 4 & BÀI 7: TẠO TÀI KHOẢN VÀ CẤP QUYỀN TRÊN MYSQL
-- ============================================================================
CREATE USER IF NOT EXISTS 'QLSV_AppUser'@'%' IDENTIFIED BY 'Eaut@2026Secure';
GRANT ALL PRIVILEGES ON QLSinhVien.* TO 'QLSV_AppUser'@'%';
FLUSH PRIVILEGES;