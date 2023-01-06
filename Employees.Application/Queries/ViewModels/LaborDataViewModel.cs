using Employees.Application.Queries.ViewModels.Base;

namespace Employees.Application.Queries.ViewModels
{
    public class LaborDataViewModel
    {
        public int employeeId { get; set; }
        public decimal? salaryAdvance { get; set; }
        public string reference { get; set; }
        public DateTime? testEndDate { get; set; }
        public string employeeTypeId { get; set; }
        public string educationalSituationId { get; set; }
        public string occupationId { get; set; }
        public string positionId { get; set; }
        public string costCenterId { get; set; }
        public string specialSituationId { get; set; }
        public string laborRegimeId { get; set; }
        public string essaludVidaId { get; set; }
        public string serviceUnitId { get; set; }
        public string areaSeccionId { get; set; }
        public string trustPositionId { get; set; }
        public string accountCategoryId { get; set; }
        public string workTypeId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }
    }

    public class LaborDataRequest : PaginationRequest
    {
        public int employeeId { get; set; }
    }
}
