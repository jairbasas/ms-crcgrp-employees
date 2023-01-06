using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface IParameterDetailQuery
    {
        Task<Response<ParameterDetailViewModel>> GetById(int parameterDetailId);

        Task<Response<IEnumerable<ParameterDetailViewModel>>> GetBySearch(ParameterDetailRequest request);

        Task<Response<PaginationViewModel<ParameterDetailViewModel>>> GetByFindAll(ParameterDetailRequest request);
    }
}
