using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class EmployeeCompanyQuery : IEmployeeCompanyQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly IEmployeeCompanyMapper _iEmployeeCompanyMapper;

        public EmployeeCompanyQuery(IGenericQuery iGenericQuery, IEmployeeCompanyMapper iEmployeeCompanyMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iEmployeeCompanyMapper = iEmployeeCompanyMapper ?? throw new ArgumentNullException(nameof(iEmployeeCompanyMapper));
        }

        public async Task<Response<EmployeeCompanyViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.EMPLOYEE_COMPANY_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iEmployeeCompanyMapper.MapToEmployeeCompanyViewModel(result) : null;
            return new Response<EmployeeCompanyViewModel>(items);
        }

        public async Task<Response<IEnumerable<EmployeeCompanyViewModel>>> GetBySearch(EmployeeCompanyRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId ?? 0},
                {"company_id", request.companyId ?? 0}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.EMPLOYEE_COMPANY_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (EmployeeCompanyViewModel)_iEmployeeCompanyMapper.MapToEmployeeCompanyViewModel(item));

            return new Response<IEnumerable<EmployeeCompanyViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<EmployeeCompanyViewModel>>> GetByFindAll(EmployeeCompanyRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId ?? 0}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.EMPLOYEE_COMPANY_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (EmployeeCompanyViewModel)_iEmployeeCompanyMapper.MapToEmployeeCompanyViewModel(item));

            return new Response<PaginationViewModel<EmployeeCompanyViewModel>>(new PaginationViewModel<EmployeeCompanyViewModel>(request.pagination, items));
        }
    }
}
