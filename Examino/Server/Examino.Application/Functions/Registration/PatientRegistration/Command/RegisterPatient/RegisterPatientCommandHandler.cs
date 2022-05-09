using Examino.Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Registration.PatientRegistration.Command
{
    public class RegisterPatientCommandHandler : IRequestHandler<RegisterPatientCommand, RegisterPatientCommandResponse>
    {
        private readonly IPatientRepository _patientRepository;

        public Task<RegisterPatientCommandResponse> Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
