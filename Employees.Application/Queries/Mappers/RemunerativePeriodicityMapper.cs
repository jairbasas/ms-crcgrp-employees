using Employees.Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Queries.Mappers
{
    public interface IRemunerativePeriodicityMapper
    {
        RemunerativePeriodicityViewModel MapToRemunerativePeriodicityViewModel(dynamic r);
    }

    public class RemunerativePeriodicityMapper : IRemunerativePeriodicityMapper
    {
        public RemunerativePeriodicityViewModel MapToRemunerativePeriodicityViewModel(dynamic r)
        {
            RemunerativePeriodicityViewModel o = new RemunerativePeriodicityViewModel();

            o.employeeId = r.employee_id;
            o.periodicityId = r.periodicity_id;
            o.paymentTypeId = r.payment_type_id;
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
