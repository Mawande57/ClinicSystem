using FluentValidation;
using ClinicSystem.DTOs.Medications.Requests;

namespace ClinicSystem.DTOs.Medications.Validators;

public class CreateMedicationRequestDtoValidator : AbstractValidator<CreateMedicationRequestDto>
{
    public CreateMedicationRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.PatientId)
            .NotEmpty().WithMessage("Patient ID is required");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Medication name is required")
            .MaximumLength(200).WithMessage("Medication name cannot exceed 200 characters");

        RuleFor(x => x.Dosage)
            .NotEmpty().WithMessage("Dosage is required")
            .MaximumLength(100).WithMessage("Dosage cannot exceed 100 characters");

        RuleFor(x => x.Frequency)
            .NotEmpty().WithMessage("Frequency is required")
            .MaximumLength(100).WithMessage("Frequency cannot exceed 100 characters");

        RuleFor(x => x.Purpose)
            .MaximumLength(500).WithMessage("Purpose cannot exceed 500 characters")
            .When(x => x.Purpose != null);

        RuleFor(x => x.Instructions)
            .NotEmpty().WithMessage("Instructions are required");

        RuleFor(x => x.PrescribingDoctor)
            .MaximumLength(200).WithMessage("Prescribing doctor name cannot exceed 200 characters")
            .When(x => x.PrescribingDoctor != null);

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start date is required");
    }
}