using Dapper;
using Examino.Domain;
using Examino.Domain.ConnectionServices;
using Examino.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Raports.Queries
{
    public class GetPatientRaportQueryHandler : IRequestHandler<GetPatientRaportQuery, List<RaportViewModel>>
    {
        private readonly ISqlConnectionService _connectionService;

        public GetPatientRaportQueryHandler(ISqlConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        public async Task<List<RaportViewModel>> Handle(GetPatientRaportQuery request, CancellationToken cancellationToken)
        {
            var connection = await _connectionService.GetAsync();

            string sqlRaport =      $@"SELECT {nameof(Raport.Id)},
                                              {nameof(Raport.PatientId)},
                                              {nameof(Raport.RaportTime)},
                                              {nameof(Raport.Symptoms)},
                                              {nameof(Raport.Examination)},
                                              {nameof(Raport.Diagnosis)},
                                              {nameof(Raport.Recommendation)},
                                              {nameof(Raport.Comment)}
                                              FROM {(Dbo.Raports)}
                                              WHERE {nameof(Raport.PatientId)} = @PatientId";

            var foundRaports = await connection.QueryAsync<RaportDto>(sqlRaport, new { request.PatientId });

            string sqlPrescription = $@"SELECT {nameof(Prescription.Id)},
                                               {nameof(Prescription.RaportId)},
                                               {nameof(Prescription.Medicines)}
                                               FROM {(Dbo.Prescriptions)}";

            var foundPrescription = await connection.QueryAsync<PrescriptionDto>(sqlPrescription);


            const string sqlPatient = "SELECT " +
                                      "[Users].[Id], " +
                                      "[Users].[Name], " +
                                      "[Users].[Surname] " +
                                      "FROM [Users] " +
                                      "WHERE [Users].[UserType] = @patient";           

            var foundPatient = await connection.QueryAsync<PatientDto>(sqlPatient, new { patient = "Patient" });

            const string sqlDoctor = "SELECT " +
                                     "[Users].[Id], " +
                                     "[Users].[Name], " +
                                     "[Users].[Surname] " +
                                     "FROM [Users] " +
                                     "WHERE [USERS].[UserType] = @doctor";

            var foundDoctor = await connection.QueryAsync<DoctorDto>(sqlDoctor, new { doctor = "Doctor" });

            var listOfViewModels = new List<RaportViewModel>();

            foreach (var raport in foundRaports)
            {
                var doctor = foundDoctor?.Where(doc => doc.Id == raport.DoctorId).FirstOrDefault();

                var patient = foundPatient?.Where(pat => pat.Id == raport.PatientId).FirstOrDefault();

                var prescriptionFromRaport = foundPrescription?.Where(rap => rap.RaportId == raport.Id).FirstOrDefault();

                listOfViewModels.Add(new RaportViewModel
                {
                    DoctorName = doctor?.Name,
                    DoctorSurname = doctor?.Surname,
                    PatientName = patient?.Name,
                    PatientSurname = patient?.Surname,
                    Raport = raport,
                    Prescription = prescriptionFromRaport                    
                });
                
            }
            return listOfViewModels;
        }
    }
}
