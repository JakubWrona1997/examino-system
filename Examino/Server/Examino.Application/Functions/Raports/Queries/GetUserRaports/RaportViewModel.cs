using System;

namespace Examino.Application.Functions.Raports.Queries.GetUserRaports
{
    public record RaportViewModel
    {
        public Guid Id { get; init; }
        public string PatientName { get; init; }
        public string PatientSurname { get; init; }
        public string DoctorName { get; init; }
        public string DoctorSurname { get; init; }
        public DateTimeOffset RaportTime { get; init; }
        public string Symptoms { get; init; }
        public string Examination { get; init; }
        public string Diagnosis { get; init; }
        public string Recommendation { get; init; }
        public string Comment { get; init; }
        public Guid PrescritpionId { get; init; }
        public string Medicines { get; init; }
    }
}
