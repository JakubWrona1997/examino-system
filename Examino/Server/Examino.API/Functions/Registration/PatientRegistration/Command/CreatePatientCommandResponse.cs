using Examino.API.Responses;
using FluentValidation.Results;

namespace Examino.API.Functions.Registration.PatientRegistration.Command
{
    public class CreatePatientCommandResponse : BaseResponse
    {
        public string? PatientId { get; set; }

        public CreatePatientCommandResponse() : base()
        {

        }
        public CreatePatientCommandResponse(ValidationResult validationResult) 
        {

        }
    }
}
