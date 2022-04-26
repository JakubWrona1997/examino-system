using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.DummyData
{
    public class DummyUserRoles
    {
        public static List<IdentityUserRole<Guid>> Get()
        {
            List<IdentityUserRole<Guid>> list = new List<IdentityUserRole<Guid>>();
            var item1 = new IdentityUserRole<Guid>()
            {
                RoleId = Guid.Parse("7d6f59b9-3f81-4678-9a40-f1d018e711ca"),
                UserId = Guid.Parse("8931ce67-348b-48b6-96fc-6fc47a74311e")
            };
            var item2 = new IdentityUserRole<Guid>()
            {
                RoleId = Guid.Parse("15268796-ee21-482c-8f68-fdec407de8ae"),
                UserId = Guid.Parse("ae47d26c-b934-4057-8d05-dfd78ea1a138")
            };
            var item3 = new IdentityUserRole<Guid>()
            {
                RoleId = Guid.Parse("15268796-ee21-482c-8f68-fdec407de8ae"),
                UserId = Guid.Parse("d9339e74-284d-46f4-ad46-b13269c4900e")
            };
            var item4 = new IdentityUserRole<Guid>()
            {
                RoleId = Guid.Parse("c8b28366-811a-4c6f-9838-f603c452d37e"),
                UserId = Guid.Parse("4d9b6996-8e8a-4cec-9f2f-d7f64e2113ca")
            };
            var item5 = new IdentityUserRole<Guid>()
            {
                RoleId = Guid.Parse("c8b28366-811a-4c6f-9838-f603c452d37e"),
                UserId = Guid.Parse("c394c3c5-3727-4b3b-999f-de8180edf15f")
            };
            var item6 = new IdentityUserRole<Guid>()
            {
                RoleId = Guid.Parse("c8b28366-811a-4c6f-9838-f603c452d37e"),
                UserId = Guid.Parse("f43c4920-a607-4d32-a937-ba324e07ebd6")
            };

            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
            list.Add(item4);
            list.Add(item5);
            list.Add(item6);
            return list;
        }
    }
}
