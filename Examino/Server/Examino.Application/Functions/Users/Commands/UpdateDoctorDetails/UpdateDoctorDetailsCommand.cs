using Examino.Domain.Requests.Doctors.Update;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.UpdateDoctorDetails
{
    public record UpdateDoctorDetailsCommand : IRequest
    {
        public UpdateDoctorDetailsCommand(UpdateDoctorDetailsRequest body, Guid currentUserId)
        {
            Request = body;
            Request.UserId = currentUserId;            
        }
        public UpdateDoctorDetailsRequest Request { get; set; }
    }
}
