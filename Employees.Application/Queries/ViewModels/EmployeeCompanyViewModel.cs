using Employees.Application.Queries.ViewModels.Base;

namespace Employees.Application.Queries.ViewModels
{
    public class EmployeeCompanyViewModel
    {
        public int employeeId { get; set; }
        public int companyId { get; set; }
        public int? state { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }
    }

    public class EmployeeCompanyRequest : PaginationRequest
    {
        public int? employeeId { get; set; }
        public int? companyId { get; set; }
    }
}
