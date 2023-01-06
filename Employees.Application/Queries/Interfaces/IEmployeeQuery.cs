using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface IEmployeeQuery
    {
        Task<Response<EmployeeViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<EmployeeViewModel>>> GetBySearch(EmployeeRequest request);

        Task<Response<PaginationViewModel<EmployeeViewModel>>> GetByFindAll(EmployeeRequest request);
    }
}
