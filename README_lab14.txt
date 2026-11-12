====================================================================
BÁO CÁO BÀI TẬP LAB 14: BÁO CÁO THAM SỐ, NHÓM, THỐNG KÊ VÀ XUẤT EXCEL
====================================================================

1. THÔNG TIN HỆ THỐNG
---------------------
- DBMS: MySQL Server 8.0 (Views vw_BaoCaoSinhVien, vw_BaoCaoDangKyHocKy)
- Visual Studio: 2026 (.NET Framework 4.8 / C#)
- Crystal Reports: SAP Crystal Reports SP40 (13.0.4000.0)
- Form chính: frmLab14_TrungTamBaoCao (Trung tâm báo cáo tổng hợp)

2. HƯỚNG DẪN CHẠY & DỮ LIỆU THỬ
-------------------------------
Bước 1: Chạy script 'Lab14_Views.sql' trong MySQL Workbench để cập nhật cột XepLoai và View thống kê học kỳ.
Bước 2: Mở Solution trong Visual Studio 2026, kiểm tra Form khởi chạy 'frmLab14_TrungTamBaoCao' trong Program.cs.
Bước 3: Nhấn F5 để chạy ứng dụng, chọn loại báo cáo và nhập tham số (Khoa, Điểm Min/Max, Top N, Học kỳ).
Bước 4: Thử nghiệm các nút 'Xuất Excel (Bài 5)', 'Xuất Grid Excel (Bài 9)' và 'Xuất PDF (Bài 10)'.

3. DANH MỤC 10 BÀI TẬP ĐÃ HOÀN THÀNH
------------------------------------
[x] Bài 1: Báo cáo sinh viên theo tham số Khoa & truyền pTenKhoa, pNgayLap.
[x] Bài 2: Nhóm dữ liệu theo Khoa & đếm số lượng sinh viên mỗi khoa.
[x] Bài 3: Thống kê điểm trung bình (Average, Max, Min) và công thức xếp loại @XepLoai.
[x] Bài 4: Báo cáo lọc sinh viên theo khoảng điểm [Min, Max] thuộc [0, 10].
[x] Bài 5: Xuất báo cáo Crystal Report sang Excel Workbook & kiểm tra khóa tệp.
[x] Bài 6: Báo cáo Top N sinh viên điểm cao nhất (có lọc theo Khoa).
[x] Bài 7: Báo cáo thống kê đăng ký theo Học kỳ và Học phần (Số lượt ĐK, Điểm TB).
[x] Bài 8: Trực quan hóa dữ liệu bằng biểu đồ cột (Số lượng SV theo Khoa & Phân bố Xếp loại).
[x] Bài 9: Xuất DataGridView sang Excel giữ nguyên tiêu đề cột, định dạng ngày và số.
[x] Bài 10: Trung tâm báo cáo tổng hợp (frmLab14_TrungTamBaoCao) tích hợp đầy đủ tính năng.