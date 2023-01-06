using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class CompensationPaymentQuery : ICompensationPaymentQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly ICompensationPaymentMapper _iCompensationPaymentMapper;

        public CompensationPaymentQuery(IGenericQuery iGenericQuery, ICompensationPaymentMapper iCompensationPaymentMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iCompensationPaymentMapper = iCompensationPaymentMapper ?? throw new ArgumentNullException(nameof(iCompensationPaymentMapper));
        }

        public async Task<Response<CompensationPaymentViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.COMPENSATION_PAYMENT_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iCompensationPaymentMapper.MapToCompensationPaymentViewModel(result) : null;
            return new Response<CompensationPaymentViewModel>(items);
        }

        public async Task<Response<IEnumerable<CompensationPaymentViewModel>>> GetBySearch(CompensationPaymentRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.COMPENSATION_PAYMENT_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (CompensationPaymentViewModel)_iCompensationPaymentMapper.MapToCompensationPaymentViewModel(item));

            return new Response<IEnumerable<CompensationPaymentViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<CompensationPaymentViewModel>>> GetByFindAll(CompensationPaymentRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.COMPENSATION_PAYMENT_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (CompensationPaymentViewModel)_iCompensationPaymentMapper.MapToCompensationPaymentViewModel(item));

            return new Response<PaginationViewModel<CompensationPaymentViewModel>>(new PaginationViewModel<CompensationPaymentViewModel>(request.pagination, items));
        }
    }
}
