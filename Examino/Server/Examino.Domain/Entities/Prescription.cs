using System.ComponentModel.DataAnnotations.Schema;

namespace Examino.Domain.Entities
{
    public class Prescription
    {
        public string Id { get; set; }
        [ForeignKey("Raport")]
        public string RaportId { get; set; }
        public virtual Raport Raport { get; set; }
        public string Medicines { get; set; }      
    }
}
