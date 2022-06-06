using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Domain.Contracts
{
    public interface IValidationService
    {
        Task<bool> IsEmailAlreadyExist(string email);
        Task<bool> IsPeselAlreadyExist(string pesel);
    }
}
