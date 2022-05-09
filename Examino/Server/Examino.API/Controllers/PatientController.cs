using Examino.API.Functions.Registration.PatientRegistration;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examino.API.Controllers
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
        [HttpPost]
        public async Task<ActionResult> RegisterPatientAsync([FromBody] RegisterPatientCommand RegisterPatientData)
        {
            await _mediator.Send(RegisterPatientData);
            return Ok();
        }
    }
}
