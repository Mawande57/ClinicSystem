using ClinicSystem.DTO.WoundDetails.Requests;
using ClinicSystem.DTOs.WoundDetails.Requests;
using FluentValidation;

namespace ClinicSystem.DTOs.WoundDetails.Validators;

public class CreateWoundDetailRequestDtoValidator : AbstractValidator<CreateWoundDetailRequestDto>
{
    public CreateWoundDetailRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.AppointmentId)
            .NotEmpty().WithMessage("Appointment ID is required");

        RuleFor(x => x.CauseOfWound)
            .MaximumLength(500).WithMessage("Cause of wound cannot exceed 500 characters")
            .When(x => x.CauseOfWound != null);

        RuleFor(x => x.PreviousTreatment)
            .MaximumLength(500).WithMessage("Previous treatment cannot exceed 500 characters")
            .When(x => x.PreviousTreatment != null);

        RuleFor(x => x.WoundLocation)
            .MaximumLength(200).WithMessage("Wound location cannot exceed 200 characters")
            .When(x => x.WoundLocation != null);

        RuleFor(x => x.ProgressNotes)
            .MaximumLength(2000).WithMessage("Progress notes cannot exceed 2000 characters")
            .When(x => x.ProgressNotes != null);

        RuleFor(x => x.PainLevel)
            .InclusiveBetween(0, 10).WithMessage("Pain level must be between 0 and 10")
            .When(x => x.PainLevel.HasValue);

        RuleFor(x => x.PainDescription)
            .MaximumLength(500).WithMessage("Pain description cannot exceed 500 characters")
            .When(x => x.PainDescription != null);

        RuleFor(x => x.ExudateAmount)
            .MaximumLength(100).WithMessage("Exudate amount cannot exceed 100 characters")
            .When(x => x.ExudateAmount != null);

        RuleFor(x => x.DateOfOnset)
            .Must(date => !date.HasValue || date.Value <= DateTime.UtcNow)
            .WithMessage("Date of onset cannot be in the future")
            .When(x => x.DateOfOnset.HasValue);
    }
}