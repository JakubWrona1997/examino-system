using Examino.Application.Functions.Users.Registration.Command.RegisterPatient;
using MediatR;

namespace Examino.Application.Functions.Users.Registration.Command.RegisterPatient
{
    public record RegisterPatientCommand : IRequest<RegisterPatientCommandResponse>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PESEL { get; set; }
        public string Password { get; set; }
    }
}
