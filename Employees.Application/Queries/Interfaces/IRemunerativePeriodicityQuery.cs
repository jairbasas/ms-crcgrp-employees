using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface IRemunerativePeriodicityQuery
    {
        Task<Response<RemunerativePeriodicityViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<RemunerativePeriodicityViewModel>>> GetBySearch(RemunerativePeriodicityRequest request);

        Task<Response<PaginationViewModel<RemunerativePeriodicityViewModel>>> GetByFindAll(RemunerativePeriodicityRequest request);
    }
}
