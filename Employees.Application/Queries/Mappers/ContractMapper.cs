using Employees.Application.Queries.ViewModels;

namespace Employees.Application.Queries.Mappers
{
    public interface IContractMapper
    {
        ContractViewModel MapToContractViewModel(dynamic r);
    }

    public class ContractMapper : IContractMapper
    {
        public ContractViewModel MapToContractViewModel(dynamic r)
        {
            ContractViewModel o = new ContractViewModel();

            o.employeeId = r.employee_id;
            o.startDate = r.start_date;
            o.endDate = r.end_date;
            o.contractTypeId = r.contract_type_id;
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
