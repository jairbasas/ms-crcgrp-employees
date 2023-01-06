
namespace Employees.Domain.Aggregates.IncomeDiscountAggregate
{
    public interface IIncomeDiscountRepository
    {
        Task<int> Register(IncomeDiscount incomeDiscount);
    }
}
