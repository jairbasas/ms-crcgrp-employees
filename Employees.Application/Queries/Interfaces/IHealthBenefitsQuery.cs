using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface IHealthBenefitsQuery
    {
        Task<Response<HealthBenefitsViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<HealthBenefitsViewModel>>> GetBySearch(HealthBenefitsRequest request);

        Task<Response<PaginationViewModel<HealthBenefitsViewModel>>> GetByFindAll(HealthBenefitsRequest request);
    }
}
