using Microsoft.AspNetCore.Identity;

namespace Examino.Infrastructure.Entities
{
    public class ApplicationUser : IdentityUser
    {       
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public DateTime? BirthDay { get; set; }
        public long? PESEL { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }

        public virtual ICollection<Raport>? Raports { get; set; }
    }
}
