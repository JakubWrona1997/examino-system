using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Database.Entities
{
    public class Prescription
    {
        public string Id { get; set; }
        [ForeignKey("Raport")]
        public string RaportId { get; set; }
        public string Medicines { get; set; }
        public int BarCode { get; set; }
        public virtual Raport Raport { get; set; }
    }
}
