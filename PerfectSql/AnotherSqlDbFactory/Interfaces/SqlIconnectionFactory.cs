using System.Data.SqlClient;

namespace PerfectSql.SqlDbFactory.Interfaces
{
    public interface SqlIconnectionFactory
    {
        //IDbConnection
        SqlConnection GetConnectionString(string connectionString);
    }
}
