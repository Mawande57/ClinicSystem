using FluentValidation;
using ClinicSystem.DTOs.Qualifications.Requests;

namespace ClinicSystem.DTOs.Qualifications.Validators;

public class CreateQualificationRequestDtoValidator : AbstractValidator<CreateQualificationRequestDto>
{
    public CreateQualificationRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.StaffId)
            .NotEmpty().WithMessage("Staff ID is required");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Qualification name is required")
            .MaximumLength(200).WithMessage("Qualification name cannot exceed 200 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters");

        RuleFor(x => x.Issuer)
            .NotEmpty().WithMessage("Issuer is required")
            .MaximumLength(200).WithMessage("Issuer cannot exceed 200 characters");
    }
}