using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface IEmployeeCompanyQuery
    {
        Task<Response<EmployeeCompanyViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<EmployeeCompanyViewModel>>> GetBySearch(EmployeeCompanyRequest request);

        Task<Response<PaginationViewModel<EmployeeCompanyViewModel>>> GetByFindAll(EmployeeCompanyRequest request);
    }
}
