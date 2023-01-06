using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface IMainDataQuery
    {
        Task<Response<MainDataViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<MainDataViewModel>>> GetBySearch(MainDataRequest request);

        Task<Response<PaginationViewModel<MainDataViewModel>>> GetByFindAll(MainDataRequest request);
    }
}
