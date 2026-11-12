using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Lab07_ADONET_Connection.DAL
{
    public class BaoCaoDAL
    {
        // --- CÁC PHƯƠNG THỨC TỪ LAB 13 ---
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

        // --- CÁC PHƯƠNG THỨC NÂNG CAO LAB 14 ---

        // Bài 1: Lấy danh sách Sinh viên theo tham số Khoa
        public DataTable GetStudentsByDepartment(string maKhoa)
        {
            string sql = @"SELECT * FROM vw_BaoCaoSinhVien 
                           WHERE (@MaKhoa = '' OR MaKhoa = @MaKhoa)
                           ORDER BY TenKhoa, HoTen";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlDataAdapter ad = new MySqlDataAdapter(sql, conn))
            {
                ad.SelectCommand.Parameters.Add("@MaKhoa", MySqlDbType.VarChar, 10).Value = maKhoa ?? "";
                DataTable t = new DataTable("SinhVienReport");
                ad.Fill(t);
                return t;
            }
        }

        // Bài 2 & 3: Thống kê nhóm theo Khoa (Số lượng SV, Average, Max, Min DiemTB)
        public DataTable GetDepartmentSummaryStats()
        {
            const string sql = @"SELECT k.MaKhoa, k.TenKhoa,
                                        COUNT(sv.MaSV) AS SoLuongSV,
                                        ROUND(IFNULL(AVG(sv.DiemTB), 0), 2) AS DiemTB_Chung,
                                        IFNULL(MAX(sv.DiemTB), 0) AS DiemCaoNhat,
                                        IFNULL(MIN(sv.DiemTB), 0) AS DiemThapNhat
                                 FROM Khoa k
                                 LEFT JOIN SinhVien sv ON k.MaKhoa = sv.MaKhoa AND sv.IsActive = 1
                                 GROUP BY k.MaKhoa, k.TenKhoa
                                 ORDER BY k.TenKhoa";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlDataAdapter ad = new MySqlDataAdapter(sql, conn))
            {
                DataTable t = new DataTable("ThongKeKhoa");
                ad.Fill(t);
                return t;
            }
        }

        // Bài 4: Báo cáo sinh viên theo khoảng điểm [Min, Max]
        public DataTable GetByScoreRange(decimal min, decimal max)
        {
            const string sql = @"SELECT * FROM vw_BaoCaoSinhVien
                                 WHERE DiemTB BETWEEN @Min AND @Max
                                 ORDER BY DiemTB DESC, HoTen ASC";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlDataAdapter ad = new MySqlDataAdapter(sql, conn))
            {
                ad.SelectCommand.Parameters.Add("@Min", MySqlDbType.Decimal).Value = min;
                ad.SelectCommand.Parameters.Add("@Max", MySqlDbType.Decimal).Value = max;
                DataTable t = new DataTable("SinhVienReport");
                ad.Fill(t);
                return t;
            }
        }

        // Bài 6: Báo cáo Top N sinh viên điểm cao nhất (có thể lọc theo Khoa)
        public DataTable GetTopStudents(int topN, string maKhoa)
        {
            const string sql = @"SELECT * FROM vw_BaoCaoSinhVien
                                 WHERE (@MaKhoa = '' OR MaKhoa = @MaKhoa)
                                 ORDER BY DiemTB DESC, HoTen ASC
                                 LIMIT @TopN";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlDataAdapter ad = new MySqlDataAdapter(sql, conn))
            {
                ad.SelectCommand.Parameters.Add("@MaKhoa", MySqlDbType.VarChar, 10).Value = maKhoa ?? "";
                ad.SelectCommand.Parameters.Add("@TopN", MySqlDbType.Int32).Value = topN;
                DataTable t = new DataTable("SinhVienReport");
                ad.Fill(t);
                return t;
            }
        }

        // Bài 7: Báo cáo thống kê đăng ký theo Học kỳ và Học phần
        public DataTable GetEnrollmentStatsBySemester(int hocKy)
        {
            const string sql = @"SELECT * FROM vw_BaoCaoDangKyHocKy
                                 WHERE (@HocKy = 0 OR HocKy = @HocKy)
                                 ORDER BY HocKy ASC, TenHP ASC";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlDataAdapter ad = new MySqlDataAdapter(sql, conn))
            {
                ad.SelectCommand.Parameters.Add("@HocKy", MySqlDbType.Int32).Value = hocKy;
                DataTable t = new DataTable("DangKyHocKyReport");
                ad.Fill(t);
                return t;
            }
        }

        // Bài 8: Dữ liệu biểu đồ phân bố xếp loại học lực
        public DataTable GetGradeDistribution()
        {
            const string sql = @"SELECT XepLoai, COUNT(*) AS SoLuong
                                 FROM vw_BaoCaoSinhVien
                                 GROUP BY XepLoai
                                 ORDER BY FIELD(XepLoai, 'Xuất sắc', 'Giỏi', 'Khá', 'Trung bình', 'Yếu')";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlDataAdapter ad = new MySqlDataAdapter(sql, conn))
            {
                DataTable t = new DataTable("PhanBoXepLoai");
                ad.Fill(t);
                return t;
            }
        }
    }
}