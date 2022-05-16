﻿using Examino.Application.Functions.Login.Commands.Login;
using Examino.Application.Functions.Registration.PatientRegistration;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examino.Application.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<ActionResult> RegisterPatientAsync([FromBody] RegisterPatientCommand RegisterPatientData)
        {
         var result  = await _mediator.Send(RegisterPatientData);

            if (result.Success ==false)
            {
                return StatusCode(result.StatusCode, result.Message);
            }

            return Ok(new { Email=result.Email,Password = result.Password });
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            string token = await _mediator.Send(loginCommand); // generowanie tokena
            return Ok(token);
        }
    }
}
