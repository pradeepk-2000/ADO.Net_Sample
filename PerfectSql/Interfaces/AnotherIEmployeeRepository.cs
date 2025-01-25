using PerfectSql.Models;

namespace PerfectSql.Interfaces
{
    public interface AnotherIEmployeeRepository
    {
        Task<EmployeeDetails?> GetEmployeeDetails(EmployeeDetailsRequestModel model);
        Task<List<EmployeeDetails>> GetAllEmployeeDetails();
        Task<bool> UpdateDesignation(UpdateEmployeDesignationRequestModel model);
        Task<bool> AddNewEmployee(NewEmployeeDetailsRequestModel model);
    }
}
