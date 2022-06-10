using Examino.Application.Functions.Users.Commands.Login.UserLogin;
using Examino.Application.Functions.Users.Commands.UpdateDoctorDetails;
using Examino.Application.Functions.Users.Queries.GetDoctorDetails;
using Examino.Application.Functions.Users.Queries.GetPatientsBasicInfo;
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

        [Authorize(Roles = "Doctor")]
        [HttpGet]
        [ProducesResponseType(typeof(DoctorViewModel), (int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<DoctorViewModel>> GetDoctorDetails()
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
        [Authorize(Roles = "Doctor")]
        [HttpGet("users-list")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> GetUsersDetailsList()
        {
            var usersListInViewModel = await _mediator.Send(new GetPatientsBasicInfoQuery());

            return Ok(usersListInViewModel);
        }
    }
}
