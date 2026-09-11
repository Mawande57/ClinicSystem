namespace ClinicSystem.DTOs.Appointments.Requests;

public record CancelAppointmentRequestDto
{
    public string? CancellationReason { get; init; }
}