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
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<Patient> _userManager;

        public PatientRepository(ApplicationDbContext dbContext, UserManager<Patient> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public Task<bool> Register(Patient patient)
        {
            _userManager.CreateAsync(patient).Wait();
        }
    }
}
