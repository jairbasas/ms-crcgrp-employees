using Employees.Application.Commands.EmployeeCompanyCommand;
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
    [Route("employees/employee-companies")]
    [ApiController]
    public class EmployeeCompanyController : ControllerBase
    {
        readonly IEmployeeCompanyQuery _iEmployeeCompanyQuery;
        readonly IMediator _mediator;

        public EmployeeCompanyController(IEmployeeCompanyQuery iEmployeeCompanyQuery, IMediator mediator)
        {
            _iEmployeeCompanyQuery = iEmployeeCompanyQuery ?? throw new ArgumentNullException(nameof(iEmployeeCompanyQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Response<EmployeeCompanyViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var result = await _iEmployeeCompanyQuery.GetById(employeeId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<EmployeeCompanyViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] EmployeeCompanyRequest request)
        {
            var result = await _iEmployeeCompanyQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<EmployeeCompanyViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] EmployeeCompanyRequest request)
        {
            var result = await _iEmployeeCompanyQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateEmployeeCompany(CreateEmployeeCompanyCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateEmployeeCompany), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateEmployeeCompany(UpdateEmployeeCompanyCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
