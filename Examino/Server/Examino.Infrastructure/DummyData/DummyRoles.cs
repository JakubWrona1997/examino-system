using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.DummyData
{
    public class DummyRoles
    {
        public static List<IdentityRole<Guid>> GetRoles()
        {
            List<IdentityRole<Guid>> roles = new List<IdentityRole<Guid>>();
            IdentityRole<Guid> role1 = new IdentityRole<Guid>()
            {
                Id = Guid.Parse("7d6f59b9-3f81-4678-9a40-f1d018e711ca"),
                Name="Admin",
                ConcurrencyStamp="1",
                NormalizedName="ADMIN"

            };
            IdentityRole<Guid> role2 = new IdentityRole<Guid>()
            {
                Id = Guid.Parse("15268796-ee21-482c-8f68-fdec407de8ae"),
                Name = "Doctor",
                ConcurrencyStamp = "1",
                NormalizedName = "DOCTOR"

            };
            IdentityRole<Guid> role3 = new IdentityRole<Guid>()
            {
                Id = Guid.Parse("c8b28366-811a-4c6f-9838-f603c452d37e"),
                Name = "Patient",
                ConcurrencyStamp = "1",
                NormalizedName = "PATIENT"

            };

            roles.Add(role1);
            roles.Add(role2);
            roles.Add(role3);
            return roles;
        }
    }
}
