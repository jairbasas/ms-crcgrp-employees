using Employees.Application.Queries.ViewModels;

namespace Employees.Application.Queries.Mappers
{
    public interface IEmployeeCompanyMapper
    {
        EmployeeCompanyViewModel MapToEmployeeCompanyViewModel(dynamic r);
    }

    public class EmployeeCompanyMapper : IEmployeeCompanyMapper
    {
        public EmployeeCompanyViewModel MapToEmployeeCompanyViewModel(dynamic r)
        {
            EmployeeCompanyViewModel o = new EmployeeCompanyViewModel();

            o.employeeId = r.employee_id;
            o.companyId = r.company_id;
            o.state = r.state;
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
