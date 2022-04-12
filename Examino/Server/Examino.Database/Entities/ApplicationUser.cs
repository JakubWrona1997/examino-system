using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Database.Entities
{
    public class ApplicationUser : IdentityUser
    {
   
        public virtual Patient Patient { get; set; }
     
        public virtual Doctor Doctor { get; set; }
    }
}
