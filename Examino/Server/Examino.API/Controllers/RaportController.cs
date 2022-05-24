using Examino.Application.Functions.Raports.Commands.CreateRaport;
using Examino.Application.Functions.Raports.Commands.DeleteRaport;
using Examino.Application.Functions.Raports.Queries;
using Examino.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Examino.API.Controllers
{
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

        [HttpGet("{patientId}")]
        [ProducesResponseType(typeof(List<RaportDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetPatientRaports([FromRoute]Guid patientId)
        {
            //var userId = _userProvider.GetUserId(); 

            var raports = await _mediator.Send(new GetPatientRaportQuery(patientId));

            return Ok(raports);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateRaport([FromBody] CreateRaportCommand createRaportCommand)
        {
            var result = await _mediator.Send(createRaportCommand);

            return Ok(result.Id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> DeleteRaport([FromRoute]Guid id)
        {
            var deleteRaportCommand = new DeleteRaportCommand() { RaportId = id };
            await _mediator.Send(deleteRaportCommand);
            return NoContent();
        }
    }
}
