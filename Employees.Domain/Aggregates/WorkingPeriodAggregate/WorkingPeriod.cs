using Employees.Domain.Core;

namespace Employees.Domain.Aggregates.WorkingPeriodAggregate
{
    public class WorkingPeriod : Audit
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

        public WorkingPeriod()
        {
        }

        public WorkingPeriod(int employeeId, DateTime? dateAdmission, decimal? hourDay, string shiftId, int? tareoDiario, int? extraHourTareo, string tareoGroupId, DateTime? terminationDate, string reasonTerminationId, int? registerUserId, string registerUserFullname, DateTime? registerDatetime, int? updateUserId, string updateUserFullname, DateTime? updateDatetime)
        {
            this.employeeId = employeeId;
            this.dateAdmission = dateAdmission;
            this.hourDay = hourDay;
            this.shiftId = shiftId;
            this.tareoDiario = tareoDiario;
            this.extraHourTareo = extraHourTareo;
            this.tareoGroupId = tareoGroupId;
            this.terminationDate = terminationDate;
            this.reasonTerminationId = reasonTerminationId;
            this.registerUserId = registerUserId;
            this.registerUserFullname = registerUserFullname;
            this.registerDatetime = registerDatetime;
            this.updateUserId = updateUserId;
            this.updateUserFullname = updateUserFullname;
            this.updateDatetime = updateDatetime;
        }
    }
}
