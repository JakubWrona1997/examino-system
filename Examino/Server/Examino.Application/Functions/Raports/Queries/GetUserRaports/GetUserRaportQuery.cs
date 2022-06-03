using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Raports.Queries.GetUserRaports
{
    public class GetUserRaportQuery : IRequest<List<RaportViewModel>>
    {
        public Guid PatientId { get;} = Guid.Empty;
        public Guid DoctorId { get;} = Guid.Empty;
        public GetUserRaportQuery(Guid userId, string role)
        {
            if(role == "Patient")
                PatientId = userId;
            if(role == "Doctor")
                DoctorId = userId;
        }

    }
}
