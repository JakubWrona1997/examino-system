using AutoMapper;
using Examino.Domain.Contracts;
using Examino.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Registration.PatientRegistration.Command
{
    public class RegisterPatientCommandHandler : IRequestHandler<RegisterPatientCommand, RegisterPatientCommandResponse>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public RegisterPatientCommandHandler(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<RegisterPatientCommandResponse> Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
        {
            var patient = _mapper.Map<Patient>(request);

            var patientResult = await _patientRepository.Register(patient, request.Password);

            return new RegisterPatientCommandResponse(patientResult.Email,patientResult.PasswordHash);

        }
    }
}
