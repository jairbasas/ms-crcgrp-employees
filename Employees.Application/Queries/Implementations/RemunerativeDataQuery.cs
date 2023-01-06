using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class RemunerativeDataQuery : IRemunerativeDataQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly IRemunerativeDataMapper _iRemunerativeDataMapper;

        public RemunerativeDataQuery(IGenericQuery iGenericQuery, IRemunerativeDataMapper iRemunerativeDataMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iRemunerativeDataMapper = iRemunerativeDataMapper ?? throw new ArgumentNullException(nameof(iRemunerativeDataMapper));
        }

        public async Task<Response<RemunerativeDataViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.REMUNERATIVE_DATA_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iRemunerativeDataMapper.MapToRemunerativeDataViewModel(result) : null;
            return new Response<RemunerativeDataViewModel>(items);
        }

        public async Task<Response<IEnumerable<RemunerativeDataViewModel>>> GetBySearch(RemunerativeDataRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.REMUNERATIVE_DATA_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (RemunerativeDataViewModel)_iRemunerativeDataMapper.MapToRemunerativeDataViewModel(item));

            return new Response<IEnumerable<RemunerativeDataViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<RemunerativeDataViewModel>>> GetByFindAll(RemunerativeDataRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.REMUNERATIVE_DATA_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (RemunerativeDataViewModel)_iRemunerativeDataMapper.MapToRemunerativeDataViewModel(item));

            return new Response<PaginationViewModel<RemunerativeDataViewModel>>(new PaginationViewModel<RemunerativeDataViewModel>(request.pagination, items));
        }
    }
}
