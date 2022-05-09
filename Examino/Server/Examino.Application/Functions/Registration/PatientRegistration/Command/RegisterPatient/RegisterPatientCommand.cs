using Examino.Application.Functions.Registration.PatientRegistration.Command;
using MediatR;

namespace Examino.Application.Functions.Registration.PatientRegistration
{
    public record RegisterPatientCommand : IRequest<RegisterPatientCommandResponse>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long  PESEL { get; set; }
        public string Password { get; set; }
    }
}
