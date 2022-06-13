using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.UpdatePatientDetails
{
    public class UpdatePatientDetailsCommandValidator : AbstractValidator<UpdatePatientDetailsCommand>
    {
        public UpdatePatientDetailsCommandValidator()
        {
            RuleFor(u => u.Request).SetValidator(new UpdatePatientDetailsRequestValidator());
        }
    }
}
