using FluentValidation;
using ClinicSystem.DTOs.HealthTips.Requests;

namespace ClinicSystem.DTOs.HealthTips.Validators;

public class UpdateHealthTipRequestDtoValidator : AbstractValidator<UpdateHealthTipRequestDto>
{
    public UpdateHealthTipRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Title)
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters")
            .When(x => x.Title != null);

        RuleFor(x => x.Content)
            .MinimumLength(50).WithMessage("Content must be at least 50 characters")
            .When(x => x.Content != null);
    }
}