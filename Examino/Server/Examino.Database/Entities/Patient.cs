using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Database.Entities
{
    public class Patient
    {
        public string Id { get; set; }
        [ForeignKey("User")]
       public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int PESEL { get; set; }
        public int Age { get; set; }
        public double? Height { get; set; }
        public int? Weight { get; set; }
        public string BloodType { get; set; }


       public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Raport> Raports { get; set; }

    }
}
