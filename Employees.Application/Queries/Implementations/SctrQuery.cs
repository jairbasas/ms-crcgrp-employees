using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class SctrQuery : ISctrQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly ISctrMapper _iSctrMapper;

        public SctrQuery(IGenericQuery iGenericQuery, ISctrMapper iSctrMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iSctrMapper = iSctrMapper ?? throw new ArgumentNullException(nameof(iSctrMapper));
        }

        public async Task<Response<SctrViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.SCTR_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iSctrMapper.MapToSctrViewModel(result) : null;
            return new Response<SctrViewModel>(items);
        }

        public async Task<Response<IEnumerable<SctrViewModel>>> GetBySearch(SctrRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.SCTR_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (SctrViewModel)_iSctrMapper.MapToSctrViewModel(item));

            return new Response<IEnumerable<SctrViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<SctrViewModel>>> GetByFindAll(SctrRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.SCTR_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (SctrViewModel)_iSctrMapper.MapToSctrViewModel(item));

            return new Response<PaginationViewModel<SctrViewModel>>(new PaginationViewModel<SctrViewModel>(request.pagination, items));
        }
    }
}
