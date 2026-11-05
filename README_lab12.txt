====================================================================
BÁO CÁO BÀI TẬP LAB 12: MASTER-DETAIL, TRANSACTION VÀ HOÀN THIỆN MÔ HÌNH 3 LỚP
====================================================================

1. THÔNG TIN HỆ THỐNG
---------------------
- DBMS: MySQL Server 8.0 & MySqlTransaction
- Visual Studio: 2022 (.NET Framework 4.8 / C#)
- Project Name: Lab12_MasterDetail_Transaction (Kiến trúc DTO - DAL - BUS - GUI)

2. HƯỚNG DẪN CHẠY DỰ ÁN
-----------------------
Bước 1: Mở MySQL Workbench và thực thi tệp 'Lab12_Schema_Transaction.sql' để tạo các bảng HocPhan, DangKy, LichSuChuyenKhoa.
Bước 2: Mở Solution Visual Studio 2022 và chọn Form chạy mặc định 'frmLab12'.
Bước 3: Nhấn F5 để khởi chạy ứng dụng.

3. KẾT QUẢ NGHIỆM THU 10 BÀI TẬP LAB 12
----------------------------------------
[x] Bài 1: Giao diện Master-Detail Khoa - SinhVien (dgvKhoa_SelectionChanged).
[x] Bài 2: Master-Detail SinhVien - DangKy HocPhan (JOIN DangKy với HocPhan).
[x] Bài 3: Thêm SinhVien + Đăng ký học phần ban đầu trong 1 MySqlTransaction.
[x] Bài 4: Mô phỏng cố ý chèn mã môn sai và kiểm chứng ROLLBACK 100% dữ liệu.
[x] Bài 5: Truyền MySqlConnection và MySqlTransaction qua các phương thức DAL.
[x] Bài 6: Chuyển sinh viên sang khoa mới & Ghi nhật ký vào LichSuChuyenKhoa bằng Transaction.
[x] Bài 7: Xóa khoa an toàn (Transaction cascade/reassign dữ liệu liên quan).
[x] Bài 8: Cập nhật điểm hàng loạt (Batch Update) trong Transaction (Rollback nếu có điểm ngoài [0,10]).
[x] Bài 9: Kiểm soát xung đột cập nhật đồng thời (Optimistic Concurrency Control với Timestamp).
[x] Bài 10: Hoàn thiện mô hình 3 lớp tổng hợp kết nối 4 bảng CSDL QLSinhVien.