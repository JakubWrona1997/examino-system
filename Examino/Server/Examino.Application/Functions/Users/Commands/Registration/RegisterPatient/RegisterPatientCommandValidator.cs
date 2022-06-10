using Examino.Domain.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.Registration.RegisterPatient
{
    public class RegisterPatientCommandValidator : AbstractValidator<RegisterPatientCommand>
    {
        private readonly IValidationService _validationService;

        public RegisterPatientCommandValidator(IValidationService validationService)
        {
            _validationService = validationService;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email jest wymagany")
                .EmailAddress().WithMessage("Email musi mieć poprawny email")
                .Must(IsEmailUnique).WithMessage("Pacjent z tym emailem istnieje");


            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Imie jest wymagane")
                .Length(3, 50).WithMessage("Imie musi posiadać od 3 do 50 znaków")
                .Matches("^[A-ZĄĆĘŁŃÓŚŹŻ]").WithMessage("Imię musi zaczynać się z dużej litery")
                .Matches(@"^\S+$").WithMessage("Imię nie może zawierać przerw")
                .Matches(@"^.[a-ząćęłńóśźż\s]*$").WithMessage("Imię nie może zawierać dużych liter w środku");

            RuleFor(x => x.Surname)
              .NotEmpty().WithMessage("Nazwisko jest wymagane")
              .Length(3, 50).WithMessage("Nazwisko musi posiadać od 3 do 50 znaków")
              .Matches("^[A-ZĄĆĘŁŃÓŚŹŻ]").WithMessage("Nazwisko musi zaczynać się z dużej litery")
              .Matches(@"^\S+$").WithMessage("Nazwisko nie może zawierać przerw")
              .Matches(@"^.[a-ząćęłńóśźż\s]*$").WithMessage("Nazwisko nie może zawierać dużych liter w środku");
   
            RuleFor(x => x.PESEL)
                .NotEmpty().WithMessage("Pesel jest wymagany")
                .Length(11).WithMessage("Pesel mu sie mieć długość 11 znaków")
                .Matches("\\d{11}").WithMessage("Pesel musi mieć 11 liczb")
                .Must(IsPeselUnique).WithMessage("Juz taki pesel istnieje");


            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Hasło jest wymagane")
                .Length(6, 50).WithMessage("Hasło musi mieć od 6 do 50 znaków")
                .Matches("[A-ZĄĆĘŁŃÓŚŹŻ]").WithMessage("Hasło musi posiadać jedną dużą litere")
                .Matches("[a-ząćęłńóśźż]").WithMessage("Hasło musi posiadać jedną małą litere")
                .Matches("[0-9]").WithMessage("Hasło musi posiadać jedną liczbe")
                .Matches("(?=.*?[#?!@$%^&*-])").WithMessage("Hasło musi mieć jeden znak specjalny");
             
        }

        private bool IsEmailUnique(string email)
        {
            var check = _validationService.
                IsEmailAlreadyExist(email).Result;
            return !check;
        }
        private bool IsPeselUnique(string pesel)
        {
            var check = _validationService.
                IsPeselAlreadyExist(pesel).Result;
            return !check;
        }
    }
}
