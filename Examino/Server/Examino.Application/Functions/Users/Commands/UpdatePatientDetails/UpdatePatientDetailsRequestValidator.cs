using Examino.Domain.Requests.Patients.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.UpdatePatientDetails
{
    public class UpdatePatientDetailsRequestValidator : AbstractValidator<UpdatePatientDetailsRequest>
    {
        public UpdatePatientDetailsRequestValidator()
        {
            RuleFor(x => x.Address)
                .MaximumLength(100);

            RuleFor(x => x.City)
                .MaximumLength(50);

            RuleFor(x => x.PostalCode)
                .Matches("^[0-9]{2}-[0-9]{3}$").WithMessage("Kod pocztowy powinien być w formacie XX-XXX");

            RuleFor(x => x.Height)
                .LessThan(250)
                .GreaterThan(0);

            RuleFor(x => x.Weight)
                .LessThan(400)
                .GreaterThan(0);

            RuleFor(x => x.BloodType)
                .MaximumLength(10);

            RuleFor(x => x.PhoneNumber)
                .Matches(@"/\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/").WithMessage("Niepoprawny format");
        }
    }
}