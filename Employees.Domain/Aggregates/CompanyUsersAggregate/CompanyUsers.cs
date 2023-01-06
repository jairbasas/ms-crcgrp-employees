using Employees.Domain.Core;

namespace Employees.Domain.Aggregates.CompanyUsersAggregate
{
    public class CompanyUsers : Audit
    {
        public int companyUserId { get; set; }
        public int? userId { get; set; }
        public int? companyId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }
        public int? state { get; set; }

        public CompanyUsers()
        {
        }

        public CompanyUsers(int companyUserId, int? userId, int? companyId, int? registerUserId, string registerUserFullname, DateTime? registerDatetime, int? updateUserId, string updateUserFullname, DateTime? updateDatetime, int? state)
        {
            this.companyUserId = companyUserId;
            this.userId = userId;
            this.companyId = companyId;
            this.registerUserId = registerUserId;
            this.registerUserFullname = registerUserFullname;
            this.registerDatetime = registerDatetime;
            this.updateUserId = updateUserId;
            this.updateUserFullname = updateUserFullname;
            this.updateDatetime = updateDatetime;
            this.state = state;
        }
    }
}
