using FluentValidation;
using ClinicSystem.DTOs.HealthTips.Requests;

namespace ClinicSystem.DTOs.HealthTips.Validators;

public class CreateHealthTipRequestDtoValidator : AbstractValidator<CreateHealthTipRequestDto>
{
    public CreateHealthTipRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required")
            .MinimumLength(50).WithMessage("Content must be at least 50 characters");
    }
}