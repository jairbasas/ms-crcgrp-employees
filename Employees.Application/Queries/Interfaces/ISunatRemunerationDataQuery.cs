using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface ISunatRemunerationDataQuery
    {
        Task<Response<SunatRemunerationDataViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<SunatRemunerationDataViewModel>>> GetBySearch(SunatRemunerationDataRequest request);

        Task<Response<PaginationViewModel<SunatRemunerationDataViewModel>>> GetByFindAll(SunatRemunerationDataRequest request);
    }
}
