using FluentValidation;
using ClinicSystem.DTOs.Patients.Requests;

namespace ClinicSystem.DTOs.Patients.Validators;

public class CreatePatientRequestDtoValidator : AbstractValidator<CreatePatientRequestDto>
{
    public CreatePatientRequestDtoValidator()
    {
        
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required");

        RuleFor(x => x.Gender)
            .MaximumLength(20).WithMessage("Gender cannot exceed 20 characters")
            .Must(g => string.IsNullOrEmpty(g) || new[] { "Male", "Female", "Other", "Prefer not to say" }.Contains(g))
            .WithMessage("Gender must be one of: Male, Female, Other, Prefer not to say");

        RuleFor(x => x.Address)
            .MaximumLength(500).WithMessage("Address cannot exceed 500 characters");

        RuleFor(x => x.EmergencyContact)
            .MaximumLength(200).WithMessage("Emergency contact cannot exceed 200 characters");

        RuleFor(x => x.InsuranceInfo)
            .MaximumLength(500).WithMessage("Insurance info cannot exceed 500 characters");

        RuleFor(x => x.DateOfBirth)
            .Must(dob => !dob.HasValue || dob.Value <= DateTime.UtcNow)
            .WithMessage("Date of birth cannot be in the future");
    }
}