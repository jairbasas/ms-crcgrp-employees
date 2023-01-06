using Employees.Application.Commands.CompanyCommand;
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
    [Route("companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly ICompanyQuery _iCompanyQuery;
        readonly IMediator _mediator;

        public CompanyController(ICompanyQuery iCompanyQuery, IMediator mediator)
        {
            _iCompanyQuery = iCompanyQuery ?? throw new ArgumentNullException(nameof(iCompanyQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{companyId}")]
        [ProducesResponseType(typeof(Response<CompanyViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int companyId)
        {
            var result = await _iCompanyQuery.GetById(companyId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(Response<IEnumerable<CompanyViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] CompanyRequest request)
        {
            var result = await _iCompanyQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(Response<PaginationViewModel<CompanyViewModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] CompanyRequest request)
        {
            var result = await _iCompanyQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateCompany(CreateCompanyCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateCompany), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
