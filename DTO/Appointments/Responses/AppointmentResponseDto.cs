namespace ClinicSystem.DTOs.Appointments.Responses;

public record AppointmentResponseDto
{
    public Guid Id { get; init; }
    public Guid PatientId { get; init; }
    public string PatientName { get; init; } = string.Empty;
    public Guid StaffId { get; init; }
    public string StaffName { get; init; } = string.Empty;
    public string StaffSpecialization { get; init; } = string.Empty;
    public Guid ServiceId { get; init; }
    public string ServiceName { get; init; } = string.Empty;
    public DateTime AppointmentDate { get; init; }
    public TimeSpan AppointmentTime { get; init; }
    public string Status { get; init; } = string.Empty;
    public string? Notes { get; init; }
    public DateTime CreatedAt { get; init; }
    public bool IsFollowUp { get; init; }
    public Guid? ParentId { get; init; }
    public bool WoundDetailsAdded { get; init; }
}