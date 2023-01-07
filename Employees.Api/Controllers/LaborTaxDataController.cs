using Employees.Application.Commands.LaborTaxDataCommand;
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
    [Route("employees/labor-tax-data")]
    [ApiController]
    public class LaborTaxDataController : ControllerBase
    {
        readonly ILaborTaxDataQuery _iLaborTaxDataQuery;
        readonly IMediator _mediator;

        public LaborTaxDataController(ILaborTaxDataQuery iLaborTaxDataQuery, IMediator mediator)
        {
            _iLaborTaxDataQuery = iLaborTaxDataQuery ?? throw new ArgumentNullException(nameof(iLaborTaxDataQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Response<LaborTaxDataViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var result = await _iLaborTaxDataQuery.GetById(employeeId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<LaborTaxDataViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] LaborTaxDataRequest request)
        {
            var result = await _iLaborTaxDataQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<LaborTaxDataViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] LaborTaxDataRequest request)
        {
            var result = await _iLaborTaxDataQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateLaborTaxData(CreateLaborTaxDataCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateLaborTaxData), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateLaborTaxData(UpdateLaborTaxDataCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
