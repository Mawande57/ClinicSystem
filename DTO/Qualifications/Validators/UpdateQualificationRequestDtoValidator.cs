using FluentValidation;
using ClinicSystem.DTOs.Qualifications.Requests;

namespace ClinicSystem.DTOs.Qualifications.Validators;

public class UpdateQualificationRequestDtoValidator : AbstractValidator<UpdateQualificationRequestDto>
{
    public UpdateQualificationRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Name)
            .MaximumLength(200).WithMessage("Qualification name cannot exceed 200 characters")
            .When(x => x.Name != null);

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters")
            .When(x => x.Description != null);

        RuleFor(x => x.Issuer)
            .MaximumLength(200).WithMessage("Issuer cannot exceed 200 characters")
            .When(x => x.Issuer != null);
    }
}