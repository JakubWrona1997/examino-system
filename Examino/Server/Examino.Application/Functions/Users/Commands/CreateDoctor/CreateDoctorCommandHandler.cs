using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Examino.Domain.Contracts;
using Examino.Domain.Entities;
using MediatR;

namespace Examino.Application.Functions.Users.Commands.CreateDoctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, CreateDoctorCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;
        public CreateDoctorCommandHandler(IMapper mapper, IDoctorRepository doctorRepository)
        {
            _mapper = mapper;
            _doctorRepository = doctorRepository;
        }

        public async Task<CreateDoctorCommandResponse> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = _mapper.Map<Doctor>(request);
            await _doctorRepository.Add(doctor, request.Password);
            
            return new CreateDoctorCommandResponse(201, true);
        }
    }
}
