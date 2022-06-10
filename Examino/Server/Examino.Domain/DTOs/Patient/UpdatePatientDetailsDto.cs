using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Domain.DTOs.Patient
{
    public record UpdatePatientDetailsDto
    {
        public Guid UserId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string? BloodType { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
