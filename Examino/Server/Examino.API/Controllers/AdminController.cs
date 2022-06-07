using Examino.Application.Functions.Users.Commands.CreateDoctor;
using Examino.Application.Functions.Users.Commands.DeleteDoctor;
using Examino.Application.Functions.Users.Queries.UserDetails.GetListOfDoctors;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examino.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register-doctor")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDoctor([FromBody]CreateDoctorCommand createDoctor)
        {
            var result = await _mediator.Send(createDoctor);
            if (result.Success == true)
            {
                return StatusCode(201, "Doctor created!");
            }
            else return StatusCode(500);

        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ListOfDoctorsViewModel>>> GetListOfDoctors()
        {
            var result = await _mediator.Send(new GetListOfDoctorsQuery());

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid>> DeleteDoctor([FromRoute]Guid Id)
        {
            var doctorIdToDelete = new DeleteDoctorCommand() { DoctorId = Id };

            var result = await _mediator.Send(doctorIdToDelete);

            return Ok(result);
        }
    }
}
