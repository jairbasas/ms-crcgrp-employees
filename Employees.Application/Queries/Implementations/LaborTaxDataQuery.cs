using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class LaborTaxDataQuery : ILaborTaxDataQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly ILaborTaxDataMapper _iLaborTaxDataMapper;

        public LaborTaxDataQuery(IGenericQuery iGenericQuery, ILaborTaxDataMapper iLaborTaxDataMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iLaborTaxDataMapper = iLaborTaxDataMapper ?? throw new ArgumentNullException(nameof(iLaborTaxDataMapper));
        }

        public async Task<Response<LaborTaxDataViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.LABOR_TAX_DATA_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iLaborTaxDataMapper.MapToLaborTaxDataViewModel(result) : null;
            return new Response<LaborTaxDataViewModel>(items);
        }

        public async Task<Response<IEnumerable<LaborTaxDataViewModel>>> GetBySearch(LaborTaxDataRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.LABOR_TAX_DATA_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (LaborTaxDataViewModel)_iLaborTaxDataMapper.MapToLaborTaxDataViewModel(item));

            return new Response<IEnumerable<LaborTaxDataViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<LaborTaxDataViewModel>>> GetByFindAll(LaborTaxDataRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.LABOR_TAX_DATA_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (LaborTaxDataViewModel)_iLaborTaxDataMapper.MapToLaborTaxDataViewModel(item));

            return new Response<PaginationViewModel<LaborTaxDataViewModel>>(new PaginationViewModel<LaborTaxDataViewModel>(request.pagination, items));
        }
    }
}
