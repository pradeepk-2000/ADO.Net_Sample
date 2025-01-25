using PerfectSql.SqlDbFactory.Interfaces;

namespace PerfectSql.AnotherSqlDbFactory.Interfaces
{
    public interface IResultReaderMapperFactory
    {
        AnotherISqlReaderMapper GetSqlReaderMapper(string connectionString);
    }
}
