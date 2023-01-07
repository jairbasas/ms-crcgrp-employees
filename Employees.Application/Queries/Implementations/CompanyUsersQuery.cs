using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class CompanyUsersQuery : ICompanyUsersQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly ICompanyUsersMapper _iCompanyUsersMapper;

        public CompanyUsersQuery(IGenericQuery iGenericQuery, ICompanyUsersMapper iCompanyUsersMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iCompanyUsersMapper = iCompanyUsersMapper ?? throw new ArgumentNullException(nameof(iCompanyUsersMapper));
        }

        public async Task<Response<CompanyUsersViewModel>> GetById(int companyUserId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"company_user_id", companyUserId}
            };

            var result = await _iGenericQuery.Search(@"TRANSVERSAL.COMPANY_USERS_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iCompanyUsersMapper.MapToCompanyUsersViewModel(result) : null;
            return new Response<CompanyUsersViewModel>(items);
        }

        public async Task<Response<IEnumerable<CompanyUsersViewModel>>> GetBySearch(CompanyUsersRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"company_user_id", request.companyUserId ?? 0},
                {"company_id", request.companyId ?? 0},
                {"user_id", request.userId ?? 0}
            };

            var result = await _iGenericQuery.Search(@"TRANSVERSAL.COMPANY_USERS_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (CompanyUsersViewModel)_iCompanyUsersMapper.MapToCompanyUsersViewModel(item));

            return new Response<IEnumerable<CompanyUsersViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<CompanyUsersViewModel>>> GetByFindAll(CompanyUsersRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"company_user_id", request.companyUserId ?? 0}
            };

            var result = await _iGenericQuery.FindAll(@"TRANSVERSAL.COMPANY_USERS_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (CompanyUsersViewModel)_iCompanyUsersMapper.MapToCompanyUsersViewModel(item));

            return new Response<PaginationViewModel<CompanyUsersViewModel>>(new PaginationViewModel<CompanyUsersViewModel>(request.pagination, items));
        }
    }
}
