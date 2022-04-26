using System.ComponentModel.DataAnnotations.Schema;

namespace Examino.Domain.Entities
{
    public class Prescription
    {
        public Guid Id { get; set; }
        [ForeignKey("Raport")]
        public Guid RaportId { get; set; }
        public virtual Raport Raport { get; set; }
        public string Medicines { get; set; }      
    }
}
