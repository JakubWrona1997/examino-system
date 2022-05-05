using Examino.API.Responses;

namespace Examino.API.Functions.Registration.PatientRegistration.Command
{
    public class CreatePatientCommandResponse : BaseResponse
    {
        public string? Email { get; set; }
    }
}
