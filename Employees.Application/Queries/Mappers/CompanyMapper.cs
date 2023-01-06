using Employees.Application.Queries.ViewModels;

namespace Employees.Application.Queries.Mappers
{
    public interface ICompanyMapper
    {
        CompanyViewModel MapToCompanyViewModel(dynamic r);
    }

    public class CompanyMapper : ICompanyMapper
    {
        public CompanyViewModel MapToCompanyViewModel(dynamic r)
        {
            CompanyViewModel o = new CompanyViewModel();

            o.companyId = r.company_id;
            o.businessName = r.business_name;
            o.tradename = r.tradename;
            o.documentNumber = r.document_number;
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
