using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.CompanyAggregate;
using MediatR;

namespace Employees.Application.Commands.CompanyCommand
{
    public class CreateCompanyCommand : IRequest<Response<int>>
    {
        public int companyId { get; set; }
        public string businessName { get; set; }
        public string tradename { get; set; }
        public string documentNumber { get; set; }
        public int? state { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Response<int>>
    {
        readonly ICompanyRepository _iCompanyRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateCompanyCommandHandler(ICompanyRepository iCompanyRepository, IValuesSettings iValuesSettings)
        {
            _iCompanyRepository = iCompanyRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = new Company(request.companyId, request.businessName, request.tradename, request.documentNumber, request.state, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iCompanyRepository.Register(company);

            return new Response<int>(result);
        }
    }
}
