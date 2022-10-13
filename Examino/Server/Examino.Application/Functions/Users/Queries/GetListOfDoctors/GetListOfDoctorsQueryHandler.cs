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

namespace Examino.Application.Functions.Users.Queries.GetListOfDoctors
{
    public class GetListOfDoctorsQueryHandler : IRequestHandler<GetListOfDoctorsQuery, List<ListOfDoctorsViewModel>>
    {
        private readonly ISqlConnectionService _connectionService;

        public GetListOfDoctorsQueryHandler(ISqlConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        public async Task<List<ListOfDoctorsViewModel>> Handle(GetListOfDoctorsQuery request, CancellationToken cancellationToken)
        {
            var connection = await _connectionService.GetAsync();

            string getDoctors =     $@"SELECT 
                                      {(Dbo.Users)}.{nameof(Doctor.Id)},
                                      {(Dbo.Users)}.{nameof(Doctor.Name)},
                                      {(Dbo.Users)}.{nameof(Doctor.Surname)},
                                      {(Dbo.Users)}.{nameof(Doctor.PESEL)},
                                      {(Dbo.Users)}.{nameof(Doctor.Qualification)}
                                      FROM {(Dbo.Users)}
                                      WHERE {(Dbo.Users)}.[UserType] = @doctor
                                      ORDER BY {(Dbo.Users)}.{nameof(Doctor.Name)} DESC";

            var foundDoctors = await connection.QueryAsync<ListOfDoctorsViewModel>(getDoctors, new {doctor = "Doctor"});

            return foundDoctors?.ToList();
        }
    }
}
