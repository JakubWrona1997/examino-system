using Examino.Application.Responses;
using FluentValidation.Results;
using System;

namespace Examino.Application.Functions.Registration.PatientRegistration.Command
{
    public class RegisterPatientCommandResponse : BaseResponse
    {
        public Guid? PatientId { get; set; }

        public RegisterPatientCommandResponse(Guid patientId ) : base()
        {
            PatientId = patientId;
        }
        public RegisterPatientCommandResponse(string message ) :base(message)
        {

        }
        public RegisterPatientCommandResponse(int statusCode,bool success):base(statusCode, success)
        {

        }
        public RegisterPatientCommandResponse(int statusCode,string message,bool success):base(statusCode,message,success)
        {

        }
      
    }
}
