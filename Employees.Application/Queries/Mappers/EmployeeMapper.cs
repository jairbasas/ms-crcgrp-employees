using Employees.Application.Queries.ViewModels;

namespace Employees.Application.Queries.Mappers
{
    public interface IEmployeeMapper
    {
        EmployeeViewModel MapToEmployeeViewModel(dynamic r);
    }

    public class EmployeeMapper : IEmployeeMapper
    {
        public EmployeeViewModel MapToEmployeeViewModel(dynamic r)
        {
            EmployeeViewModel o = new EmployeeViewModel();

            o.employeeId = r.employee_id;
            o.code = r.code;
            o.name = r.name;
            o.fatherLastName = r.father_last_name;
            o.motherLastName = r.mother_last_name;
            o.categoryName = r.category_name;
            o.situationId = r.situation_id;
            o.registerUserId = r.register_user_id;
            o.registerUserFullname = r.register_user_fullname;
            o.registerUpdate = r.register_update;
            o.updateUserId = r.update_user_id;
            o.updateUserFullname = r.update_user_fullname;
            o.updateDatetime = r.update_datetime;

            return o;
        }
    }
}
