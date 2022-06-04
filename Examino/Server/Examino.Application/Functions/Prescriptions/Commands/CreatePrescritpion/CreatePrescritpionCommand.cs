using MediatR;
using System;

namespace Examino.Application.Functions.Prescriptions.Command.CreatePrescritpion
{
    public record CreatePrescritpionCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid RaportId { get; set; }
        public string Medicines { get; set; }
    }
}
