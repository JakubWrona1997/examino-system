using MediatR;
using System;

namespace Examino.Application.Functions.Prescriptions.Events.CreatePrescritpion
{
    public record CreatePrescritpionEvent : INotification
    {
        public CreatePrescritpionEvent(Guid raportId, string medicines)
        {
            RaportId = raportId;
            Medicines = medicines;
        }
        public Guid Id { get; set; }
        public Guid RaportId { get; set; }
        public string Medicines { get; set; }
    }
}
