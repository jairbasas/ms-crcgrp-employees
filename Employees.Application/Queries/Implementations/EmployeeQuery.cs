using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class EmployeeQuery : IEmployeeQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly IEmployeeMapper _iEmployeeMapper;

        public EmployeeQuery(IGenericQuery iGenericQuery, IEmployeeMapper iEmployeeMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iEmployeeMapper = iEmployeeMapper ?? throw new ArgumentNullException(nameof(iEmployeeMapper));
        }

        public async Task<Response<EmployeeViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.EMPLOYEE_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iEmployeeMapper.MapToEmployeeViewModel(result) : null;
            return new Response<EmployeeViewModel>(items);
        }

        public async Task<Response<IEnumerable<EmployeeViewModel>>> GetBySearch(EmployeeRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.EMPLOYEE_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (EmployeeViewModel)_iEmployeeMapper.MapToEmployeeViewModel(item));

            return new Response<IEnumerable<EmployeeViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<EmployeeViewModel>>> GetByFindAll(EmployeeRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.EMPLOYEE_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (EmployeeViewModel)_iEmployeeMapper.MapToEmployeeViewModel(item));

            return new Response<PaginationViewModel<EmployeeViewModel>>(new PaginationViewModel<EmployeeViewModel>(request.pagination, items));
        }
    }
}
