using AutoMapper;
using Examino.Application.Functions.Prescriptions.Events.CreatePrescritpion;
using Examino.Domain.Contracts;
using Examino.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Raports.Commands.CreateRaport
{
    public class CreateRaportCommandHandler : IRequestHandler<CreateRaportCommand, CreateRaportCommandResponse>
    {
        private readonly IRaportRepository _raportRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateRaportCommandHandler(IRaportRepository raportRepository, IMapper mapper, IMediator mediator)
        {
            _raportRepository = raportRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CreateRaportCommandResponse> Handle(CreateRaportCommand command, CancellationToken cancellationToken)
        {            
            var raport = _mapper.Map<Raport>(command.Request);

            var raportId = await _raportRepository.CreateRaport(raport);

            if (raportId == Guid.Empty)
                return new CreateRaportCommandResponse(404, false);

            if (command.Request.Prescription != null)
                await _mediator.Publish(new CreatePrescritpionEvent(raportId, command.Request.Prescription.Medicines));                
           

            return new CreateRaportCommandResponse(raportId);
        }
    }
}
