using FluentValidation;
using ClinicSystem.DTOs.Appointments.Requests;

namespace ClinicSystem.DTOs.Appointments.Validators;

public class UpdateAppointmentRequestDtoValidator : AbstractValidator<UpdateAppointmentRequestDto>
{
    public UpdateAppointmentRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.AppointmentDate)
            .Must(date => !date.HasValue || date.Value >= DateTime.UtcNow.Date)
            .WithMessage("Appointment date cannot be in the past")
            .When(x => x.AppointmentDate.HasValue);

        RuleFor(x => x.Notes)
            .MaximumLength(1000).WithMessage("Notes cannot exceed 1000 characters")
            .When(x => x.Notes != null);

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid appointment status")
            .When(x => x.Status.HasValue);
    }
}