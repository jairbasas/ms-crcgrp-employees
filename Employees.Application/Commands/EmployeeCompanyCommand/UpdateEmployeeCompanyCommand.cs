using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.EmployeeCompanyAggregate;
using MediatR;

namespace Employees.Application.Commands.EmployeeCompanyCommand
{
    public class UpdateEmployeeCompanyCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public int companyId { get; set; }
        public int? state { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
    }

    public class UpdateEmployeeCompanyCommandHandler : IRequestHandler<UpdateEmployeeCompanyCommand, Response<int>>
    {
        readonly IEmployeeCompanyRepository _iEmployeeCompanyRepository;

        readonly IValuesSettings _iValuesSettings;

        public UpdateEmployeeCompanyCommandHandler(IEmployeeCompanyRepository iEmployeeCompanyRepository, IValuesSettings iValuesSettings)
        {
            _iEmployeeCompanyRepository = iEmployeeCompanyRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(UpdateEmployeeCompanyCommand request, CancellationToken cancellationToken)
        {
            EmployeeCompany employeeCompany = new EmployeeCompany(request.employeeId, request.companyId, request.state, request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iEmployeeCompanyRepository.Register(employeeCompany);

            return new Response<int>(result);
        }
    }
}
