using Examino.Domain.Contracts;
using Examino.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;

        public PatientRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {

            _userManager = userManager;
            _db = db;
        }

        public  Task<bool> IsEmailAlreadyExist(string email)
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
    }
}
