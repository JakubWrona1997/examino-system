using AutoMapper;
using Dapper;
using Examino.Application.Functions.PeselChecker;
using Examino.Domain;
using Examino.Domain.Contracts;
using Examino.Domain.DTOs.Patient;
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

        public PatientRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext db, ISqlConnectionService connectionService, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _db = db;
        }

        public async Task<Patient> Register(Patient patient, string password)
        {
            //haslo musi byc dobre inacze null w bazie
            PeselChecker pesel = new PeselChecker(patient.PESEL);
            if(pesel.isValid() != false)
            {
                patient.BirthDay = pesel.CreateDateOfBirth();
                patient.Gender = pesel.getSex();
                await _userManager.CreateAsync(patient, password);
                var newMadeUser = _userManager.FindByEmailAsync(patient.Email).Result;
                await _userManager.AddToRoleAsync(newMadeUser, "Patient");
                return (Patient)newMadeUser;
            }
            return null;

        }

        public async Task UpdateDetails(UpdatePatientDetailsDto patient)
        {
            var patientToEdit = await _db.Patients.FirstOrDefaultAsync(x => x.Id == patient.UserId);
            if(patientToEdit!= null)
                _mapper.Map<UpdatePatientDetailsDto, Patient>(patient, patientToEdit);
            
            await _db.SaveChangesAsync();            
        }
    }
}
