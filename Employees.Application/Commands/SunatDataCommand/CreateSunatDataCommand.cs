﻿using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.SunatDataAggregate;
using MediatR;

namespace Employees.Application.Commands.SunatDataCommand
{
    public class CreateSunatDataCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public string essaludCode { get; set; }
        public bool? mixedCommission { get; set; }
        public DateTime? registrationDate { get; set; }
        public string pensionTypeId { get; set; }
        public string pensionSchemeId { get; set; }
        public string workerSituationId { get; set; }
        public string occupationalCategoryId { get; set; }
        public string affiliateTypeId { get; set; }
        public string doubleTaxationId { get; set; }
        public string afpExonerationTypeId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
    }

    public class CreateSunatDataCommandHandler : IRequestHandler<CreateSunatDataCommand, Response<int>>
    {
        readonly ISunatDataRepository _iSunatDataRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateSunatDataCommandHandler(ISunatDataRepository iSunatDataRepository, IValuesSettings iValuesSettings)
        {
            _iSunatDataRepository = iSunatDataRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateSunatDataCommand request, CancellationToken cancellationToken)
        {
            SunatData sunatData = new SunatData(request.employeeId, request.essaludCode, request.mixedCommission, request.registrationDate, request.pensionTypeId, request.pensionSchemeId, request.workerSituationId, request.occupationalCategoryId, request.affiliateTypeId, request.doubleTaxationId, request.afpExonerationTypeId, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iSunatDataRepository.Register(sunatData);

            return new Response<int>(result);
        }
    }

}
