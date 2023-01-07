using Employees.Application.Commands.UsersCommand;
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
    [Route("employees/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUsersQuery _iUsersQuery;
        readonly IMediator _mediator;

        public UsersController(IUsersQuery iUsersQuery, IMediator mediator)
        {
            _iUsersQuery = iUsersQuery ?? throw new ArgumentNullException(nameof(iUsersQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{userId}")]
        [ProducesResponseType(typeof(Response<UsersViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int userId)
        {
            var result = await _iUsersQuery.GetById(userId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<UsersViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] UsersRequest request)
        {
            request.companyId = Tools.GetCompanyToken(Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", ""));
            var result = await _iUsersQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<UsersViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] UsersRequest request)
        {
            var result = await _iUsersQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateUsers(CreateUsersCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateUsers), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateUsers(UpdateUsersCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
