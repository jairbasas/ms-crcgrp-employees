using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface IParameterQuery
    {
        Task<Response<ParameterViewModel>> GetById(int parameterId);

        Task<Response<IEnumerable<ParameterViewModel>>> GetBySearch(ParameterRequest request);

        Task<Response<PaginationViewModel<ParameterViewModel>>> GetByFindAll(ParameterRequest request);
    }
}
