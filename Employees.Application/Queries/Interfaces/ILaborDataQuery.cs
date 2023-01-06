using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface ILaborDataQuery
    {
        Task<Response<LaborDataViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<LaborDataViewModel>>> GetBySearch(LaborDataRequest request);

        Task<Response<PaginationViewModel<LaborDataViewModel>>> GetByFindAll(LaborDataRequest request);
    }
}
