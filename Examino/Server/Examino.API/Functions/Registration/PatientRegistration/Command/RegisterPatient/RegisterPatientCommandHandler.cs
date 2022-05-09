using Examino.Domain.Contracts;
using MediatR;

namespace Examino.API.Functions.Registration.PatientRegistration.Command
{
    public class RegisterPatientCommandHandler : IRequestHandler<RegisterPatientCommand, RegisterPatientCommandResponse>
    {
        private readonly IPatientRepository _patientRepository;
        public Task<RegisterPatientCommandResponse> Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
