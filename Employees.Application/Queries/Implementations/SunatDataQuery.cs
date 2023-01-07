using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class SunatDataQuery : ISunatDataQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly ISunatDataMapper _iSunatDataMapper;

        public SunatDataQuery(IGenericQuery iGenericQuery, ISunatDataMapper iSunatDataMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iSunatDataMapper = iSunatDataMapper ?? throw new ArgumentNullException(nameof(iSunatDataMapper));
        }

        public async Task<Response<SunatDataViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.SUNAT_DATA_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iSunatDataMapper.MapToSunatDataViewModel(result) : null;
            return new Response<SunatDataViewModel>(items);
        }

        public async Task<Response<IEnumerable<SunatDataViewModel>>> GetBySearch(SunatDataRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.SUNAT_DATA_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (SunatDataViewModel)_iSunatDataMapper.MapToSunatDataViewModel(item));

            return new Response<IEnumerable<SunatDataViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<SunatDataViewModel>>> GetByFindAll(SunatDataRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.SUNAT_DATA_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (SunatDataViewModel)_iSunatDataMapper.MapToSunatDataViewModel(item));

            return new Response<PaginationViewModel<SunatDataViewModel>>(new PaginationViewModel<SunatDataViewModel>(request.pagination, items));
        }
    }
}
