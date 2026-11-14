using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Lab07_ADONET_Connection.DTO;
using MySql.Data.MySqlClient;

namespace Lab07_ADONET_Connection.DAL
{
    public class SinhVienDAL
    {
        public DataTable GetAllSinhVien()
        {
            DataTable dt = new DataTable("SinhVien");
            string sql = @"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.MaKhoa, k.TenKhoa, sv.DiemTB, sv.Email
                           FROM SinhVien sv
                           LEFT JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                           ORDER BY sv.MaSV";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetAll()
        {
            return GetAllSinhVien();
        }

        public int DemSoSinhVien()
        {
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM SinhVien", conn))
            {
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public double ThongKeDiemCaoNhat(string maKhoa = "")
        {
            string sql = string.IsNullOrWhiteSpace(maKhoa)
                ? "SELECT IFNULL(MAX(DiemTB), 0) FROM SinhVien"
                : "SELECT IFNULL(MAX(DiemTB), 0) FROM SinhVien WHERE MaKhoa = @MaKhoa";

            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                if (!string.IsNullOrWhiteSpace(maKhoa))
                    cmd.Parameters.AddWithValue("@MaKhoa", maKhoa.Trim());
                conn.Open();
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
        }

        public DataTable TimSinhVienTheoMa(string maSV)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.MaKhoa, k.TenKhoa, sv.DiemTB, sv.Email
                           FROM SinhVien sv
                           LEFT JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                           WHERE sv.MaSV = @MaSV";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable SearchSinhVien(string keyword)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.MaKhoa, k.TenKhoa, sv.DiemTB, sv.Email
                           FROM SinhVien sv
                           LEFT JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                           WHERE sv.MaSV LIKE @kw OR sv.HoTen LIKE @kw
                           ORDER BY sv.MaSV";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetSinhVienByKhoa(string maKhoa)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.MaKhoa, k.TenKhoa, sv.DiemTB, sv.Email
                           FROM SinhVien sv
                           LEFT JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                           WHERE sv.MaKhoa = @MaKhoa
                           ORDER BY sv.MaSV";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable SearchMultiCriteria(string maSV, string hoTen, string maKhoa, double? diemMin, double? diemMax)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.MaKhoa, k.TenKhoa, sv.DiemTB, sv.Email
                           FROM SinhVien sv
                           LEFT JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                           WHERE 1=1";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                if (!string.IsNullOrWhiteSpace(maSV))
                {
                    sql += " AND sv.MaSV LIKE @MaSV";
                    cmd.Parameters.AddWithValue("@MaSV", "%" + maSV.Trim() + "%");
                }
                if (!string.IsNullOrWhiteSpace(hoTen))
                {
                    sql += " AND sv.HoTen LIKE @HoTen";
                    cmd.Parameters.AddWithValue("@HoTen", "%" + hoTen.Trim() + "%");
                }
                if (!string.IsNullOrWhiteSpace(maKhoa))
                {
                    sql += " AND sv.MaKhoa = @MaKhoa";
                    cmd.Parameters.AddWithValue("@MaKhoa", maKhoa.Trim());
                }
                if (diemMin.HasValue)
                {
                    sql += " AND sv.DiemTB >= @DiemMin";
                    cmd.Parameters.AddWithValue("@DiemMin", diemMin.Value);
                }
                if (diemMax.HasValue)
                {
                    sql += " AND sv.DiemTB <= @DiemMax";
                    cmd.Parameters.AddWithValue("@DiemMax", diemMax.Value);
                }
                sql += " ORDER BY sv.MaSV";
                cmd.CommandText = sql;

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public bool Exists(string maSV)
        {
            string sql = "SELECT COUNT(*) FROM SinhVien WHERE MaSV = @MaSV";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public int Insert(SinhVienDTO dto)
        {
            string sql = @"INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email)
                           VALUES (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @MaKhoa, @DiemTB, @Email)";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                string gioiTinhStr = dto.GioiTinh ? "Nam" : "Nữ";
                cmd.Parameters.AddWithValue("@MaSV", dto.MaSV);
                cmd.Parameters.AddWithValue("@HoTen", dto.HoTen);
                cmd.Parameters.AddWithValue("@NgaySinh", dto.NgaySinh == DateTime.MinValue ? (object)DBNull.Value : dto.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinhStr);
                cmd.Parameters.AddWithValue("@MaKhoa", dto.MaKhoa);
                cmd.Parameters.AddWithValue("@DiemTB", dto.DiemTB);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(dto.Email) ? (object)DBNull.Value : dto.Email);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(SinhVienDTO dto)
        {
            string sql = @"UPDATE SinhVien
                           SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh,
                               MaKhoa = @MaKhoa, DiemTB = @DiemTB, Email = @Email
                           WHERE MaSV = @MaSV";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                string gioiTinhStr = dto.GioiTinh ? "Nam" : "Nữ";
                cmd.Parameters.AddWithValue("@MaSV", dto.MaSV);
                cmd.Parameters.AddWithValue("@HoTen", dto.HoTen);
                cmd.Parameters.AddWithValue("@NgaySinh", dto.NgaySinh == DateTime.MinValue ? (object)DBNull.Value : dto.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinhStr);
                cmd.Parameters.AddWithValue("@MaKhoa", dto.MaKhoa);
                cmd.Parameters.AddWithValue("@DiemTB", dto.DiemTB);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(dto.Email) ? (object)DBNull.Value : dto.Email);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int CapNhatDiem(string maSV, double diemMoi)
        {
            string sql = "UPDATE SinhVien SET DiemTB = @DiemTB WHERE MaSV = @MaSV";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DiemTB", diemMoi);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public bool Delete(string maSV)
        {
            string sql = "DELETE FROM SinhVien WHERE MaSV = @MaSV";
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lab 10: Disconnected DataSet & Adapter
        public DataSet GetQLSVDataSet()
        {
            DataSet ds = new DataSet("QLSinhVien");
            using (MySqlConnection conn = DbConnectionFactory.Create())
            {
                using (MySqlDataAdapter daKhoa = new MySqlDataAdapter("SELECT MaKhoa, TenKhoa FROM Khoa", conn))
                {
                    daKhoa.Fill(ds, "Khoa");
                }
                using (MySqlDataAdapter daSv = new MySqlDataAdapter("SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email FROM SinhVien", conn))
                {
                    daSv.Fill(ds, "SinhVien");
                }
            }
            if (ds.Tables.Contains("Khoa") && ds.Tables.Contains("SinhVien") &&
                ds.Tables["Khoa"].Columns.Contains("MaKhoa") && ds.Tables["SinhVien"].Columns.Contains("MaKhoa"))
            {
                ds.Relations.Add("FK_SinhVien_Khoa", ds.Tables["Khoa"].Columns["MaKhoa"], ds.Tables["SinhVien"].Columns["MaKhoa"], false);
            }
            return ds;
        }

        public MySqlDataAdapter GetStudentAdapterForUpdate(MySqlConnection conn = null)
        {
            MySqlConnection activeConn = conn ?? DbConnectionFactory.Create();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email FROM SinhVien", activeConn);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
            da.InsertCommand = builder.GetInsertCommand();
            da.UpdateCommand = builder.GetUpdateCommand();
            da.DeleteCommand = builder.GetDeleteCommand();
            return da;
        }

        // Lab 11: Transactions
        public bool AddStudentWithEnrollments(SinhVienDTO sv, List<DangKyDTO> dangKys)
        {
            using (MySqlConnection conn = DbConnectionFactory.Create())
            {
                conn.Open();
                using (MySqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        string gioiTinhStr = sv.GioiTinh ? "Nam" : "Nữ";
                        string sqlSv = @"INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email)
                                         VALUES (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @MaKhoa, @DiemTB, @Email)";
                        using (MySqlCommand cmdSv = new MySqlCommand(sqlSv, conn, tran))
                        {
                            cmdSv.Parameters.AddWithValue("@MaSV", sv.MaSV);
                            cmdSv.Parameters.AddWithValue("@HoTen", sv.HoTen);
                            cmdSv.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh == DateTime.MinValue ? (object)DBNull.Value : sv.NgaySinh);
                            cmdSv.Parameters.AddWithValue("@GioiTinh", gioiTinhStr);
                            cmdSv.Parameters.AddWithValue("@MaKhoa", sv.MaKhoa);
                            cmdSv.Parameters.AddWithValue("@DiemTB", sv.DiemTB);
                            cmdSv.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(sv.Email) ? (object)DBNull.Value : sv.Email);
                            cmdSv.ExecuteNonQuery();
                        }

                        if (dangKys != null)
                        {
                            string sqlDk = "INSERT INTO DangKyHocPhan (MaSV, MaHP, HocKy) VALUES (@MaSV, @MaHP, @HocKy)";
                            foreach (DangKyDTO dk in dangKys)
                            {
                                string maHp = GetPropString(dk, "MaHP", "");
                                string hocKy = GetPropString(dk, "HocKy", "HK1-2026");
                                if (string.IsNullOrWhiteSpace(maHp)) continue;

                                using (MySqlCommand cmdDk = new MySqlCommand(sqlDk, conn, tran))
                                {
                                    cmdDk.Parameters.AddWithValue("@MaSV", sv.MaSV);
                                    cmdDk.Parameters.AddWithValue("@MaHP", maHp);
                                    cmdDk.Parameters.AddWithValue("@HocKy", hocKy);
                                    cmdDk.ExecuteNonQuery();
                                }
                            }
                        }

                        tran.Commit();
                        return true;
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool TransferDepartment(string maSV, string maKhoaMoi)
        {
            using (MySqlConnection conn = DbConnectionFactory.Create())
            {
                conn.Open();
                using (MySqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "UPDATE SinhVien SET MaKhoa = @MaKhoa WHERE MaSV = @MaSV";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaKhoa", maKhoaMoi);
                            cmd.Parameters.AddWithValue("@MaSV", maSV);
                            int rows = cmd.ExecuteNonQuery();
                            if (rows == 0) throw new Exception("Không tìm thấy sinh viên để chuyển khoa.");
                        }
                        tran.Commit();
                        return true;
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public int BulkUpdateGrades(List<DangKyDTO> danhSachDiem)
        {
            if (danhSachDiem == null || danhSachDiem.Count == 0) return 0;

            int count = 0;
            using (MySqlConnection conn = DbConnectionFactory.Create())
            {
                conn.Open();
                using (MySqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (DangKyDTO item in danhSachDiem)
                        {
                            string maSv = GetPropString(item, "MaSV", "");
                            string maHp = GetPropString(item, "MaHP", "");
                            double diem = GetPropDouble(item, new[] { "Diem", "DiemSo", "DiemTB", "DiemHP" }, 0);

                            if (string.IsNullOrWhiteSpace(maSv)) continue;

                            string sql = string.IsNullOrWhiteSpace(maHp)
                                ? "UPDATE SinhVien SET DiemTB = @Diem WHERE MaSV = @MaSV"
                                : "UPDATE DangKyHocPhan SET Diem = @Diem WHERE MaSV = @MaSV AND MaHP = @MaHP";

                            using (MySqlCommand cmd = new MySqlCommand(sql, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@Diem", diem);
                                cmd.Parameters.AddWithValue("@MaSV", maSv);
                                if (!string.IsNullOrWhiteSpace(maHp))
                                    cmd.Parameters.AddWithValue("@MaHP", maHp);
                                count += cmd.ExecuteNonQuery();
                            }
                        }
                        tran.Commit();
                        return count;
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        private static string GetPropString(object obj, string propName, string defaultVal)
        {
            if (obj == null) return defaultVal;
            PropertyInfo prop = obj.GetType().GetProperty(propName);
            if (prop == null) return defaultVal;
            object val = prop.GetValue(obj, null);
            return val != null ? val.ToString() : defaultVal;
        }

        private static double GetPropDouble(object obj, string[] propNames, double defaultVal)
        {
            if (obj == null) return defaultVal;
            foreach (string name in propNames)
            {
                PropertyInfo prop = obj.GetType().GetProperty(name);
                if (prop != null)
                {
                    object val = prop.GetValue(obj, null);
                    if (val != null) return Convert.ToDouble(val);
                }
            }
            return defaultVal;
        }
    }
}