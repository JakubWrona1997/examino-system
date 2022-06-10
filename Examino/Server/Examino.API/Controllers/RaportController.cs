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
        private readonly IMapper _mapper;

        public RaportController(IMediator mediator, IUserProvider userProvider, IMapper mapper)
        {
            _mediator = mediator;
            _userProvider = userProvider;
            _mapper = mapper;
        }

        [Authorize(Roles = "Doctor, Patient")]
        [HttpGet]
        [ProducesResponseType(typeof(List<RaportViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<RaportViewModel>>> GetUserRaports()
        {
            var userRole = _userProvider.GetUserRole();
            var userId = _userProvider.GetUserId();

            var raports = await _mediator.Send(new GetUserRaportQuery(userId, userRole));            

            return Ok(raports);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateRaport([FromBody] CreateRaportRequest request)
        {
            var userId = _userProvider.GetUserId();

            var result = await _mediator.Send(new CreateRaportCommand(request, userId));

            return Ok(result.Id);
        }

        [Authorize(Roles = "Doctor")]
        [HttpDelete("{RaportId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<DeleteRaportCommandResponse>> DeleteRaport([FromRoute]Guid RaportId)
        {
            var deleteRaportCommand = new DeleteRaportCommand(RaportId);
            var result = await _mediator.Send(deleteRaportCommand);
            return Ok(result);
        }
    }
}
