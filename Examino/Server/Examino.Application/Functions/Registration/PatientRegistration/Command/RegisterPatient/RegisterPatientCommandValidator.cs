using Examino.Domain.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Registration.PatientRegistration.Command.RegisterPatient
{
   public  class RegisterPatientCommandValidator:AbstractValidator<RegisterPatientCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public RegisterPatientCommandValidator(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(IsEmailUnique).WithMessage("Patient with that email exist");
                

            RuleFor(x => x.Name)
                .NotEmpty();//add remnant rules from frontend

            RuleFor(x => x.Surname)
              .NotEmpty();//add remnant rules from frontend

            RuleFor(x => x.PESEL)
                .NotEmpty()
                .Length(11)
                .Must(IsPeselUnique).WithMessage("Patient with that PESEL exist"); ;

   
         


        }

        private bool IsEmailUnique(string email)
        {
            var check =  _patientRepository.
                IsEmailAlreadyExist(email).Result;
            return !check;
        }
        private bool IsPeselUnique(string pesel)
        {
            var check = _patientRepository.
                IsPeselAlreadyExist(pesel).Result;
            return !check;
        }
    }
}
