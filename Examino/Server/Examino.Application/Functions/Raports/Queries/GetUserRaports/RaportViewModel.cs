using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Raports.Queries.GetUserRaports
{
    public class RaportViewModel
    {
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public RaportDto Raport { get; set; }
        public PrescriptionDto Prescription { get; set; }
    }
}
