using Examino.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.DummyData
{
    class DummyApplicationUser
    {
       
        public static ApplicationUser GetAdmin()
        {
            ApplicationUser admin = new ApplicationUser()
            {
                Id = Guid.Parse("8931ce67-348b-48b6-96fc-6fc47a74311e"),
                Name ="Antek",
                Surname="Kowalski",
                PESEL = 99101912345,
                BirthDay = new DateTime(1988,10,19),
                Address = "Miejska 10",
                City="Kraków",
                Email="Admin@gmail.com",
                UserName= "Admin@gmail.com",
                EmailConfirmed=true,
                PhoneNumber="999111222",
                NormalizedEmail="ADMIN@GMAIL.COM",
                NormalizedUserName= "ADMIN@GMAIL.COM",
                PhoneNumberConfirmed=true,
                SecurityStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = false,
                PostalCode="30-004"

            };
            return admin;

        }
    }
}
