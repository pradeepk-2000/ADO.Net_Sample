using PerfectSql.AnotherSqlDbFactory.Interfaces;
using PerfectSql.SqlDbFactory.Interfaces;
using PerfectSql.SqlDbFactory.SqlRepository;

namespace PerfectSql.AnotherSqlDbFactory.SqlRepository
{
    public class ResultReaderMapperFactory :IResultReaderMapperFactory
    {
        private readonly SqlIconnectionFactory _connectionFactory;
        public ResultReaderMapperFactory(SqlIconnectionFactory sqlIconnectionFactory) 
        {
            _connectionFactory = sqlIconnectionFactory;
        }

        public AnotherISqlReaderMapper GetSqlReaderMapper(string connectionString)
        {
            return new AnotherSqlReaderMapper(connectionString, _connectionFactory);
        }
    }
}
