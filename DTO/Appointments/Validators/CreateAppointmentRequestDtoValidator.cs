using FluentValidation;
using ClinicSystem.DTOs.Appointments.Requests;

namespace ClinicSystem.DTOs.Appointments.Validators;

public class CreateAppointmentRequestDtoValidator : AbstractValidator<CreateAppointmentRequestDto>
{
    public CreateAppointmentRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.PatientId)
            .NotEmpty().WithMessage("Patient ID is required");

        RuleFor(x => x.StaffId)
            .NotEmpty().WithMessage("Staff ID is required");

        RuleFor(x => x.ServiceId)
            .NotEmpty().WithMessage("Service ID is required");

        RuleFor(x => x.AppointmentDate)
            .NotEmpty().WithMessage("Appointment date is required")
            .Must(date => date >= DateTime.UtcNow.Date)
            .WithMessage("Appointment date cannot be in the past");

        RuleFor(x => x.Notes)
            .MaximumLength(1000).WithMessage("Notes cannot exceed 1000 characters");

        RuleFor(x => x.ParentId)
            .Must((dto, parentId) => !parentId.HasValue || parentId.Value != dto.PatientId)
            .WithMessage("Parent appointment cannot reference this appointment");
    }
}