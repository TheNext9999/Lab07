====================================================================
BÁO CÁO BÀI TẬP LAB 09: ĐỌC, TÌM KIẾM VÀ LỌC DỮ LIỆU BẰNG MYSQLDATAREADER
====================================================================

1. THÔNG TIN HỆ THỐNG
---------------------
- DBMS: MySQL Server 8.0 / MySQL Workbench
- Database Name: QLSinhVien
- Visual Studio: 2022 (.NET Framework 4.8 / C#)
- Project Name: Lab09_DataReaderSearch

2. HƯỚNG DẪN CHẠY CHƯƠNG TRÌNH
-----------------------------
Bước 1: Đảm bảo MySQL Server đang chạy và CSDL 'QLSinhVien' đã được bổ sung đủ dữ liệu thử nghiệm.
Bước 2: Mở dự án trong Visual Studio 2022.
Bước 3: Nhấn F5 để khởi chạy Form 'frmLab09'.

3. KẾT QUẢ NGHIỆM THU 10 BÀI TẬP LAB 09
----------------------------------------
[x] Bài 1: Nạp MySqlDataReader vào DataTable hiển thị DataGridView.
[x] Bài 2: Tìm kiếm gần đúng theo Họ tên (LIKE @Keyword).
[x] Bài 3: Lọc theo Khoa và Khoảng điểm (BETWEEN @Min AND @Max).
[x] Bài 4: Phân trang Server-side bằng MySQL (LIMIT @PageSize OFFSET @Offset).
[x] Bài 5: Đồng bộ dòng chọn SelectionChanged với Vùng chi tiết & StatusStrip.
[x] Bài 6: Tìm kiếm đa tiêu chí linh hoạt (kết hợp Mã SV, Họ tên, Khoa, Giới tính, Điểm).
[x] Bài 7: Sắp xếp động an toàn theo Cột và Chiều (ASC/DESC chống SQL Injection).
[x] Bài 8: Lọc theo Khoảng tuổi (dùng TIMESTAMPDIFF của MySQL).
[x] Bài 9: Định dạng & Tô màu điều kiện DataGridView (Đỏ: <5, Xanh: >=8).
[x] Bài 10: Xuất kết quả đang hiển thị ra tệp CSV hỗ trợ UTF-8 BOM tiếng Việt.