
namespace Employees.Domain.Aggregates.RemunerativeDataAggregate
{
    public interface IRemunerativeDataRepository
    {
        Task<int> Register(RemunerativeData remunerativeData);
        Task<int> RegisterAsync(RemunerativeData remunerativeData);
    }
}
