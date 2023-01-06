using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.EmployeeAggregate;
using MediatR;

namespace Employees.Application.Commands.EmployeeCommand
{
    public class UpdateEmployeeCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string fatherLastName { get; set; }
        public string motherLastName { get; set; }
        public string categoryName { get; set; }
        public string situationId { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Response<int>>
    {
        readonly IEmployeeRepository _iEmployeeRepository;

        readonly IValuesSettings _iValuesSettings;

        public UpdateEmployeeCommandHandler(IEmployeeRepository iEmployeeRepository, IValuesSettings iValuesSettings)
        {
            _iEmployeeRepository = iEmployeeRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = new Employee(request.employeeId, request.code, request.name, request.fatherLastName, request.motherLastName, request.categoryName, request.situationId, request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iEmployeeRepository.Register(employee);

            return new Response<int>(result);
        }
    }
}
