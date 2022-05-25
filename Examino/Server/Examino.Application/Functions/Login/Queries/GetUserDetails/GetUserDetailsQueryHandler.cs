using Dapper;
using Examino.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Prescriptions.Queries
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserViewModel>
    {
        private readonly ISqlConnectionService _connectionService;

        public GetUserDetailsQueryHandler(ISqlConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        public async Task<UserViewModel> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var connection = await _connectionService.GetAsync();

            const string sqlUser = "SELECT " +
                        "[Users].[Id]," +
                        "[Users].[Name], " +
                        "[Users].[Surname], " +
                        "[Users].[BirthDay], " +
                        "[Users].[PESEL], " +
                        "[Users].[Address], " +
                        "[Users].[City], " +
                        "[Users].[Height], " +
                        "[Users].[Weight], " +
                        "[Users].[PostalCode], " +
                        "[Users].[BloodType], " +
                        "[Users].[PhoneNumber] " +
                        "FROM [Users] " +
                        "WHERE [Users].[Id] = @UserId";

            var foundUser = await connection.QueryFirstAsync<UserViewModel>(sqlUser, new { request.UserId });

            return foundUser;
        }
    }
}
