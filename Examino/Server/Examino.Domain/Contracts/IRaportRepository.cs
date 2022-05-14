using Examino.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Domain.Contracts
{
    public interface IRaportRepository
    {
        Task<Raport> GetById(int id);
        Task<int> CreateRaport(Raport raport);
        Task<bool> UpdateRaport(Raport raport, int id);
        Task<bool> DeleteRaport(Raport raport);
    }
}
