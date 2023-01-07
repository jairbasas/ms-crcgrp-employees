using Employees.Application.Commands.SunatRemunerationDataCommand;
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
    [Route("employees/sunat-remuneration-data")]
    [ApiController]
    public class SunatRemunerationDataController : ControllerBase
    {
        readonly ISunatRemunerationDataQuery _iSunatRemunerationDataQuery;
        readonly IMediator _mediator;

        public SunatRemunerationDataController(ISunatRemunerationDataQuery iSunatRemunerationDataQuery, IMediator mediator)
        {
            _iSunatRemunerationDataQuery = iSunatRemunerationDataQuery ?? throw new ArgumentNullException(nameof(iSunatRemunerationDataQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Response<SunatRemunerationDataViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var result = await _iSunatRemunerationDataQuery.GetById(employeeId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<SunatRemunerationDataViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] SunatRemunerationDataRequest request)
        {
            var result = await _iSunatRemunerationDataQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<SunatRemunerationDataViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] SunatRemunerationDataRequest request)
        {
            var result = await _iSunatRemunerationDataQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateSunatRemunerationData(CreateSunatRemunerationDataCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateSunatRemunerationData), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateSunatRemunerationData(UpdateSunatRemunerationDataCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
