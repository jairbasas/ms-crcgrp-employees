
namespace Employees.Domain.Aggregates.UsersAggregate
{
    public interface IUsersRepository
    {
        Task<int> Register(Users users);
    }
}
