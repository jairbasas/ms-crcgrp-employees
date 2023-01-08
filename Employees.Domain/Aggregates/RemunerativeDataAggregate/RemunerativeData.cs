using Employees.Domain.Aggregates.CompensationPaymentAggregate;
using Employees.Domain.Aggregates.IncomeDiscountAggregate;
using Employees.Domain.Aggregates.RemunerativePeriodicityAggregate;
using Employees.Domain.Aggregates.SalaryPaymentAggregate;
using Employees.Domain.Core;

namespace Employees.Domain.Aggregates.RemunerativeDataAggregate
{
    public class RemunerativeData : Audit
    {
        public int employeeId { get; set; }
        public string salaryTypeId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }
        public IEnumerable<IncomeDiscount> incomeDiscount { get; set; }
        public RemunerativePeriodicity remunerativePeriodicity { get; set; }
        public SalaryPayment salaryPayment { get; set; }
        public CompensationPayment compensationPayment { get; set; }

        public RemunerativeData()
        {
        }

        public RemunerativeData(int employeeId, string salaryTypeId, int? registerUserId, string registerUserFullname, DateTime? registerDatetime, int? updateUserId, string updateUserFullname, DateTime? updateDatetime)
        {
            this.employeeId = employeeId;
            this.salaryTypeId = salaryTypeId;
            this.registerUserId = registerUserId;
            this.registerUserFullname = registerUserFullname;
            this.registerDatetime = registerDatetime;
            this.updateUserId = updateUserId;
            this.updateUserFullname = updateUserFullname;
            this.updateDatetime = updateDatetime;
        }
    }
}
