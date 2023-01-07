using Employees.Application.Commands.LaborDataCommand;
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
    [Route("employees/labor-data")]
    [ApiController]
    public class LaborDataController : ControllerBase
    {
        readonly ILaborDataQuery _iLaborDataQuery;
        readonly IMediator _mediator;

        public LaborDataController(ILaborDataQuery iLaborDataQuery, IMediator mediator)
        {
            _iLaborDataQuery = iLaborDataQuery ?? throw new ArgumentNullException(nameof(iLaborDataQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Response<LaborDataViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var result = await _iLaborDataQuery.GetById(employeeId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<LaborDataViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] LaborDataRequest request)
        {
            var result = await _iLaborDataQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<LaborDataViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] LaborDataRequest request)
        {
            var result = await _iLaborDataQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateLaborData(CreateLaborDataCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateLaborData), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateLaborData(UpdateLaborDataCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
