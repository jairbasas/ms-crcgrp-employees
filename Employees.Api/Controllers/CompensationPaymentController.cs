using Employees.Application.Commands.CompensationPaymentCommand;
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
    [Route("compensation-payments")]
    [ApiController]
    public class CompensationPaymentController : ControllerBase
    {
        readonly ICompensationPaymentQuery _iCompensationPaymentQuery;
        readonly IMediator _mediator;

        public CompensationPaymentController(ICompensationPaymentQuery iCompensationPaymentQuery, IMediator mediator)
        {
            _iCompensationPaymentQuery = iCompensationPaymentQuery ?? throw new ArgumentNullException(nameof(iCompensationPaymentQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Response<CompensationPaymentViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var result = await _iCompensationPaymentQuery.GetById(employeeId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<CompensationPaymentViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] CompensationPaymentRequest request)
        {
            var result = await _iCompensationPaymentQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<CompensationPaymentViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] CompensationPaymentRequest request)
        {
            var result = await _iCompensationPaymentQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateCompensationPayment(CreateCompensationPaymentCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateCompensationPayment), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateCompensationPayment(UpdateCompensationPaymentCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
