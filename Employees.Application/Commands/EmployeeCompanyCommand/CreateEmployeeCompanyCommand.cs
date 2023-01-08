using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.EmployeeCompanyAggregate;
using MediatR;

namespace Employees.Application.Commands.EmployeeCompanyCommand
{
    public class CreateEmployeeCompanyCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public int companyId { get; set; }
        public int? state { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
    }

    public class CreateEmployeeCompanyCommandHandler : IRequestHandler<CreateEmployeeCompanyCommand, Response<int>>
    {
        readonly IEmployeeCompanyRepository _iEmployeeCompanyRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateEmployeeCompanyCommandHandler(IEmployeeCompanyRepository iEmployeeCompanyRepository, IValuesSettings iValuesSettings)
        {
            _iEmployeeCompanyRepository = iEmployeeCompanyRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateEmployeeCompanyCommand request, CancellationToken cancellationToken)
        {
            EmployeeCompany employeeCompany = new EmployeeCompany(request.employeeId, request.companyId, request.state, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iEmployeeCompanyRepository.Register(employeeCompany);

            return new Response<int>(result);
        }
    }
}
