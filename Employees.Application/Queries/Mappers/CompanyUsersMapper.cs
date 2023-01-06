using Employees.Application.Queries.ViewModels;

namespace Employees.Application.Queries.Mappers
{
    public interface ICompanyUsersMapper
    {
        CompanyUsersViewModel MapToCompanyUsersViewModel(dynamic r);
    }

    public class CompanyUsersMapper : ICompanyUsersMapper
    {
        public CompanyUsersViewModel MapToCompanyUsersViewModel(dynamic r)
        {
            CompanyUsersViewModel o = new CompanyUsersViewModel();

            o.companyUserId = r.company_user_id;
            o.userId = r.user_id;
            o.companyId = r.company_id;
            o.registerUserId = r.register_user_id;
            o.registerUserFullname = r.register_user_fullname;
            o.registerDatetime = r.register_datetime;
            o.updateUserId = r.update_user_id;
            o.updateUserFullname = r.update_user_fullname;
            o.updateDatetime = r.update_datetime;
            o.state = r.state;

            return o;
        }
    }
}
