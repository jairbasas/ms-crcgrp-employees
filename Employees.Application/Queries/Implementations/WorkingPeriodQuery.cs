using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class WorkingPeriodQuery : IWorkingPeriodQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly IWorkingPeriodMapper _iWorkingPeriodMapper;

        public WorkingPeriodQuery(IGenericQuery iGenericQuery, IWorkingPeriodMapper iWorkingPeriodMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iWorkingPeriodMapper = iWorkingPeriodMapper ?? throw new ArgumentNullException(nameof(iWorkingPeriodMapper));
        }

        public async Task<Response<WorkingPeriodViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.WORKING_PERIOD_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iWorkingPeriodMapper.MapToWorkingPeriodViewModel(result) : null;
            return new Response<WorkingPeriodViewModel>(items);
        }

        public async Task<Response<IEnumerable<WorkingPeriodViewModel>>> GetBySearch(WorkingPeriodRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.WORKING_PERIOD_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (WorkingPeriodViewModel)_iWorkingPeriodMapper.MapToWorkingPeriodViewModel(item));

            return new Response<IEnumerable<WorkingPeriodViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<WorkingPeriodViewModel>>> GetByFindAll(WorkingPeriodRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.WORKING_PERIOD_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (WorkingPeriodViewModel)_iWorkingPeriodMapper.MapToWorkingPeriodViewModel(item));

            return new Response<PaginationViewModel<WorkingPeriodViewModel>>(new PaginationViewModel<WorkingPeriodViewModel>(request.pagination, items));
        }
    }
}
