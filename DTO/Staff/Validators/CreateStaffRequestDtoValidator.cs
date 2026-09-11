using ClinicSystem.DTO.Staff.Requests;
using ClinicSystem.DTOs.Staff.Requests;
using FluentValidation;

namespace ClinicSystem.DTOs.Staff.Validators;

public class CreateStaffRequestDtoValidator : AbstractValidator<CreateStaffRequestDto>
{
    public CreateStaffRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required");

        RuleFor(x => x.Specialization)
            .NotEmpty().WithMessage("Specialization is required")
            .MaximumLength(200).WithMessage("Specialization cannot exceed 200 characters");

        RuleFor(x => x.Bio)
            .NotEmpty().WithMessage("Bio is required")
            .MaximumLength(2000).WithMessage("Bio cannot exceed 2000 characters");
    }
}