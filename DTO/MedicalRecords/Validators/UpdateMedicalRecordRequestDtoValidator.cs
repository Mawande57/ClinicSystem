using FluentValidation;
using ClinicSystem.DTOs.MedicalRecords.Requests;

namespace ClinicSystem.DTOs.MedicalRecords.Validators;

public class UpdateMedicalRecordRequestDtoValidator : AbstractValidator<UpdateMedicalRecordRequestDto>
{
    public UpdateMedicalRecordRequestDtoValidator()
    {
       ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters")
            .When(x => x.Description != null);

        RuleFor(x => x.FilePath)
            .MaximumLength(500).WithMessage("File path cannot exceed 500 characters")
            .When(x => x.FilePath != null);

        RuleFor(x => x.RecordDate)
            .Must(date => !date.HasValue || date.Value <= DateTime.UtcNow)
            .WithMessage("Record date cannot be in the future")
            .When(x => x.RecordDate.HasValue);
    }
}