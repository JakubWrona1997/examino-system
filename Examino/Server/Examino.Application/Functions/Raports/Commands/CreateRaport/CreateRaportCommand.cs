using Examino.Domain.Requests.Prescriptions;
using Examino.Domain.Requests.Raports;
using MediatR;
using System;

namespace Examino.Application.Functions.Raports.Commands.CreateRaport
{
    public record CreateRaportCommand : IRequest<CreateRaportCommandResponse>
    {
        public CreateRaportCommand(CreateRaportRequest body, Guid currentUserId)
        {
            Request = body;

            if(currentUserId != Guid.Empty)
                Request.DoctorId = currentUserId;

            new CreateRaportCommandResponse(400, "User cannot be empty!", false);
        }
        public CreateRaportRequest Request { get; set; }
    }
}
