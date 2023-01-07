
namespace Employees.Domain.Aggregates.LaborTaxDataAggregate
{
    public interface ILaborTaxDataRepository
    {
        Task<int> Register(LaborTaxData laborTaxData);
    }
}
