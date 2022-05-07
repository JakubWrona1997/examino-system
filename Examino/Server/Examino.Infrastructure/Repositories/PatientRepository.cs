using Examino.Domain.Contracts;
using Examino.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.Repositories
{
    public class LoginPatientRepository : ILoginPatientRepository
    {
        public Task<bool> Register(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
