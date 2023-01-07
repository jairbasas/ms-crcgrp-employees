
namespace Employees.Domain.Aggregates.SctrAggregate
{
    public interface ISctrRepository
    {
        Task<int> Register(Sctr sctr);
    }
}
