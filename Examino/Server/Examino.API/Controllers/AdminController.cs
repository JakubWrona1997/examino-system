using Examino.Application.Functions.Users.Commands.CreateDoctor;
using Examino.Application.Functions.Users.Commands.DeleteDoctor;
using Examino.Application.Functions.Users.Queries.GetListOfDoctors;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examino.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin")]
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register/doctor")]    
        public async Task<IActionResult> CreateDoctor([FromBody]CreateDoctorCommand createDoctor)
        {
            var result = await _mediator.Send(createDoctor);
            if (result.Success == true)
            {
                return StatusCode(201, "Doctor created!");
            }
            return StatusCode(500);

        }

        [HttpGet]
        public async Task<ActionResult<List<ListOfDoctorsViewModel>>> GetListOfDoctors()
        {
            var result = await _mediator.Send(new GetListOfDoctorsQuery());

            return Ok(result);
        }

        [HttpDelete("{DoctorId}")]      
        public async Task<ActionResult<DeleteDoctorCommandResponse>> DeleteDoctor([FromRoute]Guid DoctorId)
        {
            var doctorIdToDelete = new DeleteDoctorCommand(DoctorId);

            var result = await _mediator.Send(doctorIdToDelete);

            return Ok(result);
        }
    }
}
