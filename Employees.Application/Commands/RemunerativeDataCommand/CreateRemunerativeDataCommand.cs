using Employees.Application.Commands.CompensationPaymentCommand;
using Employees.Application.Commands.IncomeDiscountCommand;
using Employees.Application.Commands.RemunerativePeriodicityCommand;
using Employees.Application.Commands.SalaryPaymentCommand;
using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.CompensationPaymentAggregate;
using Employees.Domain.Aggregates.IncomeDiscountAggregate;
using Employees.Domain.Aggregates.RemunerativeDataAggregate;
using Employees.Domain.Aggregates.RemunerativePeriodicityAggregate;
using Employees.Domain.Aggregates.SalaryPaymentAggregate;
using MediatR;
using MoreLinq;

namespace Employees.Application.Commands.RemunerativeDataCommand
{
    public class CreateRemunerativeDataCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public string salaryTypeId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public IEnumerable<CreateIncomeDiscountCommand> incomeDiscount { get; set; }
        public CreateRemunerativePeriodicityCommand remunerativePeriodicity { get; set; }
        public CreateSalaryPaymentCommand salaryPayment { get; set; }
        public CreateCompensationPaymentCommand compensationPayment { get; set; }
    }

    public class CreateRemunerativeDataCommandHandler : IRequestHandler<CreateRemunerativeDataCommand, Response<int>>
    {
        readonly IRemunerativeDataRepository _iRemunerativeDataRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateRemunerativeDataCommandHandler(IRemunerativeDataRepository iRemunerativeDataRepository, IValuesSettings iValuesSettings)
        {
            _iRemunerativeDataRepository = iRemunerativeDataRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateRemunerativeDataCommand request, CancellationToken cancellationToken)
        {
            RemunerativeData remunerativeData = new RemunerativeData(request.employeeId, request.salaryTypeId, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            if (request.incomeDiscount != null)
            {
                var incomeDiscountList = new List<IncomeDiscount>();
                IncomeDiscount incomeDiscount = null;
                request.incomeDiscount.ForEach(item => {
                    incomeDiscount = new IncomeDiscount(request.employeeId, item.code, item.description, item.currencyId, item.amount, item.state, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));
                });
                incomeDiscountList.Add(incomeDiscount);
                remunerativeData.incomeDiscount= incomeDiscountList;
            }

            if (request.remunerativePeriodicity != null)
            {
                RemunerativePeriodicity remunerativePeriodicity = new RemunerativePeriodicity(request.employeeId, request.remunerativePeriodicity.periodicityId, request.remunerativePeriodicity.paymentTypeId, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));
                remunerativeData.remunerativePeriodicity= remunerativePeriodicity;
            }

            if (request.salaryPayment != null)
            {
                SalaryPayment salaryPayment = new SalaryPayment(request.employeeId, request.salaryPayment.accountNumber, request.salaryPayment.interbankAccount, request.salaryPayment.bankId, request.salaryPayment.accountTypeId, request.salaryPayment.currencyId, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));
                remunerativeData.salaryPayment= salaryPayment;
            }

            if (request.compensationPayment != null)
            {
                CompensationPayment compensationPayment = new CompensationPayment(request.employeeId, request.compensationPayment.accountNumber, request.compensationPayment.interbankAccount, request.compensationPayment.bankId, request.compensationPayment.accountTypeId, request.compensationPayment.currencyId, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

                remunerativeData.compensationPayment= compensationPayment;
            }

            var result = await _iRemunerativeDataRepository.RegisterAsync(remunerativeData);

            return new Response<int>(result);
        }
    }
}
