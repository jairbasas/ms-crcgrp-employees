using Employees.Application.Commands.WorkingPeriodCommand;
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
    [Route("employees/working-periods")]
    [ApiController]
    public class WorkingPeriodController : ControllerBase
    {
        readonly IWorkingPeriodQuery _iWorkingPeriodQuery;
        readonly IMediator _mediator;

        public WorkingPeriodController(IWorkingPeriodQuery iWorkingPeriodQuery, IMediator mediator)
        {
            _iWorkingPeriodQuery = iWorkingPeriodQuery ?? throw new ArgumentNullException(nameof(iWorkingPeriodQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Response<WorkingPeriodViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var result = await _iWorkingPeriodQuery.GetById(employeeId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<WorkingPeriodViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] WorkingPeriodRequest request)
        {
            var result = await _iWorkingPeriodQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<WorkingPeriodViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] WorkingPeriodRequest request)
        {
            var result = await _iWorkingPeriodQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateWorkingPeriod(CreateWorkingPeriodCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateWorkingPeriod), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateWorkingPeriod(UpdateWorkingPeriodCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
