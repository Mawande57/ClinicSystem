namespace ClinicSystem.DTOs.Appointments.Responses;

public record AppointmentBriefResponseDto
{
    public Guid Id { get; init; }
    public DateTime AppointmentDate { get; init; }
    public TimeSpan AppointmentTime { get; init; }
    public string Status { get; init; } = string.Empty;
    public string PatientName { get; init; } = string.Empty;
    public string StaffName { get; init; } = string.Empty;
    public string ServiceName { get; init; } = string.Empty;
}