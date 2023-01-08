
namespace Employees.Domain.Aggregates.LaborDataAggregate
{
    public interface ILaborDataRepository
    {
        Task<int> Register(LaborData laborData);
        Task<int> RegisterAsync(LaborData laborData);
    }
}
