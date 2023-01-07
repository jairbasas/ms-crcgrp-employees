using Employees.Application.Commands.RemunerativeDataCommand;
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
    [Route("employees/remunerative-data")]
    [ApiController]
    public class RemunerativeDataController : ControllerBase
    {
        readonly IRemunerativeDataQuery _iRemunerativeDataQuery;
        readonly IMediator _mediator;

        public RemunerativeDataController(IRemunerativeDataQuery iRemunerativeDataQuery, IMediator mediator)
        {
            _iRemunerativeDataQuery = iRemunerativeDataQuery ?? throw new ArgumentNullException(nameof(iRemunerativeDataQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Response<RemunerativeDataViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var result = await _iRemunerativeDataQuery.GetById(employeeId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<RemunerativeDataViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] RemunerativeDataRequest request)
        {
            var result = await _iRemunerativeDataQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<RemunerativeDataViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] RemunerativeDataRequest request)
        {
            var result = await _iRemunerativeDataQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateRemunerativeData(CreateRemunerativeDataCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateRemunerativeData), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateRemunerativeData(UpdateRemunerativeDataCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
