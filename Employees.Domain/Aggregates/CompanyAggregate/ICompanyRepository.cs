
namespace Employees.Domain.Aggregates.CompanyAggregate
{
    public interface ICompanyRepository
    {
        Task<int> Register(Company company);
    }
}
