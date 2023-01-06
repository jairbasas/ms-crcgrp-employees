using Employees.Application.Queries.ViewModels;

namespace Employees.Application.Queries.Mappers
{
    public interface IIncomeDiscountMapper
    {
        IncomeDiscountViewModel MapToIncomeDiscountViewModel(dynamic r);
    }

    public class IncomeDiscountMapper : IIncomeDiscountMapper
    {
        public IncomeDiscountViewModel MapToIncomeDiscountViewModel(dynamic r)
        {
            IncomeDiscountViewModel o = new IncomeDiscountViewModel();

            o.employeeId = r.employee_id;
            o.code = r.code;
            o.description = r.description;
            o.currencyId = r.currency_id;
            o.amount = r.amount;
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
