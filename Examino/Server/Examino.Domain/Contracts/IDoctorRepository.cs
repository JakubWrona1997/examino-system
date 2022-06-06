using Examino.Domain.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Domain.Contracts
{
    public interface IDoctorRepository
    {
        Task UpdateDetails(UpdateDoctorDetailsDto patient);
    }
}
