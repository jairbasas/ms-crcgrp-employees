using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface IContractQuery
    {
        Task<Response<ContractViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<ContractViewModel>>> GetBySearch(ContractRequest request);

        Task<Response<PaginationViewModel<ContractViewModel>>> GetByFindAll(ContractRequest request);
    }
}
