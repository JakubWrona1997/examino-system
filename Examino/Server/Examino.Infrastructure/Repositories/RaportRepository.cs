using Examino.Domain.Contracts;
using Examino.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.Repositories
{
    public class RaportRepository : IRaportRepository
    {
        public Task<int> CreateRaport(Raport raport)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRaport(Raport raport)
        {
            throw new NotImplementedException();
        }

        public Task<Raport> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRaport(Raport raport, int id)
        {
            throw new NotImplementedException();
        }
    }
}
