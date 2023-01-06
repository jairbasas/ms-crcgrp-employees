using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class ContractQuery : IContractQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly IContractMapper _iContractMapper;

        public ContractQuery(IGenericQuery iGenericQuery, IContractMapper iContractMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iContractMapper = iContractMapper ?? throw new ArgumentNullException(nameof(iContractMapper));
        }

        public async Task<Response<ContractViewModel>> GetById(int employeeId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.CONTRACT_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iContractMapper.MapToContractViewModel(result) : null;
            return new Response<ContractViewModel>(items);
        }

        public async Task<Response<IEnumerable<ContractViewModel>>> GetBySearch(ContractRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.Search(@"EMPLOYEES.CONTRACT_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (ContractViewModel)_iContractMapper.MapToContractViewModel(item));

            return new Response<IEnumerable<ContractViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<ContractViewModel>>> GetByFindAll(ContractRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"employee_id", request.employeeId}
            };

            var result = await _iGenericQuery.FindAll(@"EMPLOYEES.CONTRACT_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (ContractViewModel)_iContractMapper.MapToContractViewModel(item));

            return new Response<PaginationViewModel<ContractViewModel>>(new PaginationViewModel<ContractViewModel>(request.pagination, items));
        }
    }
}
