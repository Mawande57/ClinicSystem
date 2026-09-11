using FluentValidation;
using ClinicSystem.DTOs.FAQ.Requests;

namespace ClinicSystem.DTOs.FAQ.Validators;

public class UpdateFAQRequestDtoValidator : AbstractValidator<UpdateFAQRequestDto>
{
    public UpdateFAQRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Question)
            .MaximumLength(500).WithMessage("Question cannot exceed 500 characters")
            .When(x => x.Question != null);

        RuleFor(x => x.Category)
            .MaximumLength(100).WithMessage("Category cannot exceed 100 characters")
            .When(x => x.Category != null);

        RuleFor(x => x.DisplayOrder)
            .GreaterThanOrEqualTo(0).WithMessage("Display order cannot be negative")
            .When(x => x.DisplayOrder.HasValue);
    }
}