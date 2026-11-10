using System.Data;
using MySql.Data.MySqlClient;

namespace Lab07_ADONET_Connection.DAL
{
    public class BaoCaoDAL
    {
        // Bài 3: Lấy danh sách Sinh viên từ View làm nguồn báo cáo
        public DataTable GetStudentReportData()
        {
            DataTable table = new DataTable("SinhVienReport");
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM vw_BaoCaoSinhVien ORDER BY TenKhoa, HoTen", conn))
            {
                adapter.Fill(table);
            }
            return table;
        }

        // Bài 6: Lấy danh sách Khoa & số lượng Sinh viên
        public DataTable GetDepartmentReportData()
        {
            DataTable table = new DataTable("KhoaReport");
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM vw_BaoCaoDanhSachKhoa ORDER BY TenKhoa", conn))
            {
                adapter.Fill(table);
            }
            return table;
        }

        // Bài 8: Lấy danh sách Học phần
        public DataTable GetCourseReportData()
        {
            DataTable table = new DataTable("HocPhanReport");
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM vw_BaoCaoHocPhan ORDER BY TenHP", conn))
            {
                adapter.Fill(table);
            }
            return table;
        }
    }
}