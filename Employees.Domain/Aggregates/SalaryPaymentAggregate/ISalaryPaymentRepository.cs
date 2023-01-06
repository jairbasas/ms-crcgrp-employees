
namespace Employees.Domain.Aggregates.SalaryPaymentAggregate
{
    public interface ISalaryPaymentRepository
    {
        Task<int> Register(SalaryPayment salaryPayment);
    }
}
