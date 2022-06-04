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

namespace Examino.Application.Functions.Users.Queries.UserDetails.GetDoctorDetails
{
    public class GetDoctorDetailsQueryHandler : IRequestHandler<GetDoctorDetailsQuery, DoctorViewModel>
    {
        private readonly ISqlConnectionService _connectionService;

        public GetDoctorDetailsQueryHandler(ISqlConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        public async Task<DoctorViewModel> Handle(GetDoctorDetailsQuery request, CancellationToken cancellationToken)
        {
            var connection = await _connectionService.GetAsync();

            string getDoctorDetails = $@"SELECT 
                                      {(Dbo.Users)}.{nameof(Doctor.Id)},
                                      {(Dbo.Users)}.{nameof(Doctor.Name)},
                                      {(Dbo.Users)}.{nameof(Doctor.Surname)},
                                      {(Dbo.Users)}.{nameof(Doctor.BirthDay)} AS [DateOfBirth],
                                      {(Dbo.Users)}.{nameof(Doctor.PESEL)},
                                      {(Dbo.Users)}.{nameof(Doctor.Address)},
                                      {(Dbo.Users)}.{nameof(Doctor.City)},
                                      {(Dbo.Users)}.{nameof(Doctor.PostalCode)},
                                      {(Dbo.Users)}.{nameof(Doctor.Qualification)},
                                      {(Dbo.Users)}.{nameof(Doctor.Specialization)},
                                      {(Dbo.Users)}.{nameof(Doctor.Gender)},
                                      {(Dbo.Users)}.{nameof(Doctor.PhoneNumber)}
                                      FROM {(Dbo.Users)}
                                      WHERE {(Dbo.Users)}.{nameof(Doctor.Id)} = @UserId";

            var foundDoctor = await connection.QueryFirstAsync<DoctorViewModel>(getDoctorDetails, new { request.UserId });

            return foundDoctor;
        }
    }
}
