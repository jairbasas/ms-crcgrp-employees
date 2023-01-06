using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.SalaryPaymentAggregate;
using MediatR;

namespace Employees.Application.Commands.SalaryPaymentCommand
{
    public class CreateSalaryPaymentCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public string accountNumber { get; set; }
        public string interbankAccount { get; set; }
        public string bankId { get; set; }
        public string accountTypeId { get; set; }
        public string currencyId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
    }

    public class CreateSalaryPaymentCommandHandler : IRequestHandler<CreateSalaryPaymentCommand, Response<int>>
    {
        readonly ISalaryPaymentRepository _iSalaryPaymentRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateSalaryPaymentCommandHandler(ISalaryPaymentRepository iSalaryPaymentRepository, IValuesSettings iValuesSettings)
        {
            _iSalaryPaymentRepository = iSalaryPaymentRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateSalaryPaymentCommand request, CancellationToken cancellationToken)
        {
            SalaryPayment salaryPayment = new SalaryPayment(request.employeeId, request.accountNumber, request.interbankAccount, request.bankId, request.accountTypeId, request.currencyId, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iSalaryPaymentRepository.Register(salaryPayment);

            return new Response<int>(result);
        }
    }
}
