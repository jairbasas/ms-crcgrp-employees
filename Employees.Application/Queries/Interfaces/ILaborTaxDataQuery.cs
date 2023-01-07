using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Interfaces
{
    public interface ILaborTaxDataQuery
    {
        Task<Response<LaborTaxDataViewModel>> GetById(int employeeId);

        Task<Response<IEnumerable<LaborTaxDataViewModel>>> GetBySearch(LaborTaxDataRequest request);

        Task<Response<PaginationViewModel<LaborTaxDataViewModel>>> GetByFindAll(LaborTaxDataRequest request);
    }
}
