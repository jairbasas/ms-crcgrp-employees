using Employees.Domain.Core;

namespace Employees.Domain.Aggregates.CompanyAggregate
{
    public class Company : Audit
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

        public Company()
        {
        }

        public Company(int companyId, string businessName, string tradename, string documentNumber, int? state, int? registerUserId, string registerUserFullname, DateTime? registerDatetime, int? updateUserId, string updateUserFullname, DateTime? updateDatetime)
        {
            this.companyId = companyId;
            this.businessName = businessName;
            this.tradename = tradename;
            this.documentNumber = documentNumber;
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
