using Employees.Domain.Core;

namespace Employees.Domain.Aggregates.IncomeDiscountAggregate
{
    public class IncomeDiscount : Audit
    {
        public int employeeId { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string currencyId { get; set; }
        public decimal? amount { get; set; }
        public bool? state { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }

        public IncomeDiscount()
        {
        }

        public IncomeDiscount(int employeeId, string code, string description, string currencyId, decimal? amount, bool? state, int? registerUserId, string registerUserFullname, DateTime? registerDatetime, int? updateUserId, string updateUserFullname, DateTime? updateDatetime)
        {
            this.employeeId = employeeId;
            this.code = code;
            this.description = description;
            this.currencyId = currencyId;
            this.amount = amount;
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
