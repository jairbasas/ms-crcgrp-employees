using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.ContractAggregate;
using MediatR;

namespace Employees.Application.Commands.ContractCommand
{
    public class UpdateContractCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string contractTypeId { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
    }

    public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, Response<int>>
    {
        readonly IContractRepository _iContractRepository;

        readonly IValuesSettings _iValuesSettings;

        public UpdateContractCommandHandler(IContractRepository iContractRepository, IValuesSettings iValuesSettings)
        {
            _iContractRepository = iContractRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {
            Contracts contract = new Contracts(request.employeeId, request.startDate, request.endDate, request.contractTypeId, request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iContractRepository.Register(contract);

            return new Response<int>(result);
        }
    }
}
