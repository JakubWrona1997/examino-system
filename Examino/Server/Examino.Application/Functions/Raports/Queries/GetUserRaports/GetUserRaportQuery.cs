using MediatR;
using System;
using System.Collections.Generic;

namespace Examino.Application.Functions.Raports.Queries.GetUserRaports
{
    public record GetUserRaportQuery : IRequest<List<RaportViewModel>>
    {
        public Guid PatientId { get; } = Guid.Empty;
        public Guid DoctorId { get; } = Guid.Empty;
        public GetUserRaportQuery(Guid userId, string role)
        {
            switch (role)
            {
                case "Patient":
                    PatientId = userId;
                    break;
                case "Doctor":
                    DoctorId = userId;
                    break;
            }
        }
    }
}
