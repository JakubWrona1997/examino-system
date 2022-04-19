using System.ComponentModel.DataAnnotations.Schema;

namespace Examino.Domain.Entities
{
    public class Raport
    {
        public string Id { get; set; }
        [ForeignKey("Patient")]
        public string? PatientId { get; set; }
        [ForeignKey("Doctor")]
        public string? DoctorId { get; set; }
        public DateTimeOffset RaportTime { get; set; }
        public string Symptoms { get; set; }
        public string Examination { get; set; }
        public string Diagnosis { get; set; }
        public string Recommendation { get; set; }
        public string Comment { get; set; }

        public virtual Prescription Prescription { get; set; }
        public virtual Patient? Patient { get; set; }
        public virtual Doctor?  Doctor { get; set; }
    }
}
