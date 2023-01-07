using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class SunatRemunerationDataQuery : ISunatRemunerationDataQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly ISunatRemunerationDataMapper _iSunatRemunerationDataMapper;

        public SunatRemunerationDataQuery(IGenericQuery iGenericQuery, ISunatRemunerationDataMapper iSunatRemunerationDataMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iSunatRemunerationDataMapper = iSunatRemunerationDataMapper ?? throw new ArgumentNullException(nameof(iSunatRemunerationDataMapper));
        }

        public async Task<Response<SunatRemunerationDataViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.SUNAT_REMUNERATION_DATA_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iSunatRemunerationDataMapper.MapToSunatRemunerationDataViewModel(result) : null;
            return new Response<SunatRemunerationDataViewModel>(items);
        }

        public async Task<Response<IEnumerable<SunatRemunerationDataViewModel>>> GetBySearch(SunatRemunerationDataRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.SUNAT_REMUNERATION_DATA_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (SunatRemunerationDataViewModel)_iSunatRemunerationDataMapper.MapToSunatRemunerationDataViewModel(item));

            return new Response<IEnumerable<SunatRemunerationDataViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<SunatRemunerationDataViewModel>>> GetByFindAll(SunatRemunerationDataRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.SUNAT_REMUNERATION_DATA_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (SunatRemunerationDataViewModel)_iSunatRemunerationDataMapper.MapToSunatRemunerationDataViewModel(item));

            return new Response<PaginationViewModel<SunatRemunerationDataViewModel>>(new PaginationViewModel<SunatRemunerationDataViewModel>(request.pagination, items));
        }
    }
}
