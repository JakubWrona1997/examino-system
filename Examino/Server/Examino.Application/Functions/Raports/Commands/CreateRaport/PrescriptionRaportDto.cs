using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Raports.Commands.CreateRaport
{
    public record PrescriptionRaportDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid RaportId { get; set; }
        public string Medicines { get; set; }
    }
}
