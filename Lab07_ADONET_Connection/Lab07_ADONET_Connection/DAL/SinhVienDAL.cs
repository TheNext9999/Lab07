using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace Lab07_ADONET_Connection.DAL
{
    public class SinhVienDAL
    {
        #region HÀM XỬ LÝ CHO LAB 08
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
        #endregion

        #region HÀM XỬ LÝ CHO LAB 09
        // Bài 1: Nạp MySqlDataReader vào DataTable (JOIN SinhVien với Khoa)
        public DataTable LoadStudents()
        {
            string sql = @"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh,
                           CASE sv.GioiTinh WHEN 1 THEN 'Nam' ELSE 'Nữ' END AS GioiTinhText,
                           k.TenKhoa, sv.DiemTB, sv.Email, sv.MaKhoa, sv.GioiTinh
                           FROM SinhVien sv 
                           JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                           ORDER BY sv.HoTen";
            return MySqlHelper.ExecuteQuery(sql);
        }

        // Bài 2: Tìm kiếm gần đúng theo họ tên (LIKE @Keyword)
        public DataTable SearchByName(string keyword)
        {
            string sql = @"SELECT sv.MaSV, sv.HoTen, k.TenKhoa, sv.DiemTB, sv.NgaySinh
                           FROM SinhVien sv 
                           JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                           WHERE sv.HoTen LIKE @Keyword
                           ORDER BY sv.HoTen";
            MySqlParameter[] p = {
                new MySqlParameter("@Keyword", MySqlDbType.VarChar, 100) { Value = "%" + keyword.Trim() + "%" }
            };
            return MySqlHelper.ExecuteQuery(sql, CommandType.Text, p);
        }

        // Bài 3: Lọc theo khoa và khoảng điểm (BETWEEN @Min AND @Max)
        public DataTable FilterByKhoaAndDiem(string maKhoa, double min, double max)
        {
            StringBuilder sql = new StringBuilder(@"SELECT sv.MaSV, sv.HoTen, k.TenKhoa, sv.DiemTB
                                                    FROM SinhVien sv 
                                                    JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                                                    WHERE sv.DiemTB BETWEEN @Min AND @Max");
            List<MySqlParameter> pList = new List<MySqlParameter>
            {
                new MySqlParameter("@Min", MySqlDbType.Decimal) { Value = min },
                new MySqlParameter("@Max", MySqlDbType.Decimal) { Value = max }
            };

            if (!string.IsNullOrEmpty(maKhoa) && maKhoa != "ALL")
            {
                sql.Append(" AND sv.MaKhoa = @MaKhoa");
                pList.Add(new MySqlParameter("@MaKhoa", MySqlDbType.VarChar, 10) { Value = maKhoa });
            }

            return MySqlHelper.ExecuteQuery(sql.ToString(), CommandType.Text, pList.ToArray());
        }

        // Bài 4: Phân trang Server-side bằng MySQL (LIMIT @PageSize OFFSET @Offset)
        public DataTable GetStudentsPaged(int pageIndex, int pageSize, out int totalRecords)
        {
            string countSql = "SELECT COUNT(*) FROM SinhVien";
            totalRecords = Convert.ToInt32(MySqlHelper.ExecuteScalar(countSql));

            string sql = @"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh,
                           CASE sv.GioiTinh WHEN 1 THEN 'Nam' ELSE 'Nữ' END AS GioiTinhText,
                           k.TenKhoa, sv.DiemTB, sv.Email
                           FROM SinhVien sv 
                           JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                           ORDER BY sv.MaSV
                           LIMIT @PageSize OFFSET @Offset";

            MySqlParameter[] p = {
                new MySqlParameter("@PageSize", MySqlDbType.Int32) { Value = pageSize },
                new MySqlParameter("@Offset", MySqlDbType.Int32) { Value = (pageIndex - 1) * pageSize }
            };

            return MySqlHelper.ExecuteQuery(sql, CommandType.Text, p);
        }

        // Bài 6, 7, 8: Tìm kiếm đa tiêu chí, Lọc theo tuổi & Sắp xếp động an toàn (Whitelist)
        public DataTable SearchMultiCriteria(string maSV, string hoTen, string maKhoa, int? gioiTinh,
                                             double? minDiem, double? maxDiem, int? minTuoi, int? maxTuoi,
                                             string sortColumn, bool isAsc, int pageIndex, int pageSize, out int totalRecords)
        {
            StringBuilder sql = new StringBuilder(@"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh,
                           CASE sv.GioiTinh WHEN 1 THEN 'Nam' ELSE 'Nữ' END AS GioiTinhText,
                           k.TenKhoa, sv.DiemTB, sv.Email, sv.MaKhoa, sv.GioiTinh,
                           TIMESTAMPDIFF(YEAR, sv.NgaySinh, CURDATE()) AS Tuoi
                           FROM SinhVien sv 
                           JOIN Khoa k ON sv.MaKhoa = k.MaKhoa WHERE 1=1");

            List<MySqlParameter> pList = new List<MySqlParameter>();

            if (!string.IsNullOrWhiteSpace(maSV))
            {
                sql.Append(" AND sv.MaSV LIKE @MaSV");
                pList.Add(new MySqlParameter("@MaSV", "%" + maSV.Trim() + "%"));
            }
            if (!string.IsNullOrWhiteSpace(hoTen))
            {
                sql.Append(" AND sv.HoTen LIKE @HoTen");
                pList.Add(new MySqlParameter("@HoTen", "%" + hoTen.Trim() + "%"));
            }
            if (!string.IsNullOrWhiteSpace(maKhoa) && maKhoa != "ALL")
            {
                sql.Append(" AND sv.MaKhoa = @MaKhoa");
                pList.Add(new MySqlParameter("@MaKhoa", maKhoa));
            }
            if (gioiTinh.HasValue)
            {
                sql.Append(" AND sv.GioiTinh = @GioiTinh");
                pList.Add(new MySqlParameter("@GioiTinh", gioiTinh.Value));
            }
            if (minDiem.HasValue)
            {
                sql.Append(" AND sv.DiemTB >= @MinDiem");
                pList.Add(new MySqlParameter("@MinDiem", minDiem.Value));
            }
            if (maxDiem.HasValue)
            {
                sql.Append(" AND sv.DiemTB <= @MaxDiem");
                pList.Add(new MySqlParameter("@MaxDiem", maxDiem.Value));
            }
            if (minTuoi.HasValue)
            {
                sql.Append(" AND TIMESTAMPDIFF(YEAR, sv.NgaySinh, CURDATE()) >= @MinTuoi");
                pList.Add(new MySqlParameter("@MinTuoi", minTuoi.Value));
            }
            if (maxTuoi.HasValue)
            {
                sql.Append(" AND TIMESTAMPDIFF(YEAR, sv.NgaySinh, CURDATE()) <= @MaxTuoi");
                pList.Add(new MySqlParameter("@MaxTuoi", maxTuoi.Value));
            }

            string countSql = "SELECT COUNT(*) FROM (" + sql.ToString() + ") AS TempTable";
            totalRecords = Convert.ToInt32(MySqlHelper.ExecuteScalar(countSql, CommandType.Text, pList.ToArray()));

            string safeSort = "sv.MaSV";
            if (sortColumn == "HoTen") safeSort = "sv.HoTen";
            else if (sortColumn == "DiemTB") safeSort = "sv.DiemTB";
            else if (sortColumn == "NgaySinh") safeSort = "sv.NgaySinh";
            else if (sortColumn == "TenKhoa") safeSort = "k.TenKhoa";

            sql.Append($" ORDER BY {safeSort} {(isAsc ? "ASC" : "DESC")}");

            sql.Append(" LIMIT @PageSize OFFSET @Offset");
            pList.Add(new MySqlParameter("@PageSize", pageSize));
            pList.Add(new MySqlParameter("@Offset", (pageIndex - 1) * pageSize));

            return MySqlHelper.ExecuteQuery(sql.ToString(), CommandType.Text, pList.ToArray());
        }
        #endregion
    }
}