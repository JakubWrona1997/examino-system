using Examino.Domain.DTOs.Doctor;
using Examino.Domain.Entities;

namespace Examino.Domain.Contracts
{
    public interface IDoctorRepository
    {
        Task<Doctor?> GetDoctorById(Guid id);
        Task UpdateDetails(UpdateDoctorDetailsDto patient);
        Task DeleteDoctor(Doctor doctor);
        Task<ApplicationUser> Add(Doctor doctor,string password);
    }
}
