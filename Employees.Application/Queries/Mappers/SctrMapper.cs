using Employees.Application.Queries.ViewModels;

namespace Employees.Application.Queries.Mappers
{
    public interface ISctrMapper
    {
        SctrViewModel MapToSctrViewModel(dynamic r);
    }

    public class SctrMapper : ISctrMapper
    {
        public SctrViewModel MapToSctrViewModel(dynamic r)
        {
            SctrViewModel o = new SctrViewModel();

            o.employeeId = r.employee_id;
            o.parameterDetailId = r.parameter_detail_id;
            o.sctrCode = r.sctr_code;
            o.tasa = r.tasa;
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
