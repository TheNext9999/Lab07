using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Lab07_ADONET_Connection.DAL
{
    public static class DbConnectionFactory
    {
        public static string GetConnectionString(string connectionName = "MySqlRootConnection")
        {
            var settings = ConfigurationManager.ConnectionStrings[connectionName];
            if (settings == null)
            {
                throw new InvalidOperationException($"Không tìm thấy chuỗi kết nối '{connectionName}' trong App.config!");
            }
            return settings.ConnectionString;
        }

        public static MySqlConnection Create(string connectionName = "MySqlRootConnection")
        {
            string connectionString = GetConnectionString(connectionName);
            return new MySqlConnection(connectionString);
        }
    }
}