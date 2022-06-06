using Examino.Application.Functions.Users.Commands.CreateDoctor;
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

        [HttpPost("createDoctor")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDoctor(CreateDoctorCommand createDoctor)
        {
            var result = await _mediator.Send(createDoctor);
            if (result.Success == true)
            {
                return StatusCode(201, "Doctor created!");
            }
            else return StatusCode(500);

        }
    }
}
