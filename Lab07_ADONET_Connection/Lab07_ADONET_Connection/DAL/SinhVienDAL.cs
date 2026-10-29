using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Lab07_ADONET_Connection.DAL
{
    public class SinhVienDAL
    {
        // Bài 1: Đếm số sinh viên bằng ExecuteScalar
        public int DemSoSinhVien()
        {
            string sql = "SELECT COUNT(*) FROM SinhVien";
            object res = MySqlHelper.ExecuteScalar(sql);
            return Convert.ToInt32(res);
        }

        // Bài 2: Đọc danh sách bằng ExecuteReader
        public DataTable LayDanhSachSinhVien()
        {
            string sql = "SELECT MaSV, HoTen, DiemTB FROM SinhVien ORDER BY HoTen";
            return MySqlHelper.ExecuteQuery(sql);
        }

        // Bài 3: Thêm sinh viên bằng ExecuteNonQuery
        public int ThemSinhVien(string maSV, string hoTen, DateTime ngaySinh, bool gioiTinh, string maKhoa, double diemTB, string email)
        {
            string sql = @"INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email)
                           VALUES (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @MaKhoa, @DiemTB, @Email)";

            MySqlParameter[] p = {
                new MySqlParameter("@MaSV", MySqlDbType.VarChar, 15) { Value = maSV },
                new MySqlParameter("@HoTen", MySqlDbType.VarChar, 100) { Value = hoTen },
                new MySqlParameter("@NgaySinh", MySqlDbType.Date) { Value = ngaySinh },
                new MySqlParameter("@GioiTinh", MySqlDbType.Byte) { Value = gioiTinh ? 1 : 0 },
                new MySqlParameter("@MaKhoa", MySqlDbType.VarChar, 10) { Value = maKhoa },
                new MySqlParameter("@DiemTB", MySqlDbType.Decimal) { Value = diemTB },
                new MySqlParameter("@Email", MySqlDbType.VarChar, 100) { Value = string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email }
            };

            return MySqlHelper.ExecuteNonQuery(sql, CommandType.Text, p);
        }

        // Bài 4: Cập nhật điểm bằng tham số
        public int CapNhatDiem(string maSV, double diemTB)
        {
            string sql = "UPDATE SinhVien SET DiemTB = @DiemTB WHERE MaSV = @MaSV";
            MySqlParameter[] p = {
                new MySqlParameter("@DiemTB", MySqlDbType.Decimal) { Value = diemTB },
                new MySqlParameter("@MaSV", MySqlDbType.VarChar, 15) { Value = maSV }
            };
            return MySqlHelper.ExecuteNonQuery(sql, CommandType.Text, p);
        }

        // Bài 5: Gọi Stored Procedure lấy danh sách theo khoa
        public DataTable LaySinhVienTheoKhoa(string maKhoa)
        {
            string procName = "sp_SinhVien_TheoKhoa";
            MySqlParameter[] p = {
                new MySqlParameter("p_MaKhoa", MySqlDbType.VarChar, 10) { Value = maKhoa }
            };
            return MySqlHelper.ExecuteQuery(procName, CommandType.StoredProcedure, p);
        }

        // Bài 6: Tìm sinh viên theo mã
        public DataTable TimSinhVienTheoMa(string maSV)
        {
            string sql = "SELECT * FROM SinhVien WHERE MaSV = @MaSV";
            MySqlParameter[] p = {
                new MySqlParameter("@MaSV", MySqlDbType.VarChar, 15) { Value = maSV }
            };
            return MySqlHelper.ExecuteQuery(sql, CommandType.Text, p);
        }

        // Bài 7: Thống kê điểm cao nhất theo khoa (Xử lý DBNull)
        public double ThongKeDiemCaoNhat(string maKhoa)
        {
            string sql = "SELECT MAX(DiemTB) FROM SinhVien WHERE MaKhoa = @MaKhoa";
            MySqlParameter[] p = {
                new MySqlParameter("@MaKhoa", MySqlDbType.VarChar, 10) { Value = maKhoa }
            };
            object res = MySqlHelper.ExecuteScalar(sql, CommandType.Text, p);
            if (res == null || res == DBNull.Value) return 0.0;
            return Convert.ToDouble(res);
        }

        // Bài 8: Xóa sinh viên
        public int XoaSinhVien(string maSV)
        {
            string sql = "DELETE FROM SinhVien WHERE MaSV = @MaSV";
            MySqlParameter[] p = {
                new MySqlParameter("@MaSV", MySqlDbType.VarChar, 15) { Value = maSV }
            };
            return MySqlHelper.ExecuteNonQuery(sql, CommandType.Text, p);
        }

        // Bài 9: Gọi Stored Procedure thêm sinh viên & Tham số đầu ra (OUTPUT)
        public int ThemSinhVienCoOutput(string maSV, string hoTen, DateTime ngaySinh, bool gioiTinh, string maKhoa, double diemTB, string email, out int tongSoSV)
        {
            tongSoSV = 0;
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand("sp_ThemSinhVien_DemSoLuong", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_MaSV", maSV);
                cmd.Parameters.AddWithValue("p_HoTen", hoTen);
                cmd.Parameters.AddWithValue("p_NgaySinh", ngaySinh);
                cmd.Parameters.AddWithValue("p_GioiTinh", gioiTinh ? 1 : 0);
                cmd.Parameters.AddWithValue("p_MaKhoa", maKhoa);
                cmd.Parameters.AddWithValue("p_DiemTB", diemTB);
                cmd.Parameters.AddWithValue("p_Email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);

                MySqlParameter pOut = new MySqlParameter("p_TongSoSV", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(pOut);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (pOut.Value != null && pOut.Value != DBNull.Value)
                {
                    tongSoSV = Convert.ToInt32(pOut.Value);
                }
                return rows;
            }
        }
    }
}