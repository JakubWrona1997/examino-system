using AutoMapper;
using Examino.Application.Functions.Raports.Commands.CreateRaport;
using Examino.Application.Functions.Raports.Commands.DeleteRaport;
using Examino.Application.Functions.Raports.Queries.GetUserRaports;
using Examino.Domain.Contracts;
using Examino.Domain.Requests.Raports;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Examino.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/raport")]
    [ApiController]
    public class RaportController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserProvider _userProvider;

        public RaportController(IMediator mediator, IUserProvider userProvider)
        {
            _mediator = mediator;
            _userProvider = userProvider;
        }

        [Authorize(Roles = "Doctor, Patient")]
        [HttpGet]
        [ProducesResponseType(typeof(List<RaportViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<RaportViewModel>>> GetUserRaports()
        {
            var userRole = _userProvider.GetUserRole();
            var userId = _userProvider.GetUserId();

            var raports = await _mediator.Send(new GetUserRaportQuery(userId, userRole));

            if (raports == null)
                return NotFound();

            return Ok(raports);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateRaport([FromBody] CreateRaportRequest request)
        {
            var userId = _userProvider.GetUserId();

            var result = await _mediator.Send(new CreateRaportCommand(request, userId));

            if (result.Success == false)
                return BadRequest();

            return Ok(result.Id);
        }
    }
}
