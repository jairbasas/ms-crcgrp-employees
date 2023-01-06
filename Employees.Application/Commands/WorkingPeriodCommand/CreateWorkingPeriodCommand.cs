using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.WorkingPeriodAggregate;
using MediatR;

namespace Employees.Application.Commands.WorkingPeriodCommand
{
    public class CreateWorkingPeriodCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public DateTime? dateAdmission { get; set; }
        public decimal? hourDay { get; set; }
        public string shiftId { get; set; }
        public int? tareoDiario { get; set; }
        public int? extraHourTareo { get; set; }
        public string tareoGroupId { get; set; }
        public DateTime? terminationDate { get; set; }
        public string reasonTerminationId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
    }

    public class CreateWorkingPeriodCommandHandler : IRequestHandler<CreateWorkingPeriodCommand, Response<int>>
    {
        readonly IWorkingPeriodRepository _iWorkingPeriodRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateWorkingPeriodCommandHandler(IWorkingPeriodRepository iWorkingPeriodRepository, IValuesSettings iValuesSettings)
        {
            _iWorkingPeriodRepository = iWorkingPeriodRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateWorkingPeriodCommand request, CancellationToken cancellationToken)
        {
            WorkingPeriod workingPeriod = new WorkingPeriod(request.employeeId, request.dateAdmission, request.hourDay, request.shiftId, request.tareoDiario, request.extraHourTareo, request.tareoGroupId, request.terminationDate, request.reasonTerminationId, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iWorkingPeriodRepository.Register(workingPeriod);

            return new Response<int>(result);
        }
    }
}
