using Examino.Application.Functions.Users.Commands.Login.UserLogin;
using Examino.Application.Functions.Users.Commands.Registration.RegisterPatient;
using Examino.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Examino.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserProvider _userProvider;

        public UserController(IMediator mediator, IUserProvider userProvider)
        {
            _mediator = mediator;
            _userProvider = userProvider;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterPatientAsync([FromBody] RegisterPatientCommand RegisterPatientData)
        {
            var result = await _mediator.Send(RegisterPatientData);

            if (result.Success == false)
            {
                return StatusCode(result.StatusCode, result.Message);
            }

            var RedirectedStatus = await Login(new LoginCommand { Email = result.Email, Password = result.Password });

            return RedirectedStatus;
        }

        [HttpPost("login")]
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

        [HttpGet("auth")]
        public ActionResult Get()
        {
            var token = _userProvider.GetToken();
            return Ok(token);
        }
    }
}
