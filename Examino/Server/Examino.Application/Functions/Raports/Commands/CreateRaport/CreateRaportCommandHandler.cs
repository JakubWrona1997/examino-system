using AutoMapper;
using Examino.Domain.Contracts;
using Examino.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Raports.Commands.CreateRaport
{
    public class CreateRaportCommandHandler : IRequestHandler<CreateRaportCommand, CreateRaportCommandResponse>
    {
        private readonly IRaportRepository _raportRepository;
        private readonly IMapper _mapper;

        public CreateRaportCommandHandler(IRaportRepository raportRepository, IMapper mapper)
        {
            _raportRepository = raportRepository;
            _mapper = mapper;
        }

        public async Task<CreateRaportCommandResponse> Handle(CreateRaportCommand request, CancellationToken cancellationToken)
        {
            var raport = _mapper.Map<Raport>(request);

            var raportId = await _raportRepository.CreateRaport(raport);

            return new CreateRaportCommandResponse(raportId);
        }
    }
}
