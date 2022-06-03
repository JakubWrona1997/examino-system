using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Login.Queries.GetDoctorDetails
{
    public class DoctorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PESEL { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int? Qualification { get; set; }
        public int? Specialization { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
