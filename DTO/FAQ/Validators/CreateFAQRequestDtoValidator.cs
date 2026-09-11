using FluentValidation;
using ClinicSystem.DTOs.FAQ.Requests;

namespace ClinicSystem.DTOs.FAQ.Validators;

public class CreateFAQRequestDtoValidator : AbstractValidator<CreateFAQRequestDto>
{
    public CreateFAQRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Question)
            .NotEmpty().WithMessage("Question is required")
            .MaximumLength(500).WithMessage("Question cannot exceed 500 characters");

        RuleFor(x => x.Answer)
            .NotEmpty().WithMessage("Answer is required");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required")
            .MaximumLength(100).WithMessage("Category cannot exceed 100 characters");

        RuleFor(x => x.DisplayOrder)
            .GreaterThanOrEqualTo(0).WithMessage("Display order cannot be negative");
    }
}