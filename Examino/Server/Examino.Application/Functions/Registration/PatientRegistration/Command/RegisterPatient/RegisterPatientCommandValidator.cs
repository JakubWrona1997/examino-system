using Examino.Domain.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Registration.PatientRegistration.Command.RegisterPatient
{
   public  class RegisterPatientCommandValidator : AbstractValidator<RegisterPatientCommand>
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
                .NotEmpty()
                .Length(3,50)
                .Matches("^[A-Z]").WithMessage("Name needs to start with uppercase letter");//add remnant rules from frontend

            RuleFor(x => x.Surname)
              .NotEmpty()
              .Length(3, 50)
              .Matches("^[A-Z]").WithMessage("Surname needs to start with uppercase letter"); //add remnant rules from frontend

            RuleFor(x => x.PESEL)
                .NotEmpty()
                .Length(11)
                .Matches("\\d{11}").WithMessage("Pesel need to have 11 digits")
                .Must(IsPeselUnique).WithMessage("Patient with that PESEL exist");
                

            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches("[A-Z]").WithMessage("Password need one Uppercase letter")
                .Matches("[a-z]").WithMessage("Password need one lowercase letter")
                .Matches("[0-9]").WithMessage("Password need one number")
                .Matches("(?=.*?[#?!@$%^&*-])").WithMessage("Password need at least one special character");
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
