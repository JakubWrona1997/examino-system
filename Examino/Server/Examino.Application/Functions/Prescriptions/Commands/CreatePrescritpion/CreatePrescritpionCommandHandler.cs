using AutoMapper;
using Examino.Domain.Contracts;
using Examino.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Prescriptions.Command.CreatePrescritpion
{
    public class CreatePrescritpionCommandHandler : IRequestHandler<CreatePrescritpionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRaportRepository _raportRepository;

        public CreatePrescritpionCommandHandler(IMapper mapper, IRaportRepository raportRepository)
        {
            _mapper = mapper;
            _raportRepository = raportRepository;
        }

        public async Task<Unit> Handle(CreatePrescritpionCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Prescription>(request);

            await _raportRepository.CreatePrescription(result);

            return Unit.Value;
        }
    }
}
