using Employees.Application.Queries.ViewModels;

namespace Employees.Application.Queries.Mappers
{
    public interface ISunatDataMapper
    {
        SunatDataViewModel MapToSunatDataViewModel(dynamic r);
    }

    public class SunatDataMapper : ISunatDataMapper
    {
        public SunatDataViewModel MapToSunatDataViewModel(dynamic r)
        {
            SunatDataViewModel o = new SunatDataViewModel();

            o.employeeId = r.employee_id;
            o.essaludCode = r.essalud_code;
            o.mixedCommission = r.mixed_commission;
            o.registrationDate = r.registration_date;
            o.pensionTypeId = r.pension_type_id;
            o.pensionSchemeId = r.pension_scheme_id;
            o.workerSituationId = r.worker_situation_id;
            o.occupationalCategoryId = r.occupational_category_id;
            o.affiliateTypeId = r.affiliate_type_id;
            o.doubleTaxationId = r.double_taxation_id;
            o.afpExonerationTypeId = r.afp_exoneration_type_id;
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
