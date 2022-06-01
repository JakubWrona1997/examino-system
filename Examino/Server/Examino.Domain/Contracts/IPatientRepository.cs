using Examino.Domain.DTOs;
using Examino.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Domain.Contracts
{
    public interface IPatientRepository
    {
       Task<Patient> Register(Patient patient, string password);
       Task UpdateDetails(UpdateUserDetailsDto patient);
       Task<bool> IsEmailAlreadyExist(string email);
       Task<bool> IsPeselAlreadyExist( string pesel);
    }
}
