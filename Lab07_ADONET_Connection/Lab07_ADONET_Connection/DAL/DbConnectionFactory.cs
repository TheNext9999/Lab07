using System.Configuration;
using MySql.Data.MySqlClient;

namespace Lab07_ADONET_Connection.DAL
{
    public static class DbConnectionFactory
    {
        public static string GetConnectionString()
        {
            return GetConnectionString("QLSinhVien");
        }

        public static string GetConnectionString(string connectionName)
        {
            if (string.IsNullOrWhiteSpace(connectionName))
                connectionName = "QLSinhVien";

            var setting = ConfigurationManager.ConnectionStrings[connectionName];
            if (setting != null && !string.IsNullOrWhiteSpace(setting.ConnectionString))
                return setting.ConnectionString;

            var fallback = ConfigurationManager.ConnectionStrings["QLSinhVien"]
                           ?? ConfigurationManager.ConnectionStrings["MySqlRootConnection"];
            if (fallback != null && !string.IsNullOrWhiteSpace(fallback.ConnectionString))
                return fallback.ConnectionString;

            return "Server=localhost;Port=3306;Database=QLSinhVien;Uid=root;Pwd=HoChiMinh1890;CharSet=utf8mb4;";
        }

        public static MySqlConnection Create()
        {
            return new MySqlConnection(GetConnectionString("QLSinhVien"));
        }

        public static MySqlConnection Create(string connectionName)
        {
            return new MySqlConnection(GetConnectionString(connectionName));
        }

        public static MySqlConnection CreateConnection()
        {
            return Create();
        }

        public static MySqlConnection CreateConnection(string connectionName)
        {
            return Create(connectionName);
        }

        public static MySqlConnection GetConnection()
        {
            return Create();
        }

        public static MySqlConnection GetConnection(string connectionName)
        {
            return Create(connectionName);
        }
    }
}