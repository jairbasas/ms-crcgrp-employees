
namespace Employees.Domain.Aggregates.CompanyUsersAggregate
{
    public interface ICompanyUsersRepository
    {
        Task<int> Register(CompanyUsers companyUsers);
        Task<int> RegisterAsync(CompanyUsers companyUsers);
    }
}
