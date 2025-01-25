using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PerfectSql.AnotherSqlDbFactory.Interfaces;

namespace PerfectSql.AnotherSqlDbFactory.SqlRepository
{
    public class ConnectionString : IConnectionString
    {
        string dbOneString = string.Empty;
        string dbTwoString = string.Empty;


        public string DataBaseOneConnectionString
        {
            get{
                if (string.IsNullOrEmpty(dbOneString))
                {
                    dbOneString = BuildDataBaseString();
                }
                return dbOneString;
            }
        }


        public string DataBaseTwoConnectionString
        {
            get{
                if (string.IsNullOrEmpty(dbOneString))
                {
                    dbTwoString = BuildDataBaseString();
                }
                return dbTwoString;
            }
        }

        private string BuildDataBaseString()
        {
            string serverName = Environment.GetEnvironmentVariable("ServerName"); //based on env....
            if (string.IsNullOrWhiteSpace(serverName))
            {
                serverName = "LAPTOP-AV58AB69\\SQLEXPRESS"; // if not give dev(new features.. so IT) details
            }

            string databaseName = Environment.GetEnvironmentVariable("DataBaseName");
            if (string.IsNullOrWhiteSpace(databaseName))
            {
                databaseName = "EmployeeManagement";
            }

            string userId = Environment.GetEnvironmentVariable("UserId");
            string password = Environment.GetEnvironmentVariable("Password");

            if (!string.IsNullOrWhiteSpace(userId) && !string.IsNullOrWhiteSpace(password))
            {
                return $"Server={serverName};Database={databaseName};User Id='{userId}';Password='{password}';MultiSubnetFailover=True;Connect Timeout=300";
            }
            else
            {
                //dev..
                //return $"Server={serverName};Database={databaseName};Trusted_Connection=True;MultiSubnetFailover=True;Connect Timeout=300";
                return $"Server={serverName};Database={databaseName};Integrated Security = True;"; //for local test only
            }

        }
    }
}
