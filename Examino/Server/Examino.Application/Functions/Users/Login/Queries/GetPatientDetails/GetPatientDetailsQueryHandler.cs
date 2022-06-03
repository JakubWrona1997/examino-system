using Dapper;
using Examino.Domain;
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

            const string sqlUser = "SELECT " +
                                   "[Users].[Id]," +
                                   "[Users].[Name], " +
                                   "[Users].[Surname], " +
                                   "[Users].[BirthDay] AS [DateOfBirth], " +
                                   "[Users].[PESEL], " +
                                   "[Users].[Address], " +
                                   "[Users].[City], " +
                                   "[Users].[Height], " +
                                   "[Users].[Weight], " +
                                   "[Users].[PostalCode], " +
                                   "[Users].[BloodType], " +
                                   "[Users].[Gender], " +
                                   "[Users].[PhoneNumber] " +
                                   "FROM [Users] " +
                                   "WHERE [Users].[Id] = @UserId";

            var foundUser = await connection.QueryFirstAsync<PatientViewModel>(sqlUser, new { request.UserId });

            return foundUser;
        }
    }
}
