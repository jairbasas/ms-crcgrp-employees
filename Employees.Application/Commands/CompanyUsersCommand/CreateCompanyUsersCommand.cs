using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.CompanyUsersAggregate;
using Employees.Domain.Aggregates.UsersAggregate;
using Employees.Domain.Exceptions;
using Employees.Services.Services.Interfaces;
using Employees.Services.Services.Response;
using MediatR;

namespace Employees.Application.Commands.CompanyUsersCommand
{
    public class CreateCompanyUsersCommand : IRequest<Response<int>>
    {
        public int companyUserId { get; set; }
        public int? userId { get; set; }
        public int? companyId { get; set; }
        public int? state { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }        
    }

    public class CreateUsersCommandHandler : IRequestHandler<CreateCompanyUsersCommand, Response<int>>
    {
        readonly ICompanyUsersRepository _iCompanyUsersRepository;
        readonly IValuesSettings _iValuesSettings;
        readonly ICompanyUsersQuery _iCompanyUsersQuery;
        readonly ISecurityService _iSecurityService;

        public CreateUsersCommandHandler(ICompanyUsersRepository iCompanyUsersRepository, IValuesSettings iValuesSettings, ICompanyUsersQuery iCompanyUsersQuery, ISecurityService iSecurityService)
        {
            _iCompanyUsersRepository = iCompanyUsersRepository;
            _iValuesSettings = iValuesSettings;
            _iCompanyUsersQuery = iCompanyUsersQuery;
            _iSecurityService = iSecurityService;
        }

        public async Task<Response<int>> Handle(CreateCompanyUsersCommand request, CancellationToken cancellationToken)
        {

            var companyUserFound = await _iCompanyUsersQuery.GetBySearch(new CompanyUsersRequest() 
            {
                userId = request.userId
            });

            if (companyUserFound.data.Where(x => x.companyId != request.companyId).Any()) throw new EmployeesBaseException("El usuario y/o el cliente , ya se encuentran asgindados");
            else
            {

                var userFound = await _iSecurityService.GetUserById<UserReponse>(request.userId.Value);
                if (userFound.succeeded)
                {
                    var userData = userFound.data;


                    CompanyUsers companyUsers = new CompanyUsers(request.companyUserId, request.userId, request.companyId, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.state);

                    Users users = new Users(userData.userId, userData.userName, userData.fatherLastName, userData.motherLastName, userData.documentNumber, userData.email, userData.state, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

                    companyUsers.users = users;

                    var result = await _iCompanyUsersRepository.RegisterAsync(companyUsers);

                    return new Response<int>(result);
                }
                else
                    throw new EmployeesBaseException(userFound.message);
                
            }            
        }
    }
}
