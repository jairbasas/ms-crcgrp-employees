
namespace Employees.Domain.Aggregates.EmployeeAggregate
{
    public interface IEmployeeRepository
    {
        Task<int> Register(Employee employee);
    }
}
