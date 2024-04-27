using PerfectSql.Models;
using System.Data.SqlClient;

namespace PerfectSql.SqlDbFactory.Interfaces
{
    public interface ISqlReaderMapper
    {
        bool ExecuteNonQuery(string spName, List<SqlParameter> parms);
        
        object ExecuteScalar(string spName, List<SqlParameter> parms);

        // we use the same method to get both single and multiple rcords from DB
        List<T> ExecuteReader<T>(string spName, List<SqlParameter> parms = null);


        //if u want to get single record seperately from DB
        // T ExecuteReader<T>(string spName, List<SqlParameter> parms);
    }
}
