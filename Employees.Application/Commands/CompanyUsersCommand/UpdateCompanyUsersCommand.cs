using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.CompanyUsersAggregate;
using MediatR;

namespace Employees.Application.Commands.CompanyUsersCommand
{
    public class UpdateCompanyUsersCommand : IRequest<Response<int>>
    {
        public int companyUserId { get; set; }
        public int? userId { get; set; }
        public int? companyId { get; set; }
        public int? state { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }        
    }

    public class UpdateUsersCommandHandler : IRequestHandler<UpdateCompanyUsersCommand, Response<int>>
    {
        readonly ICompanyUsersRepository _iUsersRepository;

        readonly IValuesSettings _iValuesSettings;

        public UpdateUsersCommandHandler(ICompanyUsersRepository iUsersRepository, IValuesSettings iValuesSettings)
        {
            _iUsersRepository = iUsersRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(UpdateCompanyUsersCommand request, CancellationToken cancellationToken)
        {
            CompanyUsers users = new CompanyUsers(request.companyUserId, request.userId, request.companyId, request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.updateUserId, request.updateUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.state);

            var result = await _iUsersRepository.Register(users);

            return new Response<int>(result);
        }
    }
}
