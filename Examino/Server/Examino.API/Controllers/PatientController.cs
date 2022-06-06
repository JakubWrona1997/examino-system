using Examino.Application.Functions.Users.Commands.Login.UserLogin;
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