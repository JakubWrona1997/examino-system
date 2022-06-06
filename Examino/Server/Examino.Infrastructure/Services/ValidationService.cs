using Dapper;
using Examino.Domain;
using Examino.Domain.Contracts;
using Examino.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.Services
{
    public class ValidationService : IValidationService
    {
        private readonly ISqlConnectionService _connectionService;

        public ValidationService(ISqlConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        public async Task<bool> IsEmailAlreadyExist(string email)
        {
            var connection = await _connectionService.GetAsync();
            string sqlString = @"select u.Email
                            from Users u
                            where u.Email = @Email";

            var matches = await connection.QueryAsync<Patient>(sqlString, new { @Email = email });
            bool result = matches.Count() > 0;

            return result;
        }
        public async Task<bool> IsPeselAlreadyExist(string pesel)
        {
            var connection = await _connectionService.GetAsync();
            var sqlString = @"select u.PESEL
                            from Users u
                            where u.PESEL = @PESEL";
            var matches = await connection.QueryAsync<Patient>(sqlString, new { @PESEL = pesel });
            bool result = matches.Count() > 0;


            return result;
        }
    }
}
