﻿using Examino.API.Functions.Registration.PatientRegistration.Command;
using MediatR;

namespace Examino.API.Functions.Registration.PatientRegistration
{
    public class CreatePatientCommand : IRequest<CreatePatientCommandResponse>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
    }
}
