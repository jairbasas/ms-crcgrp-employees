using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.RemunerativePeriodicityAggregate;
using MediatR;

namespace Employees.Application.Commands.RemunerativePeriodicityCommand
{
    public class CreateRemunerativePeriodicityCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public string periodicityId { get; set; }
        public string paymentTypeId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
    }

    public class CreateRemunerativePeriodicityCommandHandler : IRequestHandler<CreateRemunerativePeriodicityCommand, Response<int>>
    {
        readonly IRemunerativePeriodicityRepository _iRemunerativePeriodicityRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateRemunerativePeriodicityCommandHandler(IRemunerativePeriodicityRepository iRemunerativePeriodicityRepository, IValuesSettings iValuesSettings)
        {
            _iRemunerativePeriodicityRepository = iRemunerativePeriodicityRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateRemunerativePeriodicityCommand request, CancellationToken cancellationToken)
        {
            RemunerativePeriodicity remunerativePeriodicity = new RemunerativePeriodicity(request.employeeId, request.periodicityId, request.paymentTypeId, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iRemunerativePeriodicityRepository.Register(remunerativePeriodicity);

            return new Response<int>(result);
        }
    }
}
