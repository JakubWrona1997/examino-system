using AutoMapper;
using Examino.Application.Functions.Prescriptions.Events.CreatePrescritpion;
using Examino.Domain.Contracts;
using Examino.Domain.Entities;
using Hangfire;
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
        private readonly IHangFireService _hangFireService;

        public CreateRaportCommandHandler(IRaportRepository raportRepository, IMapper mapper, IMediator mediator, IHangFireService hangFireService)
        {
            _raportRepository = raportRepository;
            _mapper = mapper;
            _mediator = mediator;
            _hangFireService = hangFireService;
        }

        public async Task<CreateRaportCommandResponse> Handle(CreateRaportCommand command, CancellationToken cancellationToken)
        {            
            var raport = _mapper.Map<Raport>(command.Request);

            var raportId = await _raportRepository.CreateRaport(raport);

            if (raportId == Guid.Empty)
                return new CreateRaportCommandResponse(404, false);

            if (command.Request.Prescription != null)
                await _mediator.Publish(new CreatePrescritpionEvent(raportId, command.Request.Prescription.Medicines), cancellationToken);                
           
            if(_raportRepository.IsCreateCompleted() == true)
            {
                string receiver = raport.PatientId.ToString();
                string sender = raport.DoctorId.ToString();
                string raportIdentifier = raportId.ToString();

                BackgroundJob.Enqueue(() => _hangFireService.RunMessageTask(receiver, sender, raportIdentifier));
            }

            return new CreateRaportCommandResponse(raportId);
        }
    }
}
