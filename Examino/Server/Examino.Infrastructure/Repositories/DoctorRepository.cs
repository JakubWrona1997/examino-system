using AutoMapper;
using Examino.Domain.Contracts;
using Examino.Domain.DTOs.Doctor;
using Examino.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Examino.Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DoctorRepository(ApplicationDbContext dbContext, IMapper mapper,UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ApplicationUser> Add(Doctor doctor,string password)
        {
            await _userManager.CreateAsync(doctor, password);
            var newDoctor = await _userManager.FindByEmailAsync(doctor.Email);
            await _userManager.AddToRoleAsync(newDoctor, "Doctor");
            return newDoctor;

        }
        public async Task<Doctor?> GetDoctorById(Guid id)
        {
            var doctorToDelete = await _dbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);

            return doctorToDelete;
        }

        public async Task DeleteDoctor(Doctor doctor)
        {
            _dbContext.Doctors.Remove(doctor);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateDetails(UpdateDoctorDetailsDto doctor)
        {
            var doctorToEdit = await _dbContext.Doctors.FirstOrDefaultAsync(x => x.Id == doctor.UserId);
            if (doctorToEdit != null)
                _mapper.Map<UpdateDoctorDetailsDto, Doctor>(doctor, doctorToEdit);

            await _dbContext.SaveChangesAsync();
        }
    }
}
