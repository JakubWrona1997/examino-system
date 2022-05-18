using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Raports.Queries
{
    public record PrescriptionDto
    {
        public Guid Id { get; set; }
        public Guid RaportId { get; set; }
        public string Medicines { get; set; }
    }
}
