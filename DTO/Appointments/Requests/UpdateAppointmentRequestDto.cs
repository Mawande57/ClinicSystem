using ClinicSystem.Models.Entities;

namespace ClinicSystem.DTOs.Appointments.Requests;

public record UpdateAppointmentRequestDto
{
    public DateTime? AppointmentDate { get; init; }
    public TimeSpan? AppointmentTime { get; init; }
    public string? Notes { get; init; }
    public AppointmentStatus? Status { get; init; }
}