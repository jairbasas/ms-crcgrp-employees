using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface ISctrQuery
    {
        Task<Response<SctrViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<SctrViewModel>>> GetBySearch(SctrRequest request);

        Task<Response<PaginationViewModel<SctrViewModel>>> GetByFindAll(SctrRequest request);
    }
}
