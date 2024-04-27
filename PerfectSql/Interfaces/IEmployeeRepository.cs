using PerfectSql.Models;

namespace PerfectSql.Interfaces
{
    public interface IEmployeeRepository
    {
        EmployeeDetails? GetEmployeeDetails(EmployeeDetailsRequestModel model);
        List<EmployeeDetails> GetAllEmployeeDetails();
        bool UpdateDesignation(UpdateEmployeDesignationRequestModel model);
        bool AddNewEmployee(NewEmployeeDetailsRequestModel model);
    }
}
