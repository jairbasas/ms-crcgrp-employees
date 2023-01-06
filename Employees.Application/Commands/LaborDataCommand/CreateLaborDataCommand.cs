using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.LaborDataAggregate;
using MediatR;

namespace Employees.Application.Commands.LaborDataCommand
{
    public class CreateLaborDataCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public decimal? salaryAdvance { get; set; }
        public string reference { get; set; }
        public DateTime? testEndDate { get; set; }
        public string employeeTypeId { get; set; }
        public string educationalSituationId { get; set; }
        public string occupationId { get; set; }
        public string positionId { get; set; }
        public string costCenterId { get; set; }
        public string specialSituationId { get; set; }
        public string laborRegimeId { get; set; }
        public string essaludVidaId { get; set; }
        public string serviceUnitId { get; set; }
        public string areaSeccionId { get; set; }
        public string trustPositionId { get; set; }
        public string accountCategoryId { get; set; }
        public string workTypeId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
    }

    public class CreateLaborDataCommandHandler : IRequestHandler<CreateLaborDataCommand, Response<int>>
    {
        readonly ILaborDataRepository _iLaborDataRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateLaborDataCommandHandler(ILaborDataRepository iLaborDataRepository, IValuesSettings iValuesSettings)
        {
            _iLaborDataRepository = iLaborDataRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateLaborDataCommand request, CancellationToken cancellationToken)
        {
            LaborData laborData = new LaborData(request.employeeId, request.salaryAdvance, request.reference, request.testEndDate, request.employeeTypeId, request.educationalSituationId, request.occupationId, request.positionId, request.costCenterId, request.specialSituationId, request.laborRegimeId, request.essaludVidaId, request.serviceUnitId, request.areaSeccionId, request.trustPositionId, request.accountCategoryId, request.workTypeId, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iLaborDataRepository.Register(laborData);

            return new Response<int>(result);
        }
    }
}
