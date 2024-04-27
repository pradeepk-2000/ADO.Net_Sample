namespace PerfectSql.Models
{
    public class EmployeeDetails
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Qualification { get; set; }
        public DateTime JoiningDate { get; set; }

    }

    public class NewEmployeeDetailsRequestModel
    {
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Qualification { get; set; }
        public DateTime JoiningDate { get; set; }

    }
    public class NewEmployeeDetailsResponse
    {
        public int EmpId { get; set; }
    }
}
