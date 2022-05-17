using Examino.Application.Functions.Raports.Commands.CreateRaport;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateRaport([FromBody] CreateRaportCommand createRaportCommand)
        {
            var result = await _mediator.Send(createRaportCommand);

            return Ok(result.Id);
        }
    }
}
