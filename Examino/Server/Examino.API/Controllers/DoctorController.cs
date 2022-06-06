using Examino.Application.Functions.Users.Commands.Login.UserLogin;
using Examino.Application.Functions.Users.Commands.UpdateDoctorDetails;
using Examino.Application.Functions.Users.Queries.UserDetails.GetDoctorDetails;
using Examino.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Examino.API.Controllers
{    
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserProvider _userProvider;

        public DoctorController(IMediator mediator, IUserProvider userProvider)
        {
            _mediator = mediator;
            _userProvider = userProvider;
        }
        [HttpPost("login")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            var result = await _mediator.Send(loginCommand);
            if (result.Success == false)
            {
                return StatusCode(result.StatusCode, result.Message);
            }
            CookieOptions cookieOptions = new CookieOptions()
            {
                Path = "/",
                HttpOnly = true,
                Domain = "localhost",
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.Now.AddDays(15)
            };

            HttpContext.Response.Cookies.Append("tokenCookie", result.Token.ToString(), cookieOptions);

            return Ok(result.Token.ToString());
        }

        [HttpPost("logout")]
        public ActionResult Logout()
        {
            //Middleware performing delete cookie
            return Ok();
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet("auth")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Get()
        {
            var token = _userProvider.GetToken();
            return Ok(token);
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet]
        [ProducesResponseType(typeof(DoctorViewModel), (int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<DoctorViewModel>> GetPatientDetails()
        {
            var userId = _userProvider.GetUserId();

            var user = await _mediator.Send(new GetDoctorDetailsQuery(userId));

            return Ok(user);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UpdateDoctorDetails([FromBody] UpdateDoctorDetailsCommand updateDoctorDetailsCommand)
        {
            var userId = _userProvider.GetUserId();

            updateDoctorDetailsCommand.UserId = userId;

            await _mediator.Send(updateDoctorDetailsCommand);

            return Ok();
        }
    }
}
