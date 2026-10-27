
using System.Configuration;
using System.Data.SqlClient;

namespace Lab07_ADONET_Connection
{
    public static class DbConnectionFactory
    {
        public static SqlConnection Create()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings[
                    "QLSinhVienConnection"
                ].ConnectionString;

            return new SqlConnection(connectionString);
        }
    }
}
