using Microsoft.AspNetCore.Identity;

namespace Examino.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {       
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? BirthDay { get; set; }
        public long? PESEL { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }

        public virtual ICollection<Raport>? Raports { get; set; }
    }
}
