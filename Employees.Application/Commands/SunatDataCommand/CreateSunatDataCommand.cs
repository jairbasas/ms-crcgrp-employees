using Employees.Application.Commands.HealthBenefitsCommand;
using Employees.Application.Commands.LaborTaxDataCommand;
using Employees.Application.Commands.SctrCommand;
using Employees.Application.Commands.SunatRemunerationDataCommand;
using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.LaborTaxDataAggregate;
using Employees.Domain.Aggregates.SctrAggregate;
using Employees.Domain.Aggregates.SunatDataAggregate;
using Employees.Domain.Aggregates.SunatRemunerationDataAggregate;
using MediatR;
using MoreLinq;

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
        public IEnumerable<CreateLaborTaxDataCommand> laborTaxData { get; set; }
        public IEnumerable<CreateSunatRemunerationDataCommand> sunatRemunerationData { get; set; }
        public IEnumerable<CreateSctrCommand> sctr { get; set; }
        public CreateHealthBenefitsCommand healthBenefits { get; set; }
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

            if (request.laborTaxData != null)
            {
                var laborTaxDataList = new List<LaborTaxData>();
                LaborTaxData laborTaxData = null;

                request.laborTaxData.ForEach(item => 
                {
                    laborTaxData = new LaborTaxData(request.employeeId, item.parameterDetailId, item.state, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));
                    laborTaxDataList.Add(laborTaxData);
                });
                sunatData.laborTaxData= laborTaxDataList;
            }

            if (request.sunatRemunerationData != null)
            {
                var sunatRemunerationDataList = new List<SunatRemunerationData>();
                SunatRemunerationData sunatRemunerationData = null;

                request.sunatRemunerationData.ForEach(item => 
                {
                    sunatRemunerationData = new SunatRemunerationData(request.employeeId, item.parameterDetailId, item.state, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));
                    sunatRemunerationDataList.Add(sunatRemunerationData);
                });
                sunatData.sunatRemunerationData= sunatRemunerationDataList;
            }

            if (request.sctr != null)
            {
                var sctrList = new List<Sctr>();
                Sctr sctr = null;

                request.sctr.ForEach(item => 
                {
                    sctr = new Sctr(request.employeeId, item.parameterDetailId, item.sctrCode, item.tasa, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));
                    sctrList.Add(sctr);
                });
                sunatData.sctr= sctrList;
            }

            var result = await _iSunatDataRepository.RegisterAsync(sunatData);

            return new Response<int>(result);
        }
    }

}
