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

namespace Examino.Application.Functions.Users.Login.Queries.GetPatientDetails
{
    public class GetPatientDetailsQueryHandler : IRequestHandler<GetPatientDetailsQuery, PatientViewModel>
    {
        private readonly ISqlConnectionService _connectionService;

        public GetPatientDetailsQueryHandler(ISqlConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        public async Task<PatientViewModel> Handle(GetPatientDetailsQuery request, CancellationToken cancellationToken)
        {
            var connection = await _connectionService.GetAsync();

            string sqlUser = $@"SELECT
                                {(Dbo.Users)}.{nameof(Patient.Id)},
                                {(Dbo.Users)}.{nameof(Patient.Name)},
                                {(Dbo.Users)}.{nameof(Patient.Surname)},
                                {(Dbo.Users)}.{nameof(Patient.BirthDay)} AS [DateOfBirth],
                                {(Dbo.Users)}.{nameof(Patient.PESEL)},
                                {(Dbo.Users)}.{nameof(Patient.Address)},
                                {(Dbo.Users)}.{nameof(Patient.City)},
                                {(Dbo.Users)}.{nameof(Patient.Height)},
                                {(Dbo.Users)}.{nameof(Patient.Weight)},
                                {(Dbo.Users)}.{nameof(Patient.PostalCode)},
                                {(Dbo.Users)}.{nameof(Patient.BloodType)},
                                {(Dbo.Users)}.{nameof(Patient.Gender)},
                                {(Dbo.Users)}.{nameof(Patient.PhoneNumber)}
                                FROM {(Dbo.Users)}
                                WHERE {(Dbo.Users)}.{nameof(Patient.Id)} = @UserId";

            var foundUser = await connection.QueryFirstAsync<PatientViewModel>(sqlUser, new { request.UserId });

            return foundUser;
        }
    }
}
