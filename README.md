====================================================================
BÁO CÁO BÀI TẬP LAB 07: KẾT NỐI CSDL MYSQL BẰNG ADO.NET (WINFORMS)
====================================================================

1. THÔNG TIN INSTANCE MYSQL SERVER
----------------------------------
- Host/Server: localhost (127.0.0.1)
- Port: 3306
- Database Name: QLSinhVien
- Server Version: MySQL 8.0.x
- Tài khoản Root: root / HoChiMinh1890
- Tài khoản AppUser: QLSV_AppUser / Eaut@2026Secure

2. HƯỚNG DẪN CẤU HÌNH & CHẠY DỰ ÁN
-----------------------------------
Bước 1: Chạy file script 'Lab07_QLSinhVien.sql' trong MySQL Workbench để khởi tạo CSDL và tài khoản người dùng.
Bước 2: Mở Solution 'Lab07_ADONET_Connection.sln' bằng Visual Studio.
Bước 3: Thay đổi chuỗi kết nối trong tệp 'App.config' nếu cần:
   - Mở tệp App.config tại thư mục gốc dự án.
   - Sửa thông số 'Pwd=HoChiMinh1890;' trong chuỗi "MySqlRootConnection" thành mật khẩu root MySQL trên máy chấm bài.
   - Ví dụ: 
     <add name="MySqlRootConnection" 
          connectionString="Server=localhost;Port=3306;Database=QLSinhVien;Uid=root;Pwd=MAT_KHAU_MÁY_BẠN;CharSet=utf8;" 
          providerName="MySql.Data.MySqlClient" />

Bước 4: Nhấn F5 để chạy ứng dụng và bấm nút "KIỂM TRA KẾT NỐI" để kiểm tra trạng thái mở kết nối và đo độ trễ latency.