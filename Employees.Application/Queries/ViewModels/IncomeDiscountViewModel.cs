using Employees.Application.Queries.ViewModels.Base;

namespace Employees.Application.Queries.ViewModels
{
    public class IncomeDiscountViewModel
    {
        public int employeeId { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string currencyId { get; set; }
        public decimal? amount { get; set; }
        public bool? state { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }
    }

    public class IncomeDiscountRequest : PaginationRequest
    {
        public int employeeId { get; set; }
    }
}
