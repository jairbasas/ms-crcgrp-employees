using Employees.Domain.Core;

namespace Employees.Domain.Aggregates.SctrAggregate
{
    public class Sctr : Audit
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

        public Sctr()
        {
        }

        public Sctr(int employeeId, int parameterDetailId, string sctrCode, string tasa, int? registerUserId, string registerUserFullname, DateTime? registerDatetime, int? updateUserId, string updateUserFullname, DateTime? updateDatetime)
        {
            this.employeeId = employeeId;
            this.parameterDetailId = parameterDetailId;
            this.sctrCode = sctrCode;
            this.tasa = tasa;
            this.registerUserId = registerUserId;
            this.registerUserFullname = registerUserFullname;
            this.registerDatetime = registerDatetime;
            this.updateUserId = updateUserId;
            this.updateUserFullname = updateUserFullname;
            this.updateDatetime = updateDatetime;
        }
    }
}
