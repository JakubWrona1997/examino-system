using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Database.Entities
{
    public class Raport
    {
        public string Id { get; set; }
        [ForeignKey("Patient")]
        public string? PatientId { get; set; }
        [ForeignKey("Doctor")]
        public string? DoctorId { get; set; }
        public DateTime RaportTime { get; set; }
        public string Symptoms { get; set; }
        public string Examination { get; set; }
        public string Diagnosis { get; set; }
        public string Recommendation { get; set; }
        public string Comment { get; set; }

        public virtual Prescription Prescription { get; set; }
        public virtual Patient? Patient { get; set; }
        public virtual Doctor? Doctor { get; set; }


    }
}
