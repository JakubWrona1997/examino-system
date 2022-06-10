using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Domain.Requests.Prescriptions
{
    public record PrescriptionRequest
    {
        public Guid Id { get; set; }
        public Guid RaportId { get; set; }
        public string Medicines { get; set; }
    }
}
