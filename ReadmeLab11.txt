====================================================================
BÁO CÁO BÀI TẬP LAB 11: CRUD THAM SỐ HÓA VÀ STORED PROCEDURE
====================================================================

1. THÔNG TIN HỆ THỐNG
---------------------
- DBMS: MySQL Server 8.0 & Stored Procedures
- Project Name: Lab11_CRUD_StoredProcedure (Kiến trúc DTO - DAL - BUS - GUI)

2. HƯỚNG DẪN CHẠY
-----------------
Bước 1: Thực thi script 'Lab11_StoredProcedures.sql' trong MySQL Workbench.
Bước 2: Mở Solution Visual Studio 2022, chọn Form khởi chạy 'frmLab11'.
Bước 3: Nhấn F5 để trải nghiệm giao diện quản lý.

3. KẾT QUẢ NGHIỆM THU 10 BÀI TẬP LAB 11
----------------------------------------
[x] Bài 1: Stored Procedure thêm sinh viên sp_SinhVien_Insert với SIGNAL SQLSTATE.
[x] Bài 2: Stored Procedure cập nhật & xóa sp_SinhVien_Update, sp_SinhVien_Delete.
[x] Bài 3: Tầng DAL gọi Stored Procedure bằng MySqlCommand & CommandType.StoredProcedure.
[x] Bài 4: Tầng BUS kiểm tra nghiệp vụ (Mã, Họ tên, Tuổi >= 15, Điểm [0, 10], Format Email).
[x] Bài 5: Kết nối các nút Thêm, Sửa, Xóa, Làm mới trên giao diện WinForms.
[x] Bài 6: CRUD bảng Khoa & ràng buộc không cho xóa Khoa đang chứa Sinh viên.
[x] Bài 7: Stored Procedure tìm kiếm đa tiêu chí sp_SinhVien_Search.
[x] Bài 8: Ràng buộc UNIQUE và kiểm tra trùng Email ở cả DB & tầng BUS.
[x] Bài 9: Xóa mềm Sinh viên bằng cột IsActive và Stored Procedure sp_SinhVien_SoftDelete.
[x] Bài 10: Chuẩn hóa xử lý lỗi (ArgumentException, MySqlException, Exception).