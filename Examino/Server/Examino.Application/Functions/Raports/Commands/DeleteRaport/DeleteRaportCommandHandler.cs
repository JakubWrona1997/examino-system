using AutoMapper;
using Examino.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Raports.Commands.DeleteRaport
{
    public class DeleteRaportCommandHandler : IRequestHandler<DeleteRaportCommand>
    {
        private readonly IRaportRepository _raportRepository;

        public DeleteRaportCommandHandler(IRaportRepository raportRepository)
        {
            _raportRepository = raportRepository;
        }

        public async Task<Unit> Handle(DeleteRaportCommand request, CancellationToken cancellationToken)
        {
            var raportToDelete = await _raportRepository.GetById(request.RaportId);

            await _raportRepository.DeleteRaport(raportToDelete);

            return Unit.Value;
        }
    }
}
