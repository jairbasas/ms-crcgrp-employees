using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class MainDataQuery : IMainDataQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly IMainDataMapper _iMainDataMapper;

        public MainDataQuery(IGenericQuery iGenericQuery, IMainDataMapper iMainDataMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iMainDataMapper = iMainDataMapper ?? throw new ArgumentNullException(nameof(iMainDataMapper));
        }

        public async Task<Response<MainDataViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.MAIN_DATA_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iMainDataMapper.MapToMainDataViewModel(result) : null;
            return new Response<MainDataViewModel>(items);
        }

        public async Task<Response<IEnumerable<MainDataViewModel>>> GetBySearch(MainDataRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.MAIN_DATA_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (MainDataViewModel)_iMainDataMapper.MapToMainDataViewModel(item));

            return new Response<IEnumerable<MainDataViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<MainDataViewModel>>> GetByFindAll(MainDataRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.MAIN_DATA_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (MainDataViewModel)_iMainDataMapper.MapToMainDataViewModel(item));

            return new Response<PaginationViewModel<MainDataViewModel>>(new PaginationViewModel<MainDataViewModel>(request.pagination, items));
        }
    }
}
