using Examino.Domain.Requests.Prescriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Domain.Requests.Raports
{
    public record CreateRaportRequest
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public string Symptoms { get; set; }
        public string Examination { get; set; }
        public string Diagnosis { get; set; }
        public string Recommendation { get; set; }
        public string Comment { get; set; }
        public PrescriptionRequest? Prescription { get; set; }
    }
}
