====================================================================
BÁO CÁO BÀI TẬP LAB 13: TẠO BÁO CÁO CƠ BẢN BẰNG CRYSTAL REPORT
====================================================================

1. THÔNG TIN HỆ THỐNG
---------------------
- DBMS: MySQL Server 8.0 & MySQL Views
- Visual Studio: 2022 (.NET Framework 4.8 / C#)
- Project Name: Lab13_CrystalReport (Kiến trúc 3 Lớp ADO.NET)

2. KẾT QUẢ NGHIỆM THU 10 BÀI TẬP LAB 13
----------------------------------------
[x] Bài 1: Kiểm tra môi trường SAP Crystal Reports & Viewer References.
[x] Bài 2: Tạo MySQL View 'vw_BaoCaoSinhVien' JOIN SinhVien và Khoa.
[x] Bài 3: Hàm BaoCaoDAL.GetStudentReportData() dùng MySqlDataAdapter nạp DataTable.
[x] Bài 4: Hiển thị báo cáo trên CrystalReportViewer & giải phóng tài nguyên OnFormClosed.
[x] Bài 5: Xuất báo cáo ra định dạng file PDF bằng ExportToDisk.
[x] Bài 6: Tạo View 'vw_BaoCaoDanhSachKhoa' thống kê số lượng sinh viên theo từng khoa.
[x] Bài 7: Định dạng báo cáo chuyên nghiệp (Tiêu đề, Header, Footer Ngày lập, Trang X/Y).
[x] Bài 8: Tạo View 'vw_BaoCaoHocPhan' làm báo cáo danh sách học phần theo tín chỉ.
[x] Bài 9: Tích hợp Menu Báo cáo trên frmMain, mở Form Singleton tránh trùng lặp.
[x] Bài 10: Kiểm thử xem trước, in và xuất PDF tự động thành công.