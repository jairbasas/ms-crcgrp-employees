using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.RemunerativeDataAggregate;
using MediatR;

namespace Employees.Application.Commands.RemunerativeDataCommand
{
    public class CreateRemunerativeDataCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public string salaryTypeId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
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

            var result = await _iRemunerativeDataRepository.Register(remunerativeData);

            return new Response<int>(result);
        }
    }
}
