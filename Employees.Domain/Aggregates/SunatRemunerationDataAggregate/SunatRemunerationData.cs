using Employees.Domain.Core;

namespace Employees.Domain.Aggregates.SunatRemunerationDataAggregate
{
    public class SunatRemunerationData : Audit
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

        public SunatRemunerationData()
        {
        }

        public SunatRemunerationData(int employeeId, int parameterDetailId, bool? state, int? registerUserId, string registerUserFullname, DateTime? registerDatetime, int? updateUserId, string updateUserFullname, DateTime? updateDatetime)
        {
            this.employeeId = employeeId;
            this.parameterDetailId = parameterDetailId;
            this.state = state;
            this.registerUserId = registerUserId;
            this.registerUserFullname = registerUserFullname;
            this.registerDatetime = registerDatetime;
            this.updateUserId = updateUserId;
            this.updateUserFullname = updateUserFullname;
            this.updateDatetime = updateDatetime;
        }
    }
}
