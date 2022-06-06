﻿using AutoMapper;
using Examino.Domain.Contracts;
using Examino.Domain.DTOs.UserDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.UpdateDoctorDetails
{
    public class UpdateDoctorDetailsCommandHandler : IRequestHandler<UpdateDoctorDetailsCommand>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;

        public UpdateDoctorDetailsCommandHandler(IMapper mapper, IDoctorRepository doctorRepository)
        {
            _mapper = mapper;
            _doctorRepository = doctorRepository;
        }
        public async Task<Unit> Handle(UpdateDoctorDetailsCommand request, CancellationToken cancellationToken)
        {
            var doctorDetails = _mapper.Map<UpdateDoctorDetailsDto>(request);
            await _doctorRepository.UpdateDetails(doctorDetails);

            return Unit.Value;
        }
    }
}
