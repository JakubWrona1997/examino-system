﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Queries.GetDoctorDetails
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
        public string? Qualification { get; set; }
        public string? Specialization { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
