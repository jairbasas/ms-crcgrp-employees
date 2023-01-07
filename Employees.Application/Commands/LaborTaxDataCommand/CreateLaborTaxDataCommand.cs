using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.LaborTaxDataAggregate;
using MediatR;

namespace Employees.Application.Commands.LaborTaxDataCommand
{
    public class CreateLaborTaxDataCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public int parameterDetailId { get; set; }
        public bool? state { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
    }

    public class CreateLaborTaxDataCommandHandler : IRequestHandler<CreateLaborTaxDataCommand, Response<int>>
    {
        readonly ILaborTaxDataRepository _iLaborTaxDataRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateLaborTaxDataCommandHandler(ILaborTaxDataRepository iLaborTaxDataRepository, IValuesSettings iValuesSettings)
        {
            _iLaborTaxDataRepository = iLaborTaxDataRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateLaborTaxDataCommand request, CancellationToken cancellationToken)
        {
            LaborTaxData laborTaxData = new LaborTaxData(request.employeeId, request.parameterDetailId, request.state, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iLaborTaxDataRepository.Register(laborTaxData);

            return new Response<int>(result);
        }
    }
}
