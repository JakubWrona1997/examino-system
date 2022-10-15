using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using Examino.Domain;
using Examino.Domain.ConnectionServices;
using Examino.Domain.Entities;
using MediatR;

namespace Examino.Application.Functions.Raports.Queries.GetUserRaports
{
    public class GetUserRaportQueryHandler : IRequestHandler<GetUserRaportQuery, List<RaportViewModel>>
    {
        private readonly ISqlConnectionService _connectionService;
        private readonly IMapper _mapper;

        public GetUserRaportQueryHandler(ISqlConnectionService connectionService, IMapper mapper)
        {
            _connectionService = connectionService;
            _mapper = mapper;

        }
        public async Task<List<RaportViewModel>> Handle(GetUserRaportQuery request, CancellationToken cancellationToken)
        {
            var connection = await _connectionService.GetAsync();

            string sqlRaport =      $@"SELECT {(Dbo.Raports)}.{nameof(Raport.Id)} AS Id,
                                              D.Name AS DoctorName,
                                              D.Surname AS DoctorSurname,
                                              P.Name AS PatientName,
                                              P.Surname AS PatientSurname,
                                              {nameof(Raport.RaportTime)},
                                              {nameof(Raport.Symptoms)},
                                              {nameof(Raport.Examination)},
                                              {nameof(Raport.Diagnosis)},
                                              {nameof(Raport.Recommendation)},
                                              {nameof(Raport.Comment)},
                                              {(Dbo.Prescriptions)}.{nameof(Prescription.Id)} AS PrescriptionsId,
                                              {(Dbo.Prescriptions)}.{nameof(Prescription.Medicines)}
                                              FROM {(Dbo.Raports)}
                                              LEFT OUTER JOIN {Dbo.Prescriptions} ON {(Dbo.Raports)}.{nameof(Raport.Id)} = {(Dbo.Prescriptions)}.{nameof(Prescription.RaportId)}
                                              JOIN {(Dbo.Users)} D ON D.Id = {nameof(Raport.DoctorId)}
                                              JOIN {(Dbo.Users)} P ON P.Id = {nameof(Raport.PatientId)}
                                              WHERE {nameof(Raport.PatientId)} = @PatientId OR {nameof(Raport.DoctorId)} = @DoctorId
                                              ORDER BY {nameof(Raport.RaportTime)} DESC";

            var foundRaports = await connection.QueryAsync<RaportDto>(sqlRaport, new { request.PatientId, request.DoctorId });

            var result = _mapper.Map<List<RaportViewModel>>(foundRaports.ToList());

            return result;
        }
    }
}
