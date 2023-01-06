using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface IWorkingPeriodQuery
    {
        Task<Response<WorkingPeriodViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<WorkingPeriodViewModel>>> GetBySearch(WorkingPeriodRequest request);

        Task<Response<PaginationViewModel<WorkingPeriodViewModel>>> GetByFindAll(WorkingPeriodRequest request);
    }
}
