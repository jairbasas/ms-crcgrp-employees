using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class CompanyQuery : ICompanyQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly ICompanyMapper _iCompanyMapper;

        public CompanyQuery(IGenericQuery iGenericQuery, ICompanyMapper iCompanyMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iCompanyMapper = iCompanyMapper ?? throw new ArgumentNullException(nameof(iCompanyMapper));
        }

        public async Task<Response<CompanyViewModel>> GetById(int companyId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"company_id", companyId}
            };

            var result = await _iGenericQuery.Search(@"TRANSVERSAL.COMPANY_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iCompanyMapper.MapToCompanyViewModel(result) : null;
            return new Response<CompanyViewModel>(items);
        }

        public async Task<Response<IEnumerable<CompanyViewModel>>> GetBySearch(CompanyRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"company_id", request.companyId ?? 0},
                {"state", request.state ?? 0}
            };

            var result = await _iGenericQuery.Search(@"TRANSVERSAL.COMPANY_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (CompanyViewModel)_iCompanyMapper.MapToCompanyViewModel(item));

            return new Response<IEnumerable<CompanyViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<CompanyViewModel>>> GetByFindAll(CompanyRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"company_id", request.companyId ?? 0}
            };

            var result = await _iGenericQuery.FindAll(@"TRANSVERSAL.COMPANY_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (CompanyViewModel)_iCompanyMapper.MapToCompanyViewModel(item));

            return new Response<PaginationViewModel<CompanyViewModel>>(new PaginationViewModel<CompanyViewModel>(request.pagination, items));
        }
    }
}
