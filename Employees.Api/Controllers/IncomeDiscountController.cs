using Employees.Application.Commands.IncomeDiscountCommand;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Employees.Api.Controllers
{
    [Authorize]
    [Route("income-discounts")]
    [ApiController]
    public class IncomeDiscountController : ControllerBase
    {
        readonly IIncomeDiscountQuery _iIncomeDiscountQuery;
        readonly IMediator _mediator;

        public IncomeDiscountController(IIncomeDiscountQuery iIncomeDiscountQuery, IMediator mediator)
        {
            _iIncomeDiscountQuery = iIncomeDiscountQuery ?? throw new ArgumentNullException(nameof(iIncomeDiscountQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Response<IncomeDiscountViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var result = await _iIncomeDiscountQuery.GetById(employeeId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<IncomeDiscountViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] IncomeDiscountRequest request)
        {
            var result = await _iIncomeDiscountQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<IncomeDiscountViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] IncomeDiscountRequest request)
        {
            var result = await _iIncomeDiscountQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateIncomeDiscount(CreateIncomeDiscountCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateIncomeDiscount), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateIncomeDiscount(UpdateIncomeDiscountCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
