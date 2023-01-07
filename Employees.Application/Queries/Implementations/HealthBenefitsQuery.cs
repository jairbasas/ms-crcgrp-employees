using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class HealthBenefitsQuery : IHealthBenefitsQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly IHealthBenefitsMapper _iHealthBenefitsMapper;

        public HealthBenefitsQuery(IGenericQuery iGenericQuery, IHealthBenefitsMapper iHealthBenefitsMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iHealthBenefitsMapper = iHealthBenefitsMapper ?? throw new ArgumentNullException(nameof(iHealthBenefitsMapper));
        }

        public async Task<Response<HealthBenefitsViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.HEALTH_BENEFITS_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iHealthBenefitsMapper.MapToHealthBenefitsViewModel(result) : null;
            return new Response<HealthBenefitsViewModel>(items);
        }

        public async Task<Response<IEnumerable<HealthBenefitsViewModel>>> GetBySearch(HealthBenefitsRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.HEALTH_BENEFITS_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (HealthBenefitsViewModel)_iHealthBenefitsMapper.MapToHealthBenefitsViewModel(item));

            return new Response<IEnumerable<HealthBenefitsViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<HealthBenefitsViewModel>>> GetByFindAll(HealthBenefitsRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.HEALTH_BENEFITS_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (HealthBenefitsViewModel)_iHealthBenefitsMapper.MapToHealthBenefitsViewModel(item));

            return new Response<PaginationViewModel<HealthBenefitsViewModel>>(new PaginationViewModel<HealthBenefitsViewModel>(request.pagination, items));
        }
    }
}
