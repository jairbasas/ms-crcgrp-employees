using Employees.Domain.Core;

namespace Employees.Domain.Aggregates.LaborDataAggregate
{
    public class LaborData : Audit
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

        public LaborData()
        {
        }

        public LaborData(int employeeId, decimal? salaryAdvance, string reference, DateTime? testEndDate, string employeeTypeId, string educationalSituationId, string occupationId, string positionId, string costCenterId, string specialSituationId, string laborRegimeId, string essaludVidaId, string serviceUnitId, string areaSeccionId, string trustPositionId, string accountCategoryId, string workTypeId, int? registerUserId, string registerUserFullname, DateTime? registerDatetime, int? updateUserId, string updateUserFullname, DateTime? updateDatetime)
        {
            this.employeeId = employeeId;
            this.salaryAdvance = salaryAdvance;
            this.reference = reference;
            this.testEndDate = testEndDate;
            this.employeeTypeId = employeeTypeId;
            this.educationalSituationId = educationalSituationId;
            this.occupationId = occupationId;
            this.positionId = positionId;
            this.costCenterId = costCenterId;
            this.specialSituationId = specialSituationId;
            this.laborRegimeId = laborRegimeId;
            this.essaludVidaId = essaludVidaId;
            this.serviceUnitId = serviceUnitId;
            this.areaSeccionId = areaSeccionId;
            this.trustPositionId = trustPositionId;
            this.accountCategoryId = accountCategoryId;
            this.workTypeId = workTypeId;
            this.registerUserId = registerUserId;
            this.registerUserFullname = registerUserFullname;
            this.registerDatetime = registerDatetime;
            this.updateUserId = updateUserId;
            this.updateUserFullname = updateUserFullname;
            this.updateDatetime = updateDatetime;
        }
    }
}
