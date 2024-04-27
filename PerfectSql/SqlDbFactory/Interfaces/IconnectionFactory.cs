using System.Data.SqlClient;

namespace PerfectSql.SqlDbFactory.Interfaces
{
    public interface IconnectionFactory
    {
        SqlConnection GetConnectionString();
    }
}
