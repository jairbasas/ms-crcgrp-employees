using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface IRemunerativeDataQuery
    {
        Task<Response<RemunerativeDataViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<RemunerativeDataViewModel>>> GetBySearch(RemunerativeDataRequest request);

        Task<Response<PaginationViewModel<RemunerativeDataViewModel>>> GetByFindAll(RemunerativeDataRequest request);
    }
}
