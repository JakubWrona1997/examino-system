using Examino.Domain.Requests.Doctors.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.UpdateDoctorDetails
{
    public class UpdateDoctorDetailsCommandValidator : AbstractValidator<UpdateDoctorDetailsCommand>
    {
        public UpdateDoctorDetailsCommandValidator()
        {
            RuleFor(x => x.Request).SetValidator(new UpdateDoctorDetailsRequestValidator());
        }
    }
}
