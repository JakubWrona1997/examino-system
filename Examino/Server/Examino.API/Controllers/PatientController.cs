﻿using Examino.Application.Functions.Users.Commands.Login.UserLogin;
using Examino.Application.Functions.Users.Commands.Registration.RegisterPatient;
using Examino.Application.Functions.Users.Queries.UserDetails.GetPatientDetails;
using Examino.Application.Functions.Users.Commands.UpdatePatientDetails;
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
        [Authorize(Roles = "Patient")]
        [HttpGet("auth")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Get()
        {
            var token = _userProvider.GetToken();
            return Ok(token);
        }
        [Authorize(Roles = "Patient")]
        [HttpGet]
        [ProducesResponseType(typeof(PatientViewModel), (int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PatientViewModel>> GetPatientDetails()
        {
            var userId = _userProvider.GetUserId();

            var user = await _mediator.Send(new GetPatientDetailsQuery(userId));

            return Ok(user);
        }
        [Authorize(Roles = "Patient")]
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UpdatePatientDetails([FromBody] UpdatePatientDetailsCommand updatePatientDetailsCommand)
        {
            var userId = _userProvider.GetUserId();

            updatePatientDetailsCommand.UserId = userId;

            await _mediator.Send(updatePatientDetailsCommand);

            return Ok();
        }
    }
}