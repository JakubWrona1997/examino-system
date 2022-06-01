using Examino.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Raports.Queries.GetPatientRaport
{
    public record RaportDto
    {
        public Guid Id { get; set; }
        public Guid? PatientId { get; set; }
        public Guid? DoctorId { get; set; }
        public DateTimeOffset RaportTime { get; set; }
        public string Symptoms { get; set; }
        public string Examination { get; set; }
        public string Diagnosis { get; set; }
        public string Recommendation { get; set; }
        public string Comment { get; set; }
    }
}
