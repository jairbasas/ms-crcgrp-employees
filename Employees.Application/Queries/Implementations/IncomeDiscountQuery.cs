using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class IncomeDiscountQuery : IIncomeDiscountQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly IIncomeDiscountMapper _iIncomeDiscountMapper;

        public IncomeDiscountQuery(IGenericQuery iGenericQuery, IIncomeDiscountMapper iIncomeDiscountMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iIncomeDiscountMapper = iIncomeDiscountMapper ?? throw new ArgumentNullException(nameof(iIncomeDiscountMapper));
        }

        public async Task<Response<IncomeDiscountViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.INCOME_DISCOUNT_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iIncomeDiscountMapper.MapToIncomeDiscountViewModel(result) : null;
            return new Response<IncomeDiscountViewModel>(items);
        }

        public async Task<Response<IEnumerable<IncomeDiscountViewModel>>> GetBySearch(IncomeDiscountRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.INCOME_DISCOUNT_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (IncomeDiscountViewModel)_iIncomeDiscountMapper.MapToIncomeDiscountViewModel(item));

            return new Response<IEnumerable<IncomeDiscountViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<IncomeDiscountViewModel>>> GetByFindAll(IncomeDiscountRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.INCOME_DISCOUNT_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (IncomeDiscountViewModel)_iIncomeDiscountMapper.MapToIncomeDiscountViewModel(item));

            return new Response<PaginationViewModel<IncomeDiscountViewModel>>(new PaginationViewModel<IncomeDiscountViewModel>(request.pagination, items));
        }
    }
}
