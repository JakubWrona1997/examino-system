using Examino.Domain.DTOs.UserDTOs;
using Examino.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Domain.Contracts
{
    public interface IDoctorRepository
    {
        Task<Doctor> GetDoctorById(Guid id);
        Task UpdateDetails(UpdateDoctorDetailsDto patient);
        Task DeleteDoctor(Doctor doctor);
        Task<ApplicationUser> Add(Doctor doctor,string password);
    }
}
