using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface ICompanyUsersQuery
    {
        Task<Response<CompanyUsersViewModel>> GetById(int companyUserId);

        Task<Response<IEnumerable<CompanyUsersViewModel>>> GetBySearch(CompanyUsersRequest request);

        Task<Response<PaginationViewModel<CompanyUsersViewModel>>> GetByFindAll(CompanyUsersRequest request);
    }
}
