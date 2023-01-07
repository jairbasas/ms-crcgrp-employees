using Employees.Application.Commands.HealthBenefitsCommand;
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
    [Route("employees/health-benefits")]
    [ApiController]
    public class HealthBenefitsController : ControllerBase
    {
        readonly IHealthBenefitsQuery _iHealthBenefitsQuery;
        readonly IMediator _mediator;

        public HealthBenefitsController(IHealthBenefitsQuery iHealthBenefitsQuery, IMediator mediator)
        {
            _iHealthBenefitsQuery = iHealthBenefitsQuery ?? throw new ArgumentNullException(nameof(iHealthBenefitsQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Response<HealthBenefitsViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var result = await _iHealthBenefitsQuery.GetById(employeeId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<HealthBenefitsViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] HealthBenefitsRequest request)
        {
            var result = await _iHealthBenefitsQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<HealthBenefitsViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] HealthBenefitsRequest request)
        {
            var result = await _iHealthBenefitsQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateHealthBenefits(CreateHealthBenefitsCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateHealthBenefits), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateHealthBenefits(UpdateHealthBenefitsCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
