using Examino.Application.Functions.Raports.Commands.CreateRaport;
using Examino.Application.Functions.Raports.Queries;
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
        public RaportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{patientId}")]
        [ProducesResponseType(typeof(List<RaportDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetPatientRaports([FromRoute]Guid patientId)
        {
            var raports = await _mediator.Send(new GetPatientRaportQuery(patientId));

            return Ok(raports);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateRaport([FromBody] CreateRaportCommand createRaportCommand)
        {
            var result = await _mediator.Send(createRaportCommand);

            return Ok(result.Id);
        }
    }
}
