using AutoMapper;
using Examino.Domain.Contracts;
using Examino.Domain.DTOs;
using Examino.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.UpdateUserDetails
{
    public class UpdateUserDetailsCommandHandler : IRequestHandler<UpdateUserDetailsCommand>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;

        public UpdateUserDetailsCommandHandler(IMapper mapper, IPatientRepository patientRepository)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
        }
        public async Task<Unit> Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var userDetails = _mapper.Map<UpdateUserDetailsDto>(request);

            await _patientRepository.UpdateDetails(userDetails);

            return Unit.Value;
        }
    }
}
