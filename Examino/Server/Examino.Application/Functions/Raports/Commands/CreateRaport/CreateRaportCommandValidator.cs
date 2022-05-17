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
            RuleFor(r => r.Symptoms)
                .MaximumLength(255)
                .WithMessage("{PropertName} must not exceed 255 characters!");

            RuleFor(r => r.Examination)
                .MaximumLength(500)
                .WithMessage("{PropertName} must not exceed 500 characters!");

            RuleFor(r => r.Diagnosis)
                .MaximumLength(125)
                .WithMessage("{PropertName} must not exceed 125 characters!");

            RuleFor(r => r.Recommendation)
                .MaximumLength(125)
                .WithMessage("{PropertName} must not exceed 125 characters!");

            RuleFor(r => r.Comment)
                .MaximumLength(255)
                .WithMessage("{PropertName} must not exceed 255 characters!");
        }
    }
}
