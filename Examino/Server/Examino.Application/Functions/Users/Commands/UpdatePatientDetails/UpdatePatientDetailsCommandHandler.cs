using AutoMapper;
using Examino.Domain.Contracts;
using Examino.Domain.DTOs.UserDTOs;
using Examino.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.UpdatePatientDetails
{
    public class UpdatePatientDetailsCommandHandler : IRequestHandler<UpdatePatientDetailsCommand>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;

        public UpdatePatientDetailsCommandHandler(IMapper mapper, IPatientRepository patientRepository)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
        }
        public async Task<Unit> Handle(UpdatePatientDetailsCommand request, CancellationToken cancellationToken)
        {
            var userDetails = _mapper.Map<UpdatePatientDetailsDto>(request);

            await _patientRepository.UpdateDetails(userDetails);

            return Unit.Value;
        }
    }
}
