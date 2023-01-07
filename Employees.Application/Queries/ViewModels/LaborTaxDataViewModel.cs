using Employees.Application.Queries.ViewModels.Base;

namespace Employees.Application.Queries.ViewModels
{
    public class LaborTaxDataViewModel
    {
        public int employeeId { get; set; }
        public int parameterDetailId { get; set; }
        public bool? state { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }
    }

    public class LaborTaxDataRequest : PaginationRequest
    {
        public int employeeId { get; set; }
    }
}
