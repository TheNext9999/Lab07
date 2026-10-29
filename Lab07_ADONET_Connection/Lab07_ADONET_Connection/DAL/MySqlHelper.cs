using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Lab07_ADONET_Connection.DAL
{
    public static class MySqlHelper
    {
        public static int ExecuteNonQuery(string sql, CommandType cmdType = CommandType.Text, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.CommandType = cmdType;
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, CommandType cmdType = CommandType.Text, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.CommandType = cmdType;
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static DataTable ExecuteQuery(string sql, CommandType cmdType = CommandType.Text, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = DbConnectionFactory.Create())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.CommandType = cmdType;
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }
        }
    }
}