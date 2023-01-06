
namespace Employees.Domain.Aggregates.RemunerativePeriodicityAggregate
{
    public interface IRemunerativePeriodicityRepository
    {
        Task<int> Register(RemunerativePeriodicity remunerativePeriodicity);
    }
}
