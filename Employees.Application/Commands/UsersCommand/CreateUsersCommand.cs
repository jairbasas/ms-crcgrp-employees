﻿using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.UsersAggregate;
using MediatR;

namespace Employees.Application.Commands.UsersCommand
{
    public class CreateUsersCommand : IRequest<Response<int>>
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string fatherLastName { get; set; }
        public string motherLastName { get; set; }
        public string documentNumber { get; set; }
        public string email { get; set; }
        public int? state { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
    }

    public class CreateUsersCommandHandler : IRequestHandler<CreateUsersCommand, Response<int>>
    {
        readonly IUsersRepository _iUsersRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateUsersCommandHandler(IUsersRepository iUsersRepository, IValuesSettings iValuesSettings)
        {
            _iUsersRepository = iUsersRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateUsersCommand request, CancellationToken cancellationToken)
        {
            Users users = new Users(request.userId, request.userName, request.fatherLastName, request.motherLastName, request.documentNumber, request.email, request.state, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iUsersRepository.Register(users);

            return new Response<int>(result);
        }
    }
}
