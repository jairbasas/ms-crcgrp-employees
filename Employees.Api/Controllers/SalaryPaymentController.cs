using Employees.Application.Commands.SalaryPaymentCommand;
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
    [Route("salary-payments")]
    [ApiController]
    public class SalaryPaymentController : ControllerBase
    {
        readonly ISalaryPaymentQuery _iSalaryPaymentQuery;
        readonly IMediator _mediator;

        public SalaryPaymentController(ISalaryPaymentQuery iSalaryPaymentQuery, IMediator mediator)
        {
            _iSalaryPaymentQuery = iSalaryPaymentQuery ?? throw new ArgumentNullException(nameof(iSalaryPaymentQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Response<SalaryPaymentViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var result = await _iSalaryPaymentQuery.GetById(employeeId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<SalaryPaymentViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] SalaryPaymentRequest request)
        {
            var result = await _iSalaryPaymentQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<SalaryPaymentViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] SalaryPaymentRequest request)
        {
            var result = await _iSalaryPaymentQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateSalaryPayment(CreateSalaryPaymentCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateSalaryPayment), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateSalaryPayment(UpdateSalaryPaymentCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
