using Employees.Application.Queries.ViewModels.Base;

namespace Employees.Application.Queries.ViewModels
{
    public class SalaryPaymentViewModel
    {
        public int employeeId { get; set; }
        public string accountNumber { get; set; }
        public string interbankAccount { get; set; }
        public string bankId { get; set; }
        public string accountTypeId { get; set; }
        public string currencyId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }
    }

    public class SalaryPaymentRequest : PaginationRequest
    {
        public int employeeId { get; set; }
    }
}
