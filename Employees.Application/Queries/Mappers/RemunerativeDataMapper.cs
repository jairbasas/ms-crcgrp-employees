using Employees.Application.Queries.ViewModels;

namespace Employees.Application.Queries.Mappers
{
    public interface IRemunerativeDataMapper
    {
        RemunerativeDataViewModel MapToRemunerativeDataViewModel(dynamic r);
    }

    public class RemunerativeDataMapper : IRemunerativeDataMapper
    {
        public RemunerativeDataViewModel MapToRemunerativeDataViewModel(dynamic r)
        {
            RemunerativeDataViewModel o = new RemunerativeDataViewModel();

            o.employeeId = r.employee_id;
            o.salaryTypeId = r.salary_type_id;
            o.registerUserId = r.register_user_id;
            o.registerUserFullname = r.register_user_fullname;
            o.registerDatetime = r.register_datetime;
            o.updateUserId = r.update_user_id;
            o.updateUserFullname = r.update_user_fullname;
            o.updateDatetime = r.update_datetime;

            return o;
        }
    }
}
