
namespace Employees.Domain.Aggregates.SunatDataAggregate
{
    public interface ISunatDataRepository
    {
        Task<int> Register(SunatData sunatData);
    }
}
