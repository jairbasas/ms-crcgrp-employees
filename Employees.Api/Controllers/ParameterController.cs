using Employees.Application.Commands.ParameterCommand;
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
    [Route("employees/parameters")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        readonly IParameterQuery _iParameterQuery;
        readonly IMediator _mediator;

        public ParameterController(IParameterQuery iParameterQuery, IMediator mediator)
        {
            _iParameterQuery = iParameterQuery ?? throw new ArgumentNullException(nameof(iParameterQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{parameterId}")]
        [ProducesResponseType(typeof(Response<ParameterViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int parameterId)
        {
            var result = await _iParameterQuery.GetById(parameterId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<ParameterViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] ParameterRequest request)
        {
            var result = await _iParameterQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<ParameterViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] ParameterRequest request)
        {
            var result = await _iParameterQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateParameter(CreateParameterCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateParameter), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateParameter(UpdateParameterCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
