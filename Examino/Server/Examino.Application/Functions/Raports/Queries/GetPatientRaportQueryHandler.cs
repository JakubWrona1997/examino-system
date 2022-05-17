﻿using Dapper;
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

namespace Examino.Application.Functions.Raports.Queries
{
    public class GetPatientRaportQueryHandler : IRequestHandler<GetPatientRaportQuery, List<RaportDto>>
    {
        private readonly ISqlConnectionService _connectionService;

        public GetPatientRaportQueryHandler(ISqlConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        public async Task<List<RaportDto>> Handle(GetPatientRaportQuery request, CancellationToken cancellationToken)
        {
            var connection = await _connectionService.GetAsync();

            var sql =   "SELECT " +
                        "[Raports].[Id]," +
                        "[Raports].[PatientId], " +
                        "[Raports].[DoctorId], " +
                        "[Raports].[RaportTime], " +
                        "[Raports].[Symptoms], " +
                        "[Raports].[Examination], " +
                        "[Raports].[Diagnosis], " +
                        "[Raports].[Recommendation], " +
                        "[Raports].[Comment] " +
                        "FROM [Raports]" +
                        "WHERE [Raports].PatientId = @PatientId";

            var foundRaport = await connection.QueryAsync<RaportDto>(sql, new { request.PatientId });

            return foundRaport.AsList();
        }
    }
}
