using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class SalaryPaymentQuery : ISalaryPaymentQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly ISalaryPaymentMapper _iSalaryPaymentMapper;

        public SalaryPaymentQuery(IGenericQuery iGenericQuery, ISalaryPaymentMapper iSalaryPaymentMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iSalaryPaymentMapper = iSalaryPaymentMapper ?? throw new ArgumentNullException(nameof(iSalaryPaymentMapper));
        }

        public async Task<Response<SalaryPaymentViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.SALARY_PAYMENT_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iSalaryPaymentMapper.MapToSalaryPaymentViewModel(result) : null;
            return new Response<SalaryPaymentViewModel>(items);
        }

        public async Task<Response<IEnumerable<SalaryPaymentViewModel>>> GetBySearch(SalaryPaymentRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.SALARY_PAYMENT_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (SalaryPaymentViewModel)_iSalaryPaymentMapper.MapToSalaryPaymentViewModel(item));

            return new Response<IEnumerable<SalaryPaymentViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<SalaryPaymentViewModel>>> GetByFindAll(SalaryPaymentRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.SALARY_PAYMENT_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (SalaryPaymentViewModel)_iSalaryPaymentMapper.MapToSalaryPaymentViewModel(item));

            return new Response<PaginationViewModel<SalaryPaymentViewModel>>(new PaginationViewModel<SalaryPaymentViewModel>(request.pagination, items));
        }
    }
}
