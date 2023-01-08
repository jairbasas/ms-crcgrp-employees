
namespace Employees.Domain.Aggregates.EmployeeCompanyAggregate
{
    public interface IEmployeeCompanyRepository
    {
        Task<int> Register(EmployeeCompany employeeCompany);
    }
}
