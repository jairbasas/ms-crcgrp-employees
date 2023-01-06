using Employees.Domain.Core;

namespace Employees.Domain.Aggregates.CompensationPaymentAggregate
{
    public class CompensationPayment : Audit
    {
        public int employeeId { get; set; }
        public string accountNumber { get; set; }
        public string interbankAccount { get; set; }
        public string bankId { get; set; }
        public string accountTypeId { get; set; }
        public string currencyId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }

        public CompensationPayment()
        {
        }

        public CompensationPayment(int employeeId, string accountNumber, string interbankAccount, string bankId, string accountTypeId, string currencyId, int? registerUserId, string registerUserFullname, DateTime? registerDatetime, int? updateUserId, string updateUserFullname, DateTime? updateDatetime)
        {
            this.employeeId = employeeId;
            this.accountNumber = accountNumber;
            this.interbankAccount = interbankAccount;
            this.bankId = bankId;
            this.accountTypeId = accountTypeId;
            this.currencyId = currencyId;
            this.registerUserId = registerUserId;
            this.registerUserFullname = registerUserFullname;
            this.registerDatetime = registerDatetime;
            this.updateUserId = updateUserId;
            this.updateUserFullname = updateUserFullname;
            this.updateDatetime = updateDatetime;
        }
    }
}
