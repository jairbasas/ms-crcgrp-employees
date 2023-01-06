using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface IIncomeDiscountQuery
    {
        Task<Response<IncomeDiscountViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<IncomeDiscountViewModel>>> GetBySearch(IncomeDiscountRequest request);

        Task<Response<PaginationViewModel<IncomeDiscountViewModel>>> GetByFindAll(IncomeDiscountRequest request);
    }
}
