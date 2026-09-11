using FluentValidation;
using ClinicSystem.DTOs.MedicalRecords.Requests;

namespace ClinicSystem.DTOs.MedicalRecords.Validators;

public class CreateMedicalRecordRequestDtoValidator : AbstractValidator<CreateMedicalRecordRequestDto>
{
    public CreateMedicalRecordRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.PatientId)
            .NotEmpty().WithMessage("Patient ID is required");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

        RuleFor(x => x.FilePath)
            .MaximumLength(500).WithMessage("File path cannot exceed 500 characters")
            .When(x => x.FilePath != null);

        RuleFor(x => x.RecordDate)
            .NotEmpty().WithMessage("Record date is required")
            .Must(date => date <= DateTime.UtcNow)
            .WithMessage("Record date cannot be in the future");
    }
}