using Examino.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.DummyData
{
    public  class DummyPatients
    {
        public static List<Patient> GetPatients()
        {
            var hasher = new PasswordHasher<Patient>();
            List<Patient> patients = new List<Patient>(); 
            Patient patient1 = new Patient()
            {
                Id = Guid.Parse("4d9b6996-8e8a-4cec-9f2f-d7f64e2113ca"),
                Name = "Bartek",
                Surname = "Skrzypek",
                PESEL = "78032180802",
                BirthDay = new DateTime(1978, 3, 21),
                Address = "Kwiatowa 20",
                City = "Jeleśnia",
                Email = "BartekSkrzypek@gmail.com",
                UserName = "BartekSkrzypek@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "999111333",
                NormalizedEmail = "BARTEKSKRZYPEK@GMAIL.COM",
                NormalizedUserName = "BARTEKSKRZYPEK@GMAIL.COM",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                BloodType = "B Rh-",
                Height = 175,
                Weight = 80,
                LockoutEnabled = false,
                PostalCode= "34-331",
                PasswordHash = hasher.HashPassword(null, "Patient123!"),
                Gender = "Mężczyzna"
            };
            Patient patient2 = new Patient()
            {
                Id = Guid.Parse("c394c3c5-3727-4b3b-999f-de8180edf15f"),
                Name = "Michał",
                Surname = "Gwizd",
                PESEL = "90042182882",
                BirthDay = new DateTime(1990, 4, 21),
                Address = "Morksa 20",
                City = "Gdańsk",
                Email = "MichalGwizd@gmail.com",
                UserName = "MichalGwizd@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "999888777",
                NormalizedEmail = "MICHALGWIZD@GMAIL.COM",
                NormalizedUserName = "MICHALGWIZD@GMAIL.COM",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                BloodType="B Rh+",
                Height=172,
                Weight=70,
                LockoutEnabled = false,
                PostalCode ="80-001",
                PasswordHash = hasher.HashPassword(null, "Patient123!"),
                Gender= "Mężczyzna"

            };
            Patient patient3 = new Patient()
            {
                Id = Guid.Parse("f43c4920-a607-4d32-a937-ba324e07ebd6"),
                Name = "Jakub",
                Surname = "Kwiatowski",
                PESEL = "99042382888",
                BirthDay = new DateTime(1999, 4, 23),
                Address = "Wiejska 50",
                City = "Zakopane",
                Email = "Jakub1999@gmail.com",
                UserName = "Jakub1999@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "992488111",
                NormalizedEmail = "JAKUB1999@GMAIL.COM",
                NormalizedUserName = "JAKUB1999@GMAIL.COM",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                BloodType = "A Rh+",
                Height = 192,
                Weight = 90,
                LockoutEnabled = false,
                PostalCode = "34-500",
                PasswordHash = hasher.HashPassword(null, "Patient123!"),
                Gender= "Mężczyzna"

            };

            patients.Add(patient1); 
            patients.Add(patient2);
            patients.Add(patient3);

            return patients;
        }
    }
}
