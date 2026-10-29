====================================================================
BÁO CÁO BÀI TẬP LAB 08: SQLCOMMAND, SQLPARAMETER VÀ CÁC PHƯƠNG THỨC THỰC THI
====================================================================

1. THÔNG TIN HỆ THỐNG & CSDL MYSQL
----------------------------------
- Môi trường: Visual Studio 2022 (.NET Framework 4.8)
- Thư viện kết nối: MySql.Data 9.x (Oracle)
- DBMS: MySQL Server 8.0.43 / MySQL Workbench 8.0
- Database Name: QLSinhVien
- Host / Port: localhost:3306
- Chuỗi kết nối Root: Server=localhost;Port=3306;Database=QLSinhVien;Uid=root;Pwd=HoChiMinh1890;CharSet=utf8;
- Chuỗi kết nối AppUser: Server=localhost;Port=3306;Database=QLSinhVien;Uid=QLSV_AppUser;Pwd=Eaut@2026Secure;CharSet=utf8;

2. HƯỚNG DẪN CẤU HÌNH VÀ CHẠY DỰ ÁN
-----------------------------------
Bước 1: Mở MySQL Workbench, tạo một Query Tab mới và chạy toàn bộ script khởi tạo CSDL 'QLSinhVien' kèm 2 Stored Procedures:
        + sp_SinhVien_TheoKhoa
        + sp_ThemSinhVien_DemSoLuong
Bước 2: Mở Solution 'Lab07_ADONET_Connection.sln' bằng Visual Studio 2022.
Bước 3: Mở file 'App.config' và đảm bảo mật khẩu root khớp với mật khẩu MySQL trên máy bạn (nếu có thay đổi).
Bước 4: Mở tệp 'Program.cs', đảm bảo Form khởi chạy là 'frmLab08':
        Application.Run(new Lab07_ADONET_Connection.GUI.frmLab08());
Bước 5: Nhấn Ctrl + Shift + B để Build Solution, sau đó nhấn F5 để chạy chương trình.

3. DANH SÁCH 10 BÀI TẬP ĐÃ HOÀN THÀNH
--------------------------------------
[x] Bài 1: Đếm số sinh viên bằng ExecuteScalar (Hiển thị Label)
[x] Bài 2: Đọc danh sách sinh viên bằng ExecuteReader (Hiển thị ListBox)
[x] Bài 3: Thêm sinh viên bằng ExecuteNonQuery kết hợp MySqlParameter
[x] Bài 4: Cập nhật điểm sinh viên bằng câu SQL tham số hóa
[x] Bài 5: Gọi Stored Procedure 'sp_SinhVien_TheoKhoa'
[x] Bài 6: Tìm kiếm sinh viên theo Mã sinh viên (ExecuteReader)
[x] Bài 7: Thống kê điểm TB cao nhất theo Khoa (Xử lý DBNull.Value)
[x] Bài 8: Xóa sinh viên có hộp thoại xác nhận và bắt lỗi khóa ngoại (ErrorCode 1451)
[x] Bài 9: Gọi Stored Procedure 'sp_ThemSinhVien_DemSoLuong' nhận tham số đầu ra (OUTPUT)
[x] Bài 10: Xây dựng Lớp dùng chung MySqlHelper (ExecuteScalar, ExecuteNonQuery, ExecuteQuery)
====================================================================