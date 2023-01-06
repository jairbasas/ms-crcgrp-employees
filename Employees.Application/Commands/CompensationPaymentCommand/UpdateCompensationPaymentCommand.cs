using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.CompensationPaymentAggregate;
using MediatR;

namespace Employees.Application.Commands.CompensationPaymentCommand
{
    public class UpdateCompensationPaymentCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public string accountNumber { get; set; }
        public string interbankAccount { get; set; }
        public string bankId { get; set; }
        public string accountTypeId { get; set; }
        public string currencyId { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
    }

    public class UpdateCompensationPaymentCommandHandler : IRequestHandler<UpdateCompensationPaymentCommand, Response<int>>
    {
        readonly ICompensationPaymentRepository _iCompensationPaymentRepository;

        readonly IValuesSettings _iValuesSettings;

        public UpdateCompensationPaymentCommandHandler(ICompensationPaymentRepository iCompensationPaymentRepository, IValuesSettings iValuesSettings)
        {
            _iCompensationPaymentRepository = iCompensationPaymentRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(UpdateCompensationPaymentCommand request, CancellationToken cancellationToken)
        {
            CompensationPayment compensationPayment = new CompensationPayment(request.employeeId, request.accountNumber, request.interbankAccount, request.bankId, request.accountTypeId, request.currencyId, request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iCompensationPaymentRepository.Register(compensationPayment);

            return new Response<int>(result);
        }
    }
}
