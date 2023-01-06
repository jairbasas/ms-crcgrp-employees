
namespace Employees.Domain.Aggregates.CompensationPaymentAggregate
{
    public interface ICompensationPaymentRepository
    {
        Task<int> Register(CompensationPayment compensationPayment);
    }
}
