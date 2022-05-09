using Examino.Application.Responses;
using FluentValidation.Results;

namespace Examino.Application.Functions.Registration.PatientRegistration.Command
{
    public class RegisterPatientCommandResponse : BaseResponse
    {
        public string? PatientId { get; set; }

        public RegisterPatientCommandResponse() : base()
        {

        }
        public RegisterPatientCommandResponse(ValidationResult validationResult) 
        {

        }
    }
}
