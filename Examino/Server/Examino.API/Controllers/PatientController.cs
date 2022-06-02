using Examino.Application.Functions.Users.Login.Commands.UserLogin;
using Examino.Application.Functions.Users.Login.Queries.GetUserDetails;
using Examino.Application.Functions.Users.Registration.Command.RegisterPatient;
using Examino.Application.Functions.Users.UserDetails.UpdateUserDetails;
using Examino.Domain.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Examino.Application.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserProvider _userProvider;

        public PatientController(IMediator mediator, IUserProvider userProvider)
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
        public async Task<ActionResult> Logout()
        {

            return Ok();
        }

        [HttpGet("auth")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Get()
        {
            var token = _userProvider.GetToken();
            return Ok(token);
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UserViewModel>> GetUserDetails()
        {
            var userId = _userProvider.GetUserId();

            var user = await _mediator.Send(new GetUserDetailsQuery(userId));

            return Ok(user);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UpdateUserDetails([FromBody] UpdateUserDetailsCommand updateUserDetailsCommand)
        {
            var userId = _userProvider.GetUserId();

            updateUserDetailsCommand.UserId = userId;

            await _mediator.Send(updateUserDetailsCommand);

            return RedirectToAction("GetUserDetails");
        }
    }
}