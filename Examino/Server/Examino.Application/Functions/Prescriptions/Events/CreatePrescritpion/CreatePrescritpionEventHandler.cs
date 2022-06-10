using AutoMapper;
using Examino.Domain.Contracts;
using Examino.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace Examino.Application.Functions.Prescriptions.Events.CreatePrescritpion
{
    public class CreatePrescritpionEventHandler : INotificationHandler<CreatePrescritpionEvent>
    {
        private readonly IMapper _mapper;
        private readonly IRaportRepository _raportRepository;

        public CreatePrescritpionEventHandler(IMapper mapper, IRaportRepository raportRepository)
        {
            _mapper = mapper;
            _raportRepository = raportRepository;
        }

        public async Task Handle(CreatePrescritpionEvent notification, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<CreatePrescritpionEvent,Prescription>(notification);

            await _raportRepository.CreatePrescription(result);
        }
    }
}
