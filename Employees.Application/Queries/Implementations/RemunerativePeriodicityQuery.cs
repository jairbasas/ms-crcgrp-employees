using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class RemunerativePeriodicityQuery : IRemunerativePeriodicityQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly IRemunerativePeriodicityMapper _iRemunerativePeriodicityMapper;

        public RemunerativePeriodicityQuery(IGenericQuery iGenericQuery, IRemunerativePeriodicityMapper iRemunerativePeriodicityMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iRemunerativePeriodicityMapper = iRemunerativePeriodicityMapper ?? throw new ArgumentNullException(nameof(iRemunerativePeriodicityMapper));
        }

        public async Task<Response<RemunerativePeriodicityViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.REMUNERATIVE_PERIODICITY_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iRemunerativePeriodicityMapper.MapToRemunerativePeriodicityViewModel(result) : null;
            return new Response<RemunerativePeriodicityViewModel>(items);
        }

        public async Task<Response<IEnumerable<RemunerativePeriodicityViewModel>>> GetBySearch(RemunerativePeriodicityRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.REMUNERATIVE_PERIODICITY_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (RemunerativePeriodicityViewModel)_iRemunerativePeriodicityMapper.MapToRemunerativePeriodicityViewModel(item));

            return new Response<IEnumerable<RemunerativePeriodicityViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<RemunerativePeriodicityViewModel>>> GetByFindAll(RemunerativePeriodicityRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.REMUNERATIVE_PERIODICITY_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (RemunerativePeriodicityViewModel)_iRemunerativePeriodicityMapper.MapToRemunerativePeriodicityViewModel(item));

            return new Response<PaginationViewModel<RemunerativePeriodicityViewModel>>(new PaginationViewModel<RemunerativePeriodicityViewModel>(request.pagination, items));
        }
    }
}
