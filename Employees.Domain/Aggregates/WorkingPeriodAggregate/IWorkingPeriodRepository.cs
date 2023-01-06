
namespace Employees.Domain.Aggregates.WorkingPeriodAggregate
{
    public interface IWorkingPeriodRepository
    {
        Task<int> Register(WorkingPeriod workingPeriod);
    }
}
