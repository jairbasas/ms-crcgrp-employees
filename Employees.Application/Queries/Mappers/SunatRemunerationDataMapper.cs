using Employees.Application.Queries.ViewModels;

namespace Employees.Application.Queries.Mappers
{
    public interface ISunatRemunerationDataMapper
    {
        SunatRemunerationDataViewModel MapToSunatRemunerationDataViewModel(dynamic r);
    }

    public class SunatRemunerationDataMapper : ISunatRemunerationDataMapper
    {
        public SunatRemunerationDataViewModel MapToSunatRemunerationDataViewModel(dynamic r)
        {
            SunatRemunerationDataViewModel o = new SunatRemunerationDataViewModel();

            o.employeeId = r.employee_id;
            o.parameterDetailId = r.parameter_detail_id;
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
