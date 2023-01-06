using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class UsersQuery : IUsersQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly IUsersMapper _iUsersMapper;

        public UsersQuery(IGenericQuery iGenericQuery, IUsersMapper iUsersMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iUsersMapper = iUsersMapper ?? throw new ArgumentNullException(nameof(iUsersMapper));
        }

        public async Task<Response<UsersViewModel>> GetById(int userId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"user_id", userId}
            };

            var result = await _iGenericQuery.Search(@"TRANSVERSAL.USERS_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iUsersMapper.MapToUsersViewModel(result) : null;
            return new Response<UsersViewModel>(items);
        }

        public async Task<Response<IEnumerable<UsersViewModel>>> GetBySearch(UsersRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"user_id", request.userId}
            };

            var result = await _iGenericQuery.Search(@"TRANSVERSAL.USERS_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (UsersViewModel)_iUsersMapper.MapToUsersViewModel(item));

            return new Response<IEnumerable<UsersViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<UsersViewModel>>> GetByFindAll(UsersRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"user_id", request.userId}
            };

            var result = await _iGenericQuery.FindAll(@"TRANSVERSAL.USERS_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (UsersViewModel)_iUsersMapper.MapToUsersViewModel(item));

            return new Response<PaginationViewModel<UsersViewModel>>(new PaginationViewModel<UsersViewModel>(request.pagination, items));
        }
    }
}
