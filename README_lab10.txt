====================================================================
BÁO CÁO BÀI TẬP LAB 10: DATAADAPTER, DATATABLE, DATASET VÀ DỮ LIỆU NGẮT KẾT NỐI
====================================================================

1. THÔNG TIN HỆ THỐNG
---------------------
- DBMS: MySQL Server 8.0 / MySQL Workbench
- Database Name: QLSinhVien
- Visual Studio: 2022 (.NET Framework 4.8 / C#)
- Project Name: Lab10_DisconnectedData

2. HƯỚNG DẪN CHẠY CHƯƠNG TRÌNH
-----------------------------
Bước 1: Đảm bảo MySQL Server đang chạy và CSDL 'QLSinhVien' đã sẵn sàng.
Bước 2: Mở Solution trong Visual Studio 2022 và chọn Form khởi chạy 'frmLab10'.
Bước 3: Nhấn F5 để khởi chạy giao diện thử nghiệm.

3. KẾT QUẢ NGHIỆM THU 10 BÀI TẬP LAB 10
----------------------------------------
[x] Bài 1: Fill DataTable ngắt kết nối bằng MySqlDataAdapter.
[x] Bài 2: DataSet chứa nhiều bảng (Khoa & SinhVien).
[x] Bài 3: Thiết lập DataRelation FK_Khoa_SinhVien & lấy các dòng con GetChildRows().
[x] Bài 4: Lọc RowFilter và Sắp xếp trong bộ nhớ bằng DataView mà không gửi SQL tới Server.
[x] Bài 5: Chỉnh sửa dữ liệu trực tiếp trên DataGridView & Lưu về CSDL bằng MySqlCommandBuilder.
[x] Bài 6: Tạo DataTable thủ công & Cột tính toán Xếp Loại bằng Expression.
[x] Bài 7: Theo dõi trạng thái từng dòng DataRowState (Added, Modified, Deleted) & GetChanges().
[x] Bài 8: Quản lý thay đổi cục bộ bằng AcceptChanges() và RejectChanges().
[x] Bài 9: Ghi và Đọc DataSet offline ra tệp XML Schema (WriteXml & ReadXml).
[x] Bài 10: Hợp nhất 2 bảng dữ liệu trùng/khác khóa bằng DataTable.Merge().