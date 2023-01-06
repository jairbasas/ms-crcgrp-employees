using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface ISalaryPaymentQuery
    {
        Task<Response<SalaryPaymentViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<SalaryPaymentViewModel>>> GetBySearch(SalaryPaymentRequest request);

        Task<Response<PaginationViewModel<SalaryPaymentViewModel>>> GetByFindAll(SalaryPaymentRequest request);
    }
}
