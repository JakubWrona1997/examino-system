using Examino.Application.Functions.Login.Commands.Login;
using Examino.Application.Functions.Prescriptions.Queries;
using Examino.Application.Functions.Registration.PatientRegistration;
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
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.HttpOnly = true;
            cookieOptions.Expires = DateTime.Now.AddDays(15);
            HttpContext.Response.Cookies.Append("tokenCookie", result.Token.ToString(), cookieOptions);
            return Ok();
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
    }
}