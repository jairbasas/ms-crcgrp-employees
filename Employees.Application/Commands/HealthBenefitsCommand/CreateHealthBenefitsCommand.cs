using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.HealthBenefitsAggregate;
using MediatR;

namespace Employees.Application.Commands.HealthBenefitsCommand
{
    public class CreateHealthBenefitsCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public bool? affiliateEps { get; set; }
        public string epsNumber { get; set; }
        public DateTime? registrationDate { get; set; }
        public string familyPlan { get; set; }
        public DateTime? disenrollmentDate { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
    }

    public class CreateHealthBenefitsCommandHandler : IRequestHandler<CreateHealthBenefitsCommand, Response<int>>
    {
        readonly IHealthBenefitsRepository _iHealthBenefitsRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateHealthBenefitsCommandHandler(IHealthBenefitsRepository iHealthBenefitsRepository, IValuesSettings iValuesSettings)
        {
            _iHealthBenefitsRepository = iHealthBenefitsRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateHealthBenefitsCommand request, CancellationToken cancellationToken)
        {
            HealthBenefits healthBenefits = new HealthBenefits(request.employeeId, request.affiliateEps, request.epsNumber, request.registrationDate, request.familyPlan, request.disenrollmentDate, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iHealthBenefitsRepository.Register(healthBenefits);

            return new Response<int>(result);
        }
    }
}
