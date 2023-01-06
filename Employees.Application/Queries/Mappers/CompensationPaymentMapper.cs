using Employees.Application.Queries.ViewModels;

namespace Employees.Application.Queries.Mappers
{
    public interface ICompensationPaymentMapper
    {
        CompensationPaymentViewModel MapToCompensationPaymentViewModel(dynamic r);
    }

    public class CompensationPaymentMapper : ICompensationPaymentMapper
    {
        public CompensationPaymentViewModel MapToCompensationPaymentViewModel(dynamic r)
        {
            CompensationPaymentViewModel o = new CompensationPaymentViewModel();

            o.employeeId = r.employee_id;
            o.accountNumber = r.account_number;
            o.interbankAccount = r.interbank_account;
            o.bankId = r.bank_id;
            o.accountTypeId = r.account_type_id;
            o.currencyId = r.currency_id;
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
