using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class LaborDataQuery : ILaborDataQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly ILaborDataMapper _iLaborDataMapper;

        public LaborDataQuery(IGenericQuery iGenericQuery, ILaborDataMapper iLaborDataMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iLaborDataMapper = iLaborDataMapper ?? throw new ArgumentNullException(nameof(iLaborDataMapper));
        }

        public async Task<Response<LaborDataViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.LABOR_DATA_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iLaborDataMapper.MapToLaborDataViewModel(result) : null;
            return new Response<LaborDataViewModel>(items);
        }

        public async Task<Response<IEnumerable<LaborDataViewModel>>> GetBySearch(LaborDataRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.LABOR_DATA_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (LaborDataViewModel)_iLaborDataMapper.MapToLaborDataViewModel(item));

            return new Response<IEnumerable<LaborDataViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<LaborDataViewModel>>> GetByFindAll(LaborDataRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.LABOR_DATA_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (LaborDataViewModel)_iLaborDataMapper.MapToLaborDataViewModel(item));

            return new Response<PaginationViewModel<LaborDataViewModel>>(new PaginationViewModel<LaborDataViewModel>(request.pagination, items));
        }
    }
}
