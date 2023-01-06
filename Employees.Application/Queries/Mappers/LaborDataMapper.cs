using Employees.Application.Queries.ViewModels;

namespace Employees.Application.Queries.Mappers
{
    public interface ILaborDataMapper
    {
        LaborDataViewModel MapToLaborDataViewModel(dynamic r);
    }

    public class LaborDataMapper : ILaborDataMapper
    {
        public LaborDataViewModel MapToLaborDataViewModel(dynamic r)
        {
            LaborDataViewModel o = new LaborDataViewModel();

            o.employeeId = r.employee_id;
            o.salaryAdvance = r.salary_advance;
            o.reference = r.reference;
            o.testEndDate = r.test_end_date;
            o.employeeTypeId = r.employee_type_id;
            o.educationalSituationId = r.educational_situation_id;
            o.occupationId = r.occupation_id;
            o.positionId = r.position_id;
            o.costCenterId = r.cost_center_id;
            o.specialSituationId = r.special_situation_id;
            o.laborRegimeId = r.labor_regime_id;
            o.essaludVidaId = r.essalud_vida_id;
            o.serviceUnitId = r.service_unit_id;
            o.areaSeccionId = r.area_seccion_id;
            o.trustPositionId = r.trust_position_id;
            o.accountCategoryId = r.account_category_id;
            o.workTypeId = r.work_type_id;
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
