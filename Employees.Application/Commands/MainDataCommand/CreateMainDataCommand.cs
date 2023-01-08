using Employees.Application.Commands.ContractCommand;
using Employees.Application.Commands.WorkingPeriodCommand;
using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.ContractAggregate;
using Employees.Domain.Aggregates.MainDataAggregate;
using Employees.Domain.Aggregates.WorkingPeriodAggregate;
using MediatR;

namespace Employees.Application.Commands.MainDataCommand
{
    public class CreateMainDataCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public string documentNumber { get; set; }
        public DateTime? birthDate { get; set; }
        public string ubigeoBirth { get; set; }
        public string postalCode { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public bool? domiciled { get; set; }
        public string routeTypeNumber { get; set; }
        public string department { get; set; }
        public string inside { get; set; }
        public string mz { get; set; }
        public string routeName { get; set; }
        public string lt { get; set; }
        public string km { get; set; }
        public string block { get; set; }
        public string zoneName { get; set; }
        public string stage { get; set; }
        public string reference { get; set; }
        public string ubigeo { get; set; }
        public string documentTypeId { get; set; }
        public string nationalityId { get; set; }
        public string sexId { get; set; }
        public string civilStatus { get; set; }
        public string routeTypeId { get; set; }
        public string zoneTypeId { get; set; }
        public string observation { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public CreateContractCommand contract { get; set; }
        public CreateWorkingPeriodCommand workingPeriod { get; set; }
    }

    public class CreateMainDataCommandHandler : IRequestHandler<CreateMainDataCommand, Response<int>>
    {
        readonly IMainDataRepository _iMainDataRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateMainDataCommandHandler(IMainDataRepository iMainDataRepository, IValuesSettings iValuesSettings)
        {
            _iMainDataRepository = iMainDataRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateMainDataCommand request, CancellationToken cancellationToken)
        {
            MainData mainData = new MainData(request.employeeId, request.documentNumber, request.birthDate, request.ubigeoBirth, request.postalCode, request.phoneNumber, request.email, request.domiciled, request.routeTypeNumber, request.department, request.inside, request.mz, request.routeName, request.lt, request.km, request.block, request.zoneName, request.stage, request.reference, request.ubigeo, request.documentTypeId, request.nationalityId, request.sexId, request.civilStatus, request.routeTypeId, request.zoneTypeId, request.observation, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            if (request.contract != null)
            {
                Contracts contracts = new Contracts(request.employeeId, request.contract.startDate, request.contract.endDate, request.contract.contractTypeId, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));
                mainData.contracts = contracts;
            }

            if (request.workingPeriod != null)
            {
                WorkingPeriod workingPeriod = new WorkingPeriod(request.employeeId, request.workingPeriod.dateAdmission, request.workingPeriod.hourDay, request.workingPeriod.shiftId, request.workingPeriod.tareoDiario, request.workingPeriod.extraHourTareo, request.workingPeriod.tareoGroupId, request.workingPeriod.terminationDate, request.workingPeriod.reasonTerminationId, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));
                mainData.workingPeriod = workingPeriod;
            }

            var result = await _iMainDataRepository.RegisterAsync(mainData);

            return new Response<int>(result);
        }
    }
}
