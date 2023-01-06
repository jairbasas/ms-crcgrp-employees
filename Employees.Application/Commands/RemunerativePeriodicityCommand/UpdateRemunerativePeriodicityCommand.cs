using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.RemunerativePeriodicityAggregate;
using MediatR;

namespace Employees.Application.Commands.RemunerativePeriodicityCommand
{
    public class UpdateRemunerativePeriodicityCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public string periodicityId { get; set; }
        public string paymentTypeId { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
    }

    public class UpdateRemunerativePeriodicityCommandHandler : IRequestHandler<UpdateRemunerativePeriodicityCommand, Response<int>>
    {
        readonly IRemunerativePeriodicityRepository _iRemunerativePeriodicityRepository;

        readonly IValuesSettings _iValuesSettings;

        public UpdateRemunerativePeriodicityCommandHandler(IRemunerativePeriodicityRepository iRemunerativePeriodicityRepository, IValuesSettings iValuesSettings)
        {
            _iRemunerativePeriodicityRepository = iRemunerativePeriodicityRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(UpdateRemunerativePeriodicityCommand request, CancellationToken cancellationToken)
        {
            RemunerativePeriodicity remunerativePeriodicity = new RemunerativePeriodicity(request.employeeId, request.periodicityId, request.paymentTypeId, request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iRemunerativePeriodicityRepository.Register(remunerativePeriodicity);

            return new Response<int>(result);
        }
    }
}
