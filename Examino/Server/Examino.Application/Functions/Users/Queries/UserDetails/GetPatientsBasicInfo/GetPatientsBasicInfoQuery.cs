using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Queries.UserDetails.GetPatientsBasicInfo
{
    public class GetPatientsBasicInfoQuery : IRequest<List<PatientsBasicInfoViewModel>>
    {
    }
}
