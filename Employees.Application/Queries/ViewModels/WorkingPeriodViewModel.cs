using Employees.Application.Queries.ViewModels.Base;

namespace Employees.Application.Queries.ViewModels
{
    public class WorkingPeriodViewModel
    {
        public int employeeId { get; set; }
        public DateTime? dateAdmission { get; set; }
        public decimal? hourDay { get; set; }
        public string shiftId { get; set; }
        public int? tareoDiario { get; set; }
        public int? extraHourTareo { get; set; }
        public string tareoGroupId { get; set; }
        public DateTime? terminationDate { get; set; }
        public string reasonTerminationId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }
    }

    public class WorkingPeriodRequest : PaginationRequest
    {
        public int employeeId { get; set; }
    }
}
