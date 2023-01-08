using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.EmployeeAggregate;
using Employees.Domain.Aggregates.EmployeeCompanyAggregate;
using Employees.Domain.Exceptions;
using MediatR;

namespace Employees.Application.Commands.EmployeeCommand
{
    public class CreateEmployeeCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public int companyId { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string fatherLastName { get; set; }
        public string motherLastName { get; set; }
        public string categoryName { get; set; }
        public string situationId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Response<int>>
    {
        readonly IEmployeeRepository _iEmployeeRepository;
        readonly IValuesSettings _iValuesSettings;
        readonly IEmployeeCompanyQuery _iEmployeeCompanyQuery;
        readonly IEmployeeCompanyRepository _iEmployeeCompanyRepository;
        readonly IEmployeeQuery _iEmployeeQuery;
        public CreateEmployeeCommandHandler(IEmployeeRepository iEmployeeRepository, IValuesSettings iValuesSettings, IEmployeeCompanyQuery iEmployeeCompanyQuery, IEmployeeCompanyRepository iEmployeeCompanyRepository, IEmployeeQuery iEmployeeQuery)
        {
            _iEmployeeRepository = iEmployeeRepository;
            _iValuesSettings = iValuesSettings;
            _iEmployeeCompanyQuery = iEmployeeCompanyQuery;
            _iEmployeeCompanyRepository = iEmployeeCompanyRepository;
            _iEmployeeQuery = iEmployeeQuery;
        }

        public async Task<Response<int>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {

            var employeeFound = await _iEmployeeQuery.GetBySearch(new EmployeeRequest() 
            {
                code = request.code
            });


            if (employeeFound.data.Any()) 
            {
                if (employeeFound.data.Where(x => x.employeeId != request.employeeId).Any()) 
                {
                    throw new EmployeesBaseException($"El número de documento {request.code}, ya se encuentra registrado");
                }
            }

            Employee employee = new Employee(request.employeeId, request.code, request.name, request.fatherLastName, request.motherLastName, request.categoryName, request.situationId, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iEmployeeRepository.Register(employee);

            var employeeCompanyFound = await _iEmployeeCompanyQuery.GetBySearch(new EmployeeCompanyRequest()
            {
                employeeId = result,
                companyId = request.companyId
            });

            if (!employeeCompanyFound.data.Any())
            {
                EmployeeCompany employeeCompany = new EmployeeCompany(result, request.companyId, StateEntity.Active, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

                await _iEmployeeCompanyRepository.Register(employeeCompany);
            }


            return new Response<int>(result);
        }
    }
}
