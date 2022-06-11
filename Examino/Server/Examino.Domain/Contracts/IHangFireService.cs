using Examino.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Domain.Contracts
{
    public interface IHangFireService
    {
        Task RunMessageTask(string receiver, string sender, string raportId);
    }
}
