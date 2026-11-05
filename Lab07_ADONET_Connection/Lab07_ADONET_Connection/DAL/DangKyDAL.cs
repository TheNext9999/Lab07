// DangKyDAL.cs
using System;
using System.Data;
using MySql.Data.MySqlClient;
using Lab07_ADONET_Connection.DTO;

namespace Lab07_ADONET_Connection.DAL
{
    public class DangKyDAL
    {
        // Master-Detail (Bài 2)
        public DataTable GetByStudent(string maSV)
        {
            string sql = @"SELECT dk.MaSV, dk.MaHP, hp.TenHP, hp.SoTinChi, dk.HocKy, dk.Diem, dk.UpdatedAt
                           FROM DangKy dk
                           JOIN HocPhan hp ON dk.MaHP = hp.MaHP
                           WHERE dk.MaSV = @MaSV
                           ORDER BY dk.HocKy, hp.TenHP";
            MySqlParameter[] p = { new MySqlParameter("@MaSV", maSV) };
            return MySqlHelper.ExecuteQuery(sql, CommandType.Text, p);
        }

        // Hỗ trợ Transaction (Bài 3 & Bài 5)
        public int Insert(DangKyDTO dto, MySqlConnection conn, MySqlTransaction tx)
        {
            const string sql = @"INSERT INTO DangKy(MaSV, MaHP, HocKy, Diem) VALUES(@MaSV, @MaHP, @HocKy, @Diem)";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@MaSV", dto.MaSV);
                cmd.Parameters.AddWithValue("@MaHP", dto.MaHP);
                cmd.Parameters.AddWithValue("@HocKy", dto.HocKy);
                cmd.Parameters.AddWithValue("@Diem", dto.Diem.HasValue ? (object)dto.Diem.Value : DBNull.Value);
                return cmd.ExecuteNonQuery();
            }
        }

        // Cập nhật điểm hàng loạt trong Transaction (Bài 8)
        public int UpdateGrade(string maSV, string maHP, int hocKy, double diem, MySqlConnection conn, MySqlTransaction tx)
        {
            const string sql = @"UPDATE DangKy SET Diem = @Diem WHERE MaSV = @MaSV AND MaHP = @MaHP AND HocKy = @HocKy";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@MaHP", maHP);
                cmd.Parameters.AddWithValue("@HocKy", hocKy);
                cmd.Parameters.AddWithValue("@Diem", diem);
                return cmd.ExecuteNonQuery();
            }
        }

        // Kiểm soát xung đột đồng thời - Optimistic Concurrency Control (Bài 9)
        public bool UpdateGradeWithConcurrency(string maSV, string maHP, int hocKy, double diemMoi, DateTime originalTimestamp)
        {
            const string sql = @"UPDATE DangKy 
                                 SET Diem = @Diem 
                                 WHERE MaSV = @MaSV AND MaHP = @MaHP AND HocKy = @HocKy 
                                   AND UpdatedAt = @OriginalTimestamp";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@MaHP", maHP);
                cmd.Parameters.AddWithValue("@HocKy", hocKy);
                cmd.Parameters.AddWithValue("@Diem", diemMoi);
                cmd.Parameters.AddWithValue("@OriginalTimestamp", originalTimestamp);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0; // Trả về false nếu bản ghi đã bị người khác sửa trước đó
            }
        }
    }
}