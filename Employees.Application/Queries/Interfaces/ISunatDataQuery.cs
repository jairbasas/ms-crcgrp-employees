using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface ISunatDataQuery
    {
        Task<Response<SunatDataViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<SunatDataViewModel>>> GetBySearch(SunatDataRequest request);

        Task<Response<PaginationViewModel<SunatDataViewModel>>> GetByFindAll(SunatDataRequest request);
    }
}
