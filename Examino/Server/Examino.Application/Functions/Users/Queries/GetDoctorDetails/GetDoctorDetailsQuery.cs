using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Queries.GetDoctorDetails
{
    public class GetDoctorDetailsQuery : IRequest<DoctorViewModel>
    {
        public Guid UserId { get; set; }
        public GetDoctorDetailsQuery(Guid id)
        {
            UserId = id;
        }
    }
}
