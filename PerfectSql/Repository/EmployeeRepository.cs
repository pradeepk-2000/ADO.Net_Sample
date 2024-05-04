using PerfectSql.Interfaces;
using PerfectSql.Models;
using PerfectSql.SqlDbFactory.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace PerfectSql.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISqlReaderMapper _mapper;
        public EmployeeRepository(ISqlReaderMapper mapper)
        {
                _mapper = mapper;
        }

        public async Task<bool> AddNewEmployee(NewEmployeeDetailsRequestModel model)
        {
            List<SqlParameter> parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@EmpName", DbType.String) { Value=model.EmpName });
            parms.Add(new SqlParameter("@Designation", DbType.String) { Value=model.Designation });
            parms.Add(new SqlParameter("@Qualification", DbType.String) { Value = model.Qualification });
            parms.Add(new SqlParameter("@JoiningDate", DbType.String) { Value = model.JoiningDate });

            return _mapper.ExecuteNonQuery("[dbo].[AddNewEmployee]",parms);
        }

        public async Task<List<EmployeeDetails>> GetAllEmployeeDetails()
        {

            return _mapper.ExecuteReader<EmployeeDetails>("[dbo].[GetAllEmployeeDetails]").ToList();
        }

        public async Task<EmployeeDetails?> GetEmployeeDetails(EmployeeDetailsRequestModel model)
        {

            List<SqlParameter> parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@EmpId", DbType.Int32) { Value = model.EmpId });
            
            var eList =  _mapper.ExecuteReader<EmployeeDetails>("[dbo].[GetEmployeeDetails]",parms);
            if(eList != null && eList.Count>0)
            {
                return eList[0];
            }
            return null;
        }

        public async Task<bool> UpdateDesignation(UpdateEmployeDesignationRequestModel model)
        {

            List<SqlParameter> parms = new List<SqlParameter>();
            parms.Add(new SqlParameter("@EmpId", DbType.Int64) { Value = model.EmpId });
            parms.Add(new SqlParameter("@Designation", DbType.AnsiString) { Value = model.Designation });

             return _mapper.ExecuteNonQuery("[dbo].[UpdateEmployeeDesignation]", parms);
        }
    }
}
// we will be calling this methods with
//List<SqlParameter> parms = new List<SqlParameter>();
//parms.Add(new SqlParameter("@Id", DbType.Int64) { Value = id });
//return ISqlReaderMapper.ExecuteReader<Model>("[dbo].[StoredProcedureName]", parms).ToList();
//return ISqlReaderMapper.ExecuteNonQuery("[dbo].[StoredProcedureName]", parms);
//return long.TryParse(ISqlReaderMapper.ExecuteScalar("[dbo].[StoredProcedureName]", parms).ToString());
