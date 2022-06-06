using Examino.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.DummyData
{
    public class DummyDoctors
    {
        public static List<Doctor> GetDoctors()
        {
            var hasher = new PasswordHasher<Doctor>();
            List<Doctor> doctors = new List<Doctor>();
            Doctor doctor1 = new Doctor()
            {
                Id = Guid.Parse("ae47d26c-b934-4057-8d05-dfd78ea1a138"),
                Name = "Witold",
                Surname = "Majewski",
                PESEL = "66030280889",
                BirthDay = new DateTime(1966, 3, 2),
                Address = "Baciarego 10",
                City = "Kraków",
                Email = "WitoldMajewski@gmail.com",
                UserName = "WitoldMajewski@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "999321933",
                NormalizedEmail = "WITOLDMAJEWSKI@GMAIL.COM",
                NormalizedUserName = "WITOLDMAJEWSKI@GMAIL.COM",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Qualification = "Cardiologist,Internist",
                Specialization = "cardiology,internal diseases",
                LockoutEnabled=false,
                PostalCode="30-001",
                PasswordHash= hasher.HashPassword(null, "Doctor123!"),
                Gender= "Mężczyzna"

            };
            Doctor doctor2 = new Doctor()
            {
                Id = Guid.Parse("d9339e74-284d-46f4-ad46-b13269c4900e"),
                Name = "Wojciech",
                Surname = "Gwinciarz",
                PESEL = "60070111229",
                BirthDay = new DateTime(1960, 7, 1),
                Address = "Bliska 20",
                City = "Kraków",
                Email = "WGwinciarz@gmail.com",
                UserName = "WGwinciarz@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "129888777",
                NormalizedEmail = "WGWINCIARZ@GMAIL.COM",
                NormalizedUserName = "WGWINCIARZ@GMAIL.COM",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Qualification= "Oncologist,Laryngologist",
                Specialization= "oncological radiotherapy,otolaryngology ",
                LockoutEnabled = false,
                PostalCode = "30-003",
                PasswordHash = hasher.HashPassword(null, "Doctor123!"),
                Gender= "Mężczyzna"

            };


            
            doctors.Add(doctor1);
            doctors.Add(doctor2);

            return doctors;
        }
    }
}
