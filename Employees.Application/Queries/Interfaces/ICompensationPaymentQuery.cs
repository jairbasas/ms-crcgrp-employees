using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface ICompensationPaymentQuery
    {
        Task<Response<CompensationPaymentViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<CompensationPaymentViewModel>>> GetBySearch(CompensationPaymentRequest request);

        Task<Response<PaginationViewModel<CompensationPaymentViewModel>>> GetByFindAll(CompensationPaymentRequest request);
    }
}
