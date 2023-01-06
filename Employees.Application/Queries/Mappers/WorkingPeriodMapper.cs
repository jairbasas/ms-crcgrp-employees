using Employees.Application.Queries.ViewModels;

namespace Employees.Application.Queries.Mappers
{
    public interface IWorkingPeriodMapper
    {
        WorkingPeriodViewModel MapToWorkingPeriodViewModel(dynamic r);
    }

    public class WorkingPeriodMapper : IWorkingPeriodMapper
    {
        public WorkingPeriodViewModel MapToWorkingPeriodViewModel(dynamic r)
        {
            WorkingPeriodViewModel o = new WorkingPeriodViewModel();

            o.employeeId = r.employee_id;
            o.dateAdmission = r.date_admission;
            o.hourDay = r.hour_day;
            o.shiftId = r.shift_id;
            o.tareoDiario = r.tareo_diario;
            o.extraHourTareo = r.extra_hour_tareo;
            o.tareoGroupId = r.tareo_group_id;
            o.terminationDate = r.termination_date;
            o.reasonTerminationId = r.reason_termination_id;
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
