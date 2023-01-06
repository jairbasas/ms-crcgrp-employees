using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.CompensationPaymentAggregate;
using MediatR;

namespace Employees.Application.Commands.CompensationPaymentCommand
{
    public class CreateCompensationPaymentCommand : IRequest<Response<int>>
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

    public class CreateCompensationPaymentCommandHandler : IRequestHandler<CreateCompensationPaymentCommand, Response<int>>
    {
        readonly ICompensationPaymentRepository _iCompensationPaymentRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateCompensationPaymentCommandHandler(ICompensationPaymentRepository iCompensationPaymentRepository, IValuesSettings iValuesSettings)
        {
            _iCompensationPaymentRepository = iCompensationPaymentRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateCompensationPaymentCommand request, CancellationToken cancellationToken)
        {
            CompensationPayment compensationPayment = new CompensationPayment(request.employeeId, request.accountNumber, request.interbankAccount, request.bankId, request.accountTypeId, request.currencyId, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iCompensationPaymentRepository.Register(compensationPayment);

            return new Response<int>(result);
        }
    }
}
