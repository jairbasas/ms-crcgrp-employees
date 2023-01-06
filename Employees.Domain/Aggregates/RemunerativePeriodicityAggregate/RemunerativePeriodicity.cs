using Employees.Domain.Core;

namespace Employees.Domain.Aggregates.RemunerativePeriodicityAggregate
{
    public class RemunerativePeriodicity : Audit
    {
        public int employeeId { get; set; }
        public string periodicityId { get; set; }
        public string paymentTypeId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }

        public RemunerativePeriodicity()
        {
        }

        public RemunerativePeriodicity(int employeeId, string periodicityId, string paymentTypeId, int? registerUserId, string registerUserFullname, DateTime? registerDatetime, int? updateUserId, string updateUserFullname, DateTime? updateDatetime)
        {
            this.employeeId = employeeId;
            this.periodicityId = periodicityId;
            this.paymentTypeId = paymentTypeId;
            this.registerUserId = registerUserId;
            this.registerUserFullname = registerUserFullname;
            this.registerDatetime = registerDatetime;
            this.updateUserId = updateUserId;
            this.updateUserFullname = updateUserFullname;
            this.updateDatetime = updateDatetime;
        }
    }
}
