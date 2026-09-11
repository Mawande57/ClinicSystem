using FluentValidation;
using ClinicSystem.DTOs.Medications.Requests;

namespace ClinicSystem.DTOs.Medications.Validators;

public class UpdateMedicationRequestDtoValidator : AbstractValidator<UpdateMedicationRequestDto>
{
    public UpdateMedicationRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Name)
            .MaximumLength(200).WithMessage("Medication name cannot exceed 200 characters")
            .When(x => x.Name != null);

        RuleFor(x => x.Dosage)
            .MaximumLength(100).WithMessage("Dosage cannot exceed 100 characters")
            .When(x => x.Dosage != null);

        RuleFor(x => x.Frequency)
            .MaximumLength(100).WithMessage("Frequency cannot exceed 100 characters")
            .When(x => x.Frequency != null);

        RuleFor(x => x.Purpose)
            .MaximumLength(500).WithMessage("Purpose cannot exceed 500 characters")
            .When(x => x.Purpose != null);

        RuleFor(x => x.PrescribingDoctor)
            .MaximumLength(200).WithMessage("Prescribing doctor name cannot exceed 200 characters")
            .When(x => x.PrescribingDoctor != null);
    }
}