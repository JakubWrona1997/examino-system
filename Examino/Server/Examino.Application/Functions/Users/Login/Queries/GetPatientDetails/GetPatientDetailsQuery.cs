using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Login.Queries.GetPatientDetails
{
    public class GetPatientDetailsQuery : IRequest<PatientViewModel>
    {
        public Guid UserId { get; set; }
        public GetPatientDetailsQuery(Guid id)
        {
            UserId = id;
        }
    }
}
