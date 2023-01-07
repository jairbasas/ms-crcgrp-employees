using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.SunatRemunerationDataAggregate;
using MediatR;

namespace Employees.Application.Commands.SunatRemunerationDataCommand
{
    public class CreateSunatRemunerationDataCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public int parameterDetailId { get; set; }
        public bool? state { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
    }

    public class CreateSunatRemunerationDataCommandHandler : IRequestHandler<CreateSunatRemunerationDataCommand, Response<int>>
    {
        readonly ISunatRemunerationDataRepository _iSunatRemunerationDataRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateSunatRemunerationDataCommandHandler(ISunatRemunerationDataRepository iSunatRemunerationDataRepository, IValuesSettings iValuesSettings)
        {
            _iSunatRemunerationDataRepository = iSunatRemunerationDataRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateSunatRemunerationDataCommand request, CancellationToken cancellationToken)
        {
            SunatRemunerationData sunatRemunerationData = new SunatRemunerationData(request.employeeId, request.parameterDetailId, request.state, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iSunatRemunerationDataRepository.Register(sunatRemunerationData);

            return new Response<int>(result);
        }
    }
}
