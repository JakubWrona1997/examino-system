using AutoMapper;
using Examino.Application.Functions.Prescriptions.Command.CreatePrescritpion;
using Examino.Application.Functions.Raports.Commands.CreateRaport;
using Examino.Application.Functions.Raports.Commands.DeleteRaport;
using Examino.Application.Functions.Raports.Queries.GetUserRaports;
using Examino.Domain.Contracts;
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
        public async Task<ActionResult<Guid>> CreateRaport([FromBody] CreateRaportCommand createRaportCommand)
        {
            var userId = _userProvider.GetUserId();
            if(userId != Guid.Empty)
                createRaportCommand.DoctorId = userId;            

            var result = await _mediator.Send(createRaportCommand);
                      
            if (createRaportCommand.Prescription != null)
            {
                createRaportCommand.Prescription.RaportId = createRaportCommand.Id;
                var createPrescriptionCommand = _mapper.Map<CreatePrescritpionCommand>(createRaportCommand.Prescription);
                await _mediator.Send(createPrescriptionCommand);
            }
               
            return Ok(result.Id);
        }
        [Authorize(Roles = "Doctor")]
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
