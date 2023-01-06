using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface ICompanyQuery
    {
        Task<Response<CompanyViewModel>> GetById(int companyId);

        Task<Response<IEnumerable<CompanyViewModel>>> GetBySearch(CompanyRequest request);

        Task<Response<PaginationViewModel<CompanyViewModel>>> GetByFindAll(CompanyRequest request);
    }
}
