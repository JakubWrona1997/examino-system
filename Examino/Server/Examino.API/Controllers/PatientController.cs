using Examino.Application.Functions.Login.Commands.Login;
using Examino.Application.Functions.Registration.PatientRegistration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

            return Ok(result.Token);

        }
    }
}
