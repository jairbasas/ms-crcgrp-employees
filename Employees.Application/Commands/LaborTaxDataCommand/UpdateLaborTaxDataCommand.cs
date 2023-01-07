using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.LaborTaxDataAggregate;
using MediatR;

namespace Employees.Application.Commands.LaborTaxDataCommand
{
    public class UpdateLaborTaxDataCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public int parameterDetailId { get; set; }
        public bool? state { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
    }

    public class UpdateLaborTaxDataCommandHandler : IRequestHandler<UpdateLaborTaxDataCommand, Response<int>>
    {
        readonly ILaborTaxDataRepository _iLaborTaxDataRepository;

        readonly IValuesSettings _iValuesSettings;

        public UpdateLaborTaxDataCommandHandler(ILaborTaxDataRepository iLaborTaxDataRepository, IValuesSettings iValuesSettings)
        {
            _iLaborTaxDataRepository = iLaborTaxDataRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(UpdateLaborTaxDataCommand request, CancellationToken cancellationToken)
        {
            LaborTaxData laborTaxData = new LaborTaxData(request.employeeId, request.parameterDetailId, request.state, request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iLaborTaxDataRepository.Register(laborTaxData);

            return new Response<int>(result);
        }
    }
}
