using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Registration.PatientRegistration.Command.RegisterPatient
{
   public  class RegisterPatientCommandValidator:AbstractValidator<RegisterPatientCommand>
    {
        public RegisterPatientCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Custom((value,context) =>
                {
                    var emilInUse = dbContext.Users.Any(x => x.Email == value);
                    if (emilInUse)
                    {
                        context.AddFailure("Email", "that email is taken");
                    }
                });

            RuleFor(x => x.Name)
                .NotEmpty();//add remnant rules from frontend

            RuleFor(x => x.Surname)
              .NotEmpty();//add remnant rules from frontend

            RuleFor(x=>x.PESEL)
                .NotEmpty()
                .Length(11)
                .Custom((value, context) =>
                {
                    var peselInUse = dbContext.Users.Any(x => x.PESEL == value);
                    if (peselInUse)
                    {
                        context.AddFailure("PESEL", "that PESEL is taken");
                    }
                });
                //add cant be a number

        }
    }
}
