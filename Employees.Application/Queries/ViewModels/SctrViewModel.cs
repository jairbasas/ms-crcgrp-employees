using Employees.Application.Queries.ViewModels.Base;

namespace Employees.Application.Queries.ViewModels
{
    public class SctrViewModel
    {
        public int employeeId { get; set; }
        public int parameterDetailId { get; set; }
        public string sctrCode { get; set; }
        public string tasa { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }
    }

    public class SctrRequest : PaginationRequest
    {
        public int employeeId { get; set; }
    }
}
