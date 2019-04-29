﻿using FluentValidation;
using HRAssistant.Admin.Contracts.JobPositionContracts;

namespace HRAssistant.Admin.UseCases.Validators
{
    public sealed class JobPositionValidator : AbstractValidator<JobPosition>
    {
        public JobPositionValidator()
        {
            RuleFor(p => p.Title).NotNull().NotEmpty();
            RuleFor(p => p.Template).NotNull()
                .DependentRules(() =>
                {
                    RuleFor(t => t.Template.Description).NotNull();
                    RuleForEach(t => t.Template.Questions)
                        .Must(q => !string.IsNullOrEmpty(q.Title)).WithMessage("Question Title can't be null or empty.")
                        .Must(q => q.OrderIndex.HasValue).WithMessage("Question must be has order index.");
                });
        }
    }
}
