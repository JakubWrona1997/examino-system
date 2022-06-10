using Dapper;
using Examino.Domain;
using Examino.Domain.ConnectionServices;
using Examino.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Queries.GetPatientsBasicInfo
{
    public class GetPatientsBasicInfoQueryHandler : IRequestHandler<GetPatientsBasicInfoQuery, List<PatientsBasicInfoViewModel>>
    {
        private readonly ISqlConnectionService _connectionService;

        public GetPatientsBasicInfoQueryHandler(ISqlConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        public async Task<List<PatientsBasicInfoViewModel>> Handle(GetPatientsBasicInfoQuery request, CancellationToken cancellationToken)
        {
            var connection = await _connectionService.GetAsync();

            string sqlUsers = $@"SELECT 
                                 {(Dbo.Users)}.{nameof(Patient.Id)},
                                 {(Dbo.Users)}.{nameof(Patient.Name)},
                                 {(Dbo.Users)}.{nameof(Patient.Surname)},
                                 {(Dbo.Users)}.{nameof(Patient.PESEL)}
                                 FROM {(Dbo.Users)}
                                 WHERE {(Dbo.Users)}.[UserType] = @patient
                                 ORDER BY {(Dbo.Users)}.{nameof(Patient.Name)}";

            var foundDoctor = await connection.QueryAsync<PatientsBasicInfoViewModel>(sqlUsers, new { patient = "Patient"});

            return foundDoctor.ToList();
        }
    }
}
