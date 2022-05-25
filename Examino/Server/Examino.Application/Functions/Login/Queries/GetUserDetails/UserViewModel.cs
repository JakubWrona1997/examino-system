using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Prescriptions.Queries
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        private DateTime BirthDay { get; set; }
        public string DateOfBirth { get { return this.BirthDay.ToString("yyyy-MM-dd"); } set { } }
        public string PESEL { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string? BloodType { get; set; }
    }
}
