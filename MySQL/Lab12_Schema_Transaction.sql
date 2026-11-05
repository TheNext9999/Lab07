USE QLSinhVien;

-- Tắt tạm thời Safe Update Mode
SET SQL_SAFE_UPDATES = 0;

-- 1. Bảng Học Phần (HocPhan)
CREATE TABLE IF NOT EXISTS HocPhan (
    MaHP VARCHAR(10) PRIMARY KEY,
    TenHP VARCHAR(100) NOT NULL,
    SoTinChi INT NOT NULL CHECK (SoTinChi > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 2. Bảng Đăng Ký Học Phần (DangKy)
CREATE TABLE IF NOT EXISTS DangKy (
    MaSV VARCHAR(15) NOT NULL,
    MaHP VARCHAR(10) NOT NULL,
    HocKy INT NOT NULL,
    Diem DECIMAL(4,2) DEFAULT NULL,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY (MaSV, MaHP, HocKy),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV) ON DELETE CASCADE,
    FOREIGN KEY (MaHP) REFERENCES HocPhan(MaHP) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 3. Bảng Lịch Sử Chuyển Khoa (LichSuChuyenKhoa) - Bài 6
CREATE TABLE IF NOT EXISTS LichSuChuyenKhoa (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    MaSV VARCHAR(15) NOT NULL,
    MaKhoaCu VARCHAR(10) NOT NULL,
    MaKhoaMoi VARCHAR(10) NOT NULL,
    NgayChuyen DATETIME DEFAULT CURRENT_TIMESTAMP,
    LyDo VARCHAR(255)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 4. Thêm dữ liệu thử nghiệm cho Học Phần
INSERT IGNORE INTO HocPhan (MaHP, TenHP, SoTinChi) VALUES
('IT3212', 'Lập trình .NET', 3),
('IT3100', 'Cơ sở dữ liệu MySQL', 3),
('IT3200', 'Phân tích & Thiết kế hệ thống', 4),
('IT3300', 'Lập trình Web nâng cao', 3);

-- 5. Thêm dữ liệu đăng ký ban đầu
INSERT IGNORE INTO DangKy (MaSV, MaHP, HocKy, Diem) VALUES
('SV001', 'IT3212', 1, 8.5),
('SV001', 'IT3100', 1, 9.0),
('SV002', 'IT3212', 1, 7.0);

SET SQL_SAFE_UPDATES = 1;