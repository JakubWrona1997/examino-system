using Examino.Application.Contracts;
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

        private readonly UserManager<Patient> _userManager;

        public PatientRepository(UserManager<Patient> userManager)
        {
       
            _userManager = userManager;
        }
        public async Task<Guid> Register(Patient patient,string password)
        {
            await _userManager.CreateAsync(patient,password);
            var newMadeUser = _userManager.FindByEmailAsync(patient.Email).Result;
            await _userManager.AddToRoleAsync(newMadeUser, "Patient");
            return newMadeUser.Id;
        }
    }
}
