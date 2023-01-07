using Employees.Application.Queries.ViewModels;

namespace Employees.Application.Queries.Mappers
{
    public interface IHealthBenefitsMapper
    {
        HealthBenefitsViewModel MapToHealthBenefitsViewModel(dynamic r);
    }

    public class HealthBenefitsMapper : IHealthBenefitsMapper
    {
        public HealthBenefitsViewModel MapToHealthBenefitsViewModel(dynamic r)
        {
            HealthBenefitsViewModel o = new HealthBenefitsViewModel();

            o.employeeId = r.employee_id;
            o.affiliateEps = r.affiliate_eps;
            o.epsNumber = r.eps_number;
            o.registrationDate = r.registration_date;
            o.familyPlan = r.family_plan;
            o.disenrollmentDate = r.disenrollment_date;
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
