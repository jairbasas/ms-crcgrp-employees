
namespace Employees.Domain.Aggregates.CompanyUsersAggregate
{
    public interface ICompanyUsersRepository
    {
        Task<int> Register(CompanyUsers users);
    }
}
