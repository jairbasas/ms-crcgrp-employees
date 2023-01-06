using Employees.Application.Queries.ViewModels.Base;

namespace Employees.Application.Queries.ViewModels
{
    public class EmployeeViewModel
    {
        public int employeeId { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string fatherLastName { get; set; }
        public string motherLastName { get; set; }
        public string categoryName { get; set; }
        public string situationId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerUpdate { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }
    }

    public class EmployeeRequest : PaginationRequest
    {
        public int employeeId { get; set; }
    }
}
