using Examino.Domain.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Raports.Commands.CreateRaport
{
    public class CreateRaportCommandValidator : AbstractValidator<CreateRaportCommand>
    {
        public CreateRaportCommandValidator()
        {
            RuleFor(r => r.Request.Symptoms)
                .MaximumLength(255)
                .WithMessage("{PropertName} must not exceed 255 characters!");

            RuleFor(r => r.Request.Examination)
                .MaximumLength(500)
                .WithMessage("{PropertName} must not exceed 500 characters!");

            RuleFor(r => r.Request.Diagnosis)
                .MaximumLength(125)
                .WithMessage("{PropertName} must not exceed 125 characters!");

            RuleFor(r => r.Request.Recommendation)
                .MaximumLength(125)
                .WithMessage("{PropertName} must not exceed 125 characters!");

            RuleFor(r => r.Request.Comment)
                .MaximumLength(255)
                .WithMessage("{PropertName} must not exceed 255 characters!");
        }
    }
}
