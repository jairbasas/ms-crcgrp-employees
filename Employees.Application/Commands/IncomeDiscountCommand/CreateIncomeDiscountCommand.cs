using Employees.Application.Queries.Generics;
using Employees.Application.Utility;
using Employees.Application.Wrappers;
using Employees.Domain.Aggregates.IncomeDiscountAggregate;
using MediatR;

namespace Employees.Application.Commands.IncomeDiscountCommand
{
    public class CreateIncomeDiscountCommand : IRequest<Response<int>>
    {
        public int employeeId { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string currencyId { get; set; }
        public decimal? amount { get; set; }
        public bool? state { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
    }

    public class CreateIncomeDiscountCommandHandler : IRequestHandler<CreateIncomeDiscountCommand, Response<int>>
    {
        readonly IIncomeDiscountRepository _iIncomeDiscountRepository;
        readonly IValuesSettings _iValuesSettings;

        public CreateIncomeDiscountCommandHandler(IIncomeDiscountRepository iIncomeDiscountRepository, IValuesSettings iValuesSettings)
        {
            _iIncomeDiscountRepository = iIncomeDiscountRepository;
            _iValuesSettings = iValuesSettings;
        }

        public async Task<Response<int>> Handle(CreateIncomeDiscountCommand request, CancellationToken cancellationToken)
        {
            IncomeDiscount incomeDiscount = new IncomeDiscount(request.employeeId, request.code, request.description, request.currencyId, request.amount, request.state, request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()), request.registerUserId, request.registerUserFullname, DateTime.Now.Peru(_iValuesSettings.GetTimeZone()));

            var result = await _iIncomeDiscountRepository.Register(incomeDiscount);

            return new Response<int>(result);
        }
    }
}
