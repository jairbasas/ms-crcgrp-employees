using Employees.Application.Commands.ContractCommand;
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
    [Route("employees/contracts")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        readonly IContractQuery _iContractQuery;
        readonly IMediator _mediator;

        public ContractController(IContractQuery iContractQuery, IMediator mediator)
        {
            _iContractQuery = iContractQuery ?? throw new ArgumentNullException(nameof(iContractQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Response<ContractViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var result = await _iContractQuery.GetById(employeeId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<ContractViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] ContractRequest request)
        {
            var result = await _iContractQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<ContractViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] ContractRequest request)
        {
            var result = await _iContractQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateContract(CreateContractCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateContract), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateContract(UpdateContractCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
