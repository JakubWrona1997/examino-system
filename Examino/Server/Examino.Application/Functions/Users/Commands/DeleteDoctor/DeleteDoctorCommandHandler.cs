using Examino.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.DeleteDoctor
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, Guid>
    {
        private readonly IDoctorRepository _doctorRepository;

        public DeleteDoctorCommandHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task<Guid> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctorToDelete =  await _doctorRepository.GetDoctorById(request.DoctorId);

            await _doctorRepository.DeleteDoctor(doctorToDelete);

            return doctorToDelete.Id;
        }
    }
}
