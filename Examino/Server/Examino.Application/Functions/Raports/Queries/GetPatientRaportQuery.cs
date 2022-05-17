using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Raports.Queries
{
    public class GetPatientRaportQuery : IRequest<List<RaportDto>>
    {
        public Guid PatientId { get;}

        public GetPatientRaportQuery(Guid userId)
        {
            PatientId = userId;
        }

    }
}
