using PerfectSql.SqlDbFactory.Interfaces;
using System.Data.SqlClient;

namespace PerfectSql.SqlDbFactory.SqlRepository
{
    public class ConnectionFactory : IconnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public SqlConnection GetConnectionString()
        {
            return new SqlConnection( _connectionString);
        }
    }
}
