using AutoMapper;
using Examino.Domain.Contracts;
using Examino.Domain.DTOs;
using Examino.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;

        public PatientRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _db = db;
        }

        public Task<bool> IsEmailAlreadyExist(string email)
        {
            var matches = _db.Users.
                 Any(a => a.Email.Equals(email));

            return Task.FromResult(matches);
        }
        public Task<bool> IsPeselAlreadyExist(string pesel)
        {
            var matches = _db.Users.
                 Any(a => a.PESEL.Equals(pesel));

            return Task.FromResult(matches);
        }

        public async Task<Patient> Register(Patient patient, string password)
        {
            //haslo musi byc dobre inacze null w bazie
            await _userManager.CreateAsync(patient, password);
            var newMadeUser = _userManager.FindByEmailAsync(patient.Email).Result;
            await _userManager.AddToRoleAsync(newMadeUser, "Patient");
            return (Patient)newMadeUser;
        }

        public async Task UpdateDetails(UpdateUserDetailsDto patient)
        {
            var patientToEdit = await _db.Patients.FirstOrDefaultAsync(x => x.Id == patient.UserId);
            
            var dataToEdit = _mapper.Map<UpdateUserDetailsDto, Patient>(patient, patientToEdit);
            
            await _db.SaveChangesAsync();            
        }
    }
}
