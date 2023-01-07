using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.SctrAggregate;
using MediatR;

namespace Employees.Application.Commands.SctrCommand
{
    public class UpdateSctrCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public int parameterDetailId { get; set; }
        public string sctrCode { get; set; }
        public string tasa { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
    }

    public class UpdateSctrCommandHandler : IRequestHandler<UpdateSctrCommand, Response<int>>
    {
        readonly ISctrRepository _iSctrRepository;

        readonly IValuesSettings _iValuesSettings;

        public UpdateSctrCommandHandler(ISctrRepository iSctrRepository, IValuesSettings iValuesSettings)
        {
            _iSctrRepository = iSctrRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(UpdateSctrCommand request, CancellationToken cancellationToken)
        {
            Sctr sctr = new Sctr(request.employeeId, request.parameterDetailId, request.sctrCode, request.tasa, request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iSctrRepository.Register(sctr);

            return new Response<int>(result);
        }
    }
}
