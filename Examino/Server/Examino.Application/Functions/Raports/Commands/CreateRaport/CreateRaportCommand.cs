using MediatR;
using System;

namespace Examino.Application.Functions.Raports.Commands.CreateRaport
{
    public record CreateRaportCommand : IRequest<CreateRaportCommandResponse>
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTimeOffset RaportTime { get; private set; } = DateTimeOffset.Now;
        public string Symptoms { get; set; }
        public string Examination { get; set; }
        public string Diagnosis { get; set; }
        public string Recommendation { get; set; }
        public string Comment { get; set; }
        public PrescriptionRaportDto? Prescription { get; set; }
    }
}
