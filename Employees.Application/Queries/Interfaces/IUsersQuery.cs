using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface IUsersQuery
    {
        Task<Response<UsersViewModel>> GetById(int userId);

        Task<Response<IEnumerable<UsersViewModel>>> GetBySearch(UsersRequest request);

        Task<Response<PaginationViewModel<UsersViewModel>>> GetByFindAll(UsersRequest request);
    }
}
