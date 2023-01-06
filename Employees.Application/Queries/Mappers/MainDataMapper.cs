using Employees.Application.Queries.ViewModels;

namespace Employees.Application.Queries.Mappers
{
    public interface IMainDataMapper
    {
        MainDataViewModel MapToMainDataViewModel(dynamic r);
    }

    public class MainDataMapper : IMainDataMapper
    {
        public MainDataViewModel MapToMainDataViewModel(dynamic r)
        {
            MainDataViewModel o = new MainDataViewModel();

            o.employeeId = r.employee_id;
            o.documentNumber = r.document_number;
            o.birthDate = r.birth_date;
            o.ubigeoBirth = r.ubigeo_birth;
            o.postalCode = r.postal_code;
            o.phoneNumber = r.phone_number;
            o.email = r.email;
            o.domiciled = r.domiciled;
            o.routeTypeNumber = r.route_type_number;
            o.department = r.department;
            o.inside = r.inside;
            o.mz = r.mz;
            o.routeName = r.route_name;
            o.lt = r.lt;
            o.km = r.km;
            o.block = r.block;
            o.zoneName = r.zone_name;
            o.stage = r.stage;
            o.reference = r.reference;
            o.ubigeo = r.ubigeo;
            o.documentTypeId = r.document_type_id;
            o.nationalityId = r.nationality_id;
            o.sexId = r.sex_id;
            o.civilStatus = r.civil_status;
            o.routeTypeId = r.route_type_id;
            o.zoneTypeId = r.zone_type_id;
            o.observation = r.observation;
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
