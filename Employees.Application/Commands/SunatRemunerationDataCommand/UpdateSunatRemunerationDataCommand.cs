using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.SunatRemunerationDataAggregate;
using MediatR;

namespace Employees.Application.Commands.SunatRemunerationDataCommand
{
    public class UpdateSunatRemunerationDataCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public int parameterDetailId { get; set; }
        public bool? state { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
    }

    public class UpdateSunatRemunerationDataCommandHandler : IRequestHandler<UpdateSunatRemunerationDataCommand, Response<int>>
    {
        readonly ISunatRemunerationDataRepository _iSunatRemunerationDataRepository;

        readonly IValuesSettings _iValuesSettings;

        public UpdateSunatRemunerationDataCommandHandler(ISunatRemunerationDataRepository iSunatRemunerationDataRepository, IValuesSettings iValuesSettings)
        {
            _iSunatRemunerationDataRepository = iSunatRemunerationDataRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(UpdateSunatRemunerationDataCommand request, CancellationToken cancellationToken)
        {
            SunatRemunerationData sunatRemunerationData = new SunatRemunerationData(request.employeeId, request.parameterDetailId, request.state, request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iSunatRemunerationDataRepository.Register(sunatRemunerationData);

            return new Response<int>(result);
        }
    }
}
