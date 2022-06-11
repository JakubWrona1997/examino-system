using Examino.Domain.Requests.Doctors.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.UpdateDoctorDetails
{
    public class UpdateDoctorDetailsRequestValidator : AbstractValidator<UpdateDoctorDetailsRequest>
    {
        public UpdateDoctorDetailsRequestValidator()
        {
            RuleFor(u => u.Address)
                .MaximumLength(100);

            RuleFor(u => u.City)
                .MaximumLength(50);

            RuleFor(u => u.PostalCode)
                .Matches("^[0-9]{2}-[0-9]{3}$").WithMessage("Kod pocztowy powinien być w formacie XX-XXX");

            RuleFor(u => u.PhoneNumber)
                .Matches(@"/\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/").WithMessage("Niepoprawny format");

            RuleFor(u => u.Qualification)
                .MaximumLength(100);

            RuleFor(u => u.Specialization)
                .MaximumLength(100);
        }
    }
}
