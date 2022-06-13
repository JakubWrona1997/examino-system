using Examino.Domain.Requests.Patients.Update;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.UpdatePatientDetails
{
    public record UpdatePatientDetailsCommand : IRequest
    {
        public UpdatePatientDetailsCommand(UpdatePatientDetailsRequest body, Guid Id)
        {
            Request = body;
            UserId = Id;
        }
        public UpdatePatientDetailsRequest Request { get; set; }
        public Guid UserId { get; set; }
    }
}
