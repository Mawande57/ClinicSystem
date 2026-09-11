using FluentValidation;
using ClinicSystem.DTOs.Staff.Requests;

namespace ClinicSystem.DTOs.Staff.Validators;

public class UpdateStaffRequestDtoValidator : AbstractValidator<UpdateStaffRequestDto>
{
    public UpdateStaffRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Specialization)
            .MaximumLength(200).WithMessage("Specialization cannot exceed 200 characters")
            .When(x => x.Specialization != null);

        RuleFor(x => x.Bio)
            .MaximumLength(2000).WithMessage("Bio cannot exceed 2000 characters")
            .When(x => x.Bio != null);
    }
}