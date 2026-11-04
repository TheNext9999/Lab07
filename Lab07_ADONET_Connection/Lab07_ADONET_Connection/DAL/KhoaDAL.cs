using System;
using System.Data;
using MySql.Data.MySqlClient;
using Lab07_ADONET_Connection.DTO;

namespace Lab07_ADONET_Connection.DAL
{
    public class KhoaDAL
    {
        public DataTable GetAllKhoa()
        {
            return MySqlHelper.ExecuteQuery("SELECT * FROM Khoa ORDER BY TenKhoa");
        }

        public int InsertKhoa(KhoaDTO dto)
        {
            MySqlParameter[] p = {
                new MySqlParameter("p_MaKhoa", dto.MaKhoa),
                new MySqlParameter("p_TenKhoa", dto.TenKhoa)
            };
            return MySqlHelper.ExecuteNonQuery("sp_Khoa_Insert", CommandType.StoredProcedure, p);
        }

        public int UpdateKhoa(KhoaDTO dto)
        {
            MySqlParameter[] p = {
                new MySqlParameter("p_MaKhoa", dto.MaKhoa),
                new MySqlParameter("p_TenKhoa", dto.TenKhoa)
            };
            return MySqlHelper.ExecuteNonQuery("sp_Khoa_Update", CommandType.StoredProcedure, p);
        }

        public int DeleteKhoa(string maKhoa)
        {
            MySqlParameter[] p = {
                new MySqlParameter("p_MaKhoa", maKhoa)
            };
            return MySqlHelper.ExecuteNonQuery("sp_Khoa_Delete", CommandType.StoredProcedure, p);
        }
    }
}