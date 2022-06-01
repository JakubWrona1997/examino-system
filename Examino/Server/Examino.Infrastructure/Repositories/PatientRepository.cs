<<<<<<< HEAD
﻿using AutoMapper;
using Examino.Domain.Contracts;
using Examino.Domain.DTOs;
=======
﻿using Dapper;
using Examino.Domain;
using Examino.Domain.Contracts;
>>>>>>> 67b40dbb51e1958aa65367b2fc10ca126b8c5db8
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
<<<<<<< HEAD
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;

        public PatientRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
=======
        private readonly ISqlConnectionService _connectionService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;

        public PatientRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext db, ISqlConnectionService connectionService)
        {
            _connectionService = connectionService;
>>>>>>> 67b40dbb51e1958aa65367b2fc10ca126b8c5db8
            _userManager = userManager;
            _db = db;
        }

        public async Task<bool> IsEmailAlreadyExist(string email)
        {
            var connection = await _connectionService.GetAsync();
            string sqlString = @"select u.Email
                            from Users u
                            where u.Email = @Email";

            var matches = await connection.QueryAsync<Patient>(sqlString, new { @Email = email });
            bool result = matches.Count() > 0;

            return result;
        }
        public async Task<bool> IsPeselAlreadyExist(string pesel)
        {
            var connection = await _connectionService.GetAsync();
            var sqlString = @"select u.PESEL
                            from Users u
                            where u.PESEL = @PESEL";
            var matches = await connection.QueryAsync<Patient>(sqlString, new { @PESEL = pesel });
            bool result = matches.Count() > 0;


            return result;
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
