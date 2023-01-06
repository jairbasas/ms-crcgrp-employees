using Employees.Application.Queries.ViewModels.Base;

namespace Employees.Application.Queries.ViewModels
{
    public class CompanyViewModel
    {
        public int companyId { get; set; }
        public string businessName { get; set; }
        public string tradename { get; set; }
        public string documentNumber { get; set; }
        public int? state { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }
    }

    public class CompanyRequest : PaginationRequest
    {
        public int? companyId { get; set; }
        public int? state { get; set; }
    }
}
