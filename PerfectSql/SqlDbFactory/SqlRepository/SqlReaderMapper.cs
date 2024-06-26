﻿using PerfectSql.Models;
using PerfectSql.SqlDbFactory.Interfaces;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace PerfectSql.SqlDbFactory.SqlRepository
{
    public class SqlReaderMapper : ISqlReaderMapper
    {
        private readonly IconnectionFactory _connectionFactory;

        public SqlReaderMapper(IconnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public bool ExecuteNonQuery(string spName, List<SqlParameter> parms)
        {
            bool result = false;
            using (var conn = _connectionFactory.GetConnectionString())
            {
                using (var cmd = (SqlCommand)conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spName;
                    if (parms.Count > 0)
                    {
                        cmd.Parameters.AddRange(parms.ToArray());
                    }
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            return result;
        }


         public  List<T> ExecuteReader<T>(string spName,List<SqlParameter> parms)
        {
            List<T> results = new List<T>();
             using (var conn = _connectionFactory.GetConnectionString())
            {
                using (var cmd = (SqlCommand)conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spName;
                    if (parms!=null && parms.Count > 0)
                    {
                        cmd.Parameters.AddRange(parms.ToArray());
                    }
                    conn.Open();
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        var parser = reader.GetRowParser<T>(); //install Dapper package
                        while (reader.Read())
                        {
                            results.Add(parser(reader));

                        }
                    }
                }
            }
            return results;
        }

        public object ExecuteScalar(string spName, List<SqlParameter> parms)
        {
            using (var conn = _connectionFactory.GetConnectionString())
            {
                using (var cmd = (SqlCommand)conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spName;
                    if (parms.Count > 0)
                    {
                        cmd.Parameters.AddRange(parms.ToArray());
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();

                }
            }
        }

        #region Not for use, Just for reference
        //to get single record
        //public T ExecuteReader<T>(string spName, List<SqlParameter> parms)
        //{
        //    T results = Activator.CreateInstance<T>();
        //    //EmployeeDetails results = new EmployeeDetails();
        //   using (var conn = new SqlConnection(_connectionString))
        //   using (var conn = _connectionFactory.GetConnectionString())
        //    {
        //        using (var cmd = (SqlCommand)conn.CreateCommand())
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandText = spName;
        //            if (parms.Count > 0)
        //            {
        //                cmd.Parameters.AddRange(parms.ToArray());
        //            }
        //            conn.Open();
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        T obj = Activator.CreateInstance<T>();

        //                        foreach (var property in typeof(T).GetProperties())
        //                        {
        //                            if (reader[property.Name] != DBNull.Value)
        //                            {
        //                                property.SetValue(obj, reader[property.Name]);
        //                            }
        //                        }

        //                        results = obj;

        //                        //EmployeeDetails employee = new EmployeeDetails();

        //                        //employee.EmpId = reader["EmpId"] != DBNull.Value ? (int)reader["EmpId"] : 0;
        //                        //employee.EmpName = reader["EmpName"] != DBNull.Value ? (string)reader["EmpName"] : null;
        //                        //employee.Designation = reader["Designation"] != DBNull.Value ? (string)reader["Designation"] : null;
        //                        //employee.Qualification = reader["Qualification"] != DBNull.Value ? (string)reader["Qualification"] : null;
        //                        //employee.JoiningDate = reader["JoiningDate"] != DBNull.Value ? (DateTime)reader["JoiningDate"] : default;

        //                        //results = employee;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return results;
        //}
        #endregion
    }
}
