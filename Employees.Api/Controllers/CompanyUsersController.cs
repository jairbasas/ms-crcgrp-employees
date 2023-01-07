using Employees.Application.Commands.CompanyUsersCommand;
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
    //[Authorize]
    [Route("employees/company-users")]
    [ApiController]
    public class CompanyUsersController : ControllerBase
    {
        readonly ICompanyUsersQuery _iUsersQuery;
        readonly IMediator _mediator;

        public CompanyUsersController(ICompanyUsersQuery iUsersQuery, IMediator mediator)
        {
            _iUsersQuery = iUsersQuery ?? throw new ArgumentNullException(nameof(iUsersQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Authorize]
        [HttpGet]
        [Route("{companyUserId}")]
        [ProducesResponseType(typeof(Response<CompanyUsersViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int companyUserId)
        {
            var result = await _iUsersQuery.GetById(companyUserId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<CompanyUsersViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] CompanyUsersRequest request)
        {
            var result = await _iUsersQuery.GetBySearch(request);

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<CompanyUsersViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] CompanyUsersRequest request)
        {
            var result = await _iUsersQuery.GetByFindAll(request);

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateCompanyUsers(CreateCompanyUsersCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateCompanyUsers), result);
        }

        [Authorize]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateCompanyUsers(UpdateCompanyUsersCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
