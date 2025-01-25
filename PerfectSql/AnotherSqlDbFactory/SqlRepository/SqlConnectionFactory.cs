using PerfectSql.SqlDbFactory.Interfaces;
using System.Data.SqlClient;

namespace PerfectSql.SqlDbFactory.SqlRepository
{
    public class SqlConnectionFactory : SqlIconnectionFactory
    {
        
        public SqlConnection GetConnectionString(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
