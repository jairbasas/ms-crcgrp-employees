using Employees.Application.Commands.ParameterDetailCommand;
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
    [Route("employees/parameter-details")]
    [ApiController]
    public class ParameterDetailController : ControllerBase
    {
        readonly IParameterDetailQuery _iParameterDetailQuery;
        readonly IMediator _mediator;

        public ParameterDetailController(IParameterDetailQuery iParameterDetailQuery, IMediator mediator)
        {
            _iParameterDetailQuery = iParameterDetailQuery ?? throw new ArgumentNullException(nameof(iParameterDetailQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{parameterDetailId}")]
        [ProducesResponseType(typeof(Response<ParameterDetailViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int parameterDetailId)
        {
            var result = await _iParameterDetailQuery.GetById(parameterDetailId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<ParameterDetailViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] ParameterDetailRequest request)
        {
            var result = await _iParameterDetailQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<ParameterDetailViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] ParameterDetailRequest request)
        {
            var result = await _iParameterDetailQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateParameterDetail(CreateParameterDetailCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateParameterDetail), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateParameterDetail(UpdateParameterDetailCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
