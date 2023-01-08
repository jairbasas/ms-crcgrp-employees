
namespace Employees.Domain.Aggregates.MainDataAggregate
{
    public interface IMainDataRepository
    {
        Task<int> Register(MainData mainData);
        Task<int> RegisterAsync(MainData mainData);
    }
}
