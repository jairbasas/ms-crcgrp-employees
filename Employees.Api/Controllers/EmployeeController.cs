using Employees.Application.Commands.EmployeeCommand;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Employees.Api.Utility;
using Microsoft.Net.Http.Headers;

namespace Employees.Api.Controllers
{
    [Authorize]
    [Route("employees/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeQuery _iEmployeeQuery;
        readonly IMediator _mediator;

        public EmployeeController(IEmployeeQuery iEmployeeQuery, IMediator mediator)
        {
            _iEmployeeQuery = iEmployeeQuery ?? throw new ArgumentNullException(nameof(iEmployeeQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Response<EmployeeViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var result = await _iEmployeeQuery.GetById(employeeId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<EmployeeViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] EmployeeRequest request)
        {
            var result = await _iEmployeeQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<EmployeeViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] EmployeeRequest request)
        {
            var result = await _iEmployeeQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeCommand command)
        {
            command.companyId = Tools.GetCompanyToken(Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", ""));
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateEmployee), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
