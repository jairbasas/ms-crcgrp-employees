using Employees.Application.Commands.SunatDataCommand;
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
    [Route("employees/sunat-data")]
    [ApiController]
    public class SunatDataController : ControllerBase
    {
        readonly ISunatDataQuery _iSunatDataQuery;
        readonly IMediator _mediator;

        public SunatDataController(ISunatDataQuery iSunatDataQuery, IMediator mediator)
        {
            _iSunatDataQuery = iSunatDataQuery ?? throw new ArgumentNullException(nameof(iSunatDataQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Response<SunatDataViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var result = await _iSunatDataQuery.GetById(employeeId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<SunatDataViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] SunatDataRequest request)
        {
            var result = await _iSunatDataQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<SunatDataViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] SunatDataRequest request)
        {
            var result = await _iSunatDataQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateSunatData(CreateSunatDataCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateSunatData), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateSunatData(UpdateSunatDataCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
