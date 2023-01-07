using Employees.Application.Commands.RemunerativePeriodicityCommand;
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
    [Route("employees/remunerative-periodicities")]
    [ApiController]
    public class RemunerativePeriodicityController : ControllerBase
    {
        readonly IRemunerativePeriodicityQuery _iRemunerativePeriodicityQuery;
        readonly IMediator _mediator;

        public RemunerativePeriodicityController(IRemunerativePeriodicityQuery iRemunerativePeriodicityQuery, IMediator mediator)
        {
            _iRemunerativePeriodicityQuery = iRemunerativePeriodicityQuery ?? throw new ArgumentNullException(nameof(iRemunerativePeriodicityQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Response<RemunerativePeriodicityViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var result = await _iRemunerativePeriodicityQuery.GetById(employeeId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<RemunerativePeriodicityViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] RemunerativePeriodicityRequest request)
        {
            var result = await _iRemunerativePeriodicityQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<RemunerativePeriodicityViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] RemunerativePeriodicityRequest request)
        {
            var result = await _iRemunerativePeriodicityQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateRemunerativePeriodicity(CreateRemunerativePeriodicityCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateRemunerativePeriodicity), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateRemunerativePeriodicity(UpdateRemunerativePeriodicityCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
