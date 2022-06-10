using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Domain.DTOs.Doctor
{
    public record UpdateDoctorDetailsDto
    {
        public Guid UserId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Qualification { get; set; }
        public string? Specialization { get; set; }
    }
}
