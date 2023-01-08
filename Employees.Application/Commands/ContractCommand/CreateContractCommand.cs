using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.ContractAggregate;
using MediatR;

namespace Employees.Application.Commands.ContractCommand
{
    public class CreateContractCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string contractTypeId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
    }

    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, Response<int>>
    {
        readonly IContractRepository _iContractRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateContractCommandHandler(IContractRepository iContractRepository, IValuesSettings iValuesSettings)
        {
            _iContractRepository = iContractRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            Contracts contract = new Contracts(request.employeeId, request.startDate, request.endDate, request.contractTypeId, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iContractRepository.Register(contract);

            return new Response<int>(result);
        }
    }
}
