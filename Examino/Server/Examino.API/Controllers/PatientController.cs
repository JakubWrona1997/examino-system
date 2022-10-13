using System.Net;
using Examino.Application.Functions.Users.Commands.UpdatePatientDetails;
using Examino.Application.Functions.Users.Queries.GetPatientDetails;
using Examino.Domain.Contracts;
using Examino.Domain.Requests.Patients.Update;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

            if (user == null)
                return NotFound();

            return Ok(user);
        }
        [Authorize(Roles = "Patient")]
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UpdatePatientDetails([FromBody] UpdatePatientDetailsRequest request)
        {
            var userId = _userProvider.GetUserId();

            await _mediator.Send(new UpdatePatientDetailsCommand(request, userId));

            return Ok();
        }
    }
}