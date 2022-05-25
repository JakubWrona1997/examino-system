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

            const string sqlRaport = "SELECT " +
                        "[Raports].[Id]," +
                        "[Raports].[PatientId], " +
                        "[Raports].[DoctorId], " +
                        "[Raports].[RaportTime], " +
                        "[Raports].[Symptoms], " +
                        "[Raports].[Examination], " +
                        "[Raports].[Diagnosis], " +
                        "[Raports].[Recommendation], " +
                        "[Raports].[Comment] " +
                        "FROM [Raports] " +
                        "WHERE [Raports].[PatientId] = @PatientId";

            var foundRaports = await connection.QueryAsync<RaportDto>(sqlRaport, new { request.PatientId });

            const string sqlPrescription = "SELECT " +
                                  "[Prescriptions].[Id], " +
                                  "[Prescriptions].[RaportId], " +
                                  "[Prescriptions].[Medicines] " +
                                  "FROM [Prescriptions] ";

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

                var prescriptionShortId = Regex.Replace(Convert.ToBase64String(prescriptionFromRaport.Id.ToByteArray()), "[/+=]", "");

                listOfViewModels.Add(new RaportViewModel
                {
                    DoctorName = doctor?.Name,
                    DoctorSurname = doctor?.Surname,
                    PatientName = patient?.Name,
                    PatientSurname = patient?.Surname,
                    PrescriptionCode = prescriptionShortId,
                    Raport = raport,
                    Prescription = prescriptionFromRaport                    
                });
                
            }
            return listOfViewModels;
        }
    }
}
