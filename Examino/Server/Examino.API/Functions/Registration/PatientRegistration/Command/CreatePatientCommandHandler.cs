using Examino.Domain.Contracts;
using MediatR;

namespace Examino.API.Functions.Registration.PatientRegistration.Command
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand>
    {
        private readonly ILoginPatientRepository _patientRepository;
        public Task<Unit> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
