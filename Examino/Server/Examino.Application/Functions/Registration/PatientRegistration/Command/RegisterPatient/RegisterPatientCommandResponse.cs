using Examino.Application.Responses;
using FluentValidation.Results;
using System;

namespace Examino.Application.Functions.Registration.PatientRegistration.Command
{
    public class RegisterPatientCommandResponse : BaseResponse
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

        public RegisterPatientCommandResponse(string email,string password ) : base()
        {
            Email = email;
            Password = password;
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
