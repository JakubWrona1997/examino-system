using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Database.Entities
{
    public class Doctor
    {
        public string Id { get; set; }
       [ForeignKey("User")]
       public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public string Specialization { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Raport> Raports { get; set; }

    }
}
