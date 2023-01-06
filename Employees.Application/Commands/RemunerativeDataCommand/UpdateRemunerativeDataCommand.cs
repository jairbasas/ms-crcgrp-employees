using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.RemunerativeDataAggregate;
using MediatR;

namespace Employees.Application.Commands.RemunerativeDataCommand
{
    public class UpdateRemunerativeDataCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public string salaryTypeId { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
    }

    public class UpdateRemunerativeDataCommandHandler : IRequestHandler<UpdateRemunerativeDataCommand, Response<int>>
    {
        readonly IRemunerativeDataRepository _iRemunerativeDataRepository;

        readonly IValuesSettings _iValuesSettings;

        public UpdateRemunerativeDataCommandHandler(IRemunerativeDataRepository iRemunerativeDataRepository, IValuesSettings iValuesSettings)
        {
            _iRemunerativeDataRepository = iRemunerativeDataRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(UpdateRemunerativeDataCommand request, CancellationToken cancellationToken)
        {
            RemunerativeData remunerativeData = new RemunerativeData(request.employeeId, request.salaryTypeId, request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iRemunerativeDataRepository.Register(remunerativeData);

            return new Response<int>(result);
        }
    }
}
