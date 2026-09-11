namespace ClinicSystem.DTOs.Appointments.Requests;

public record CreateAppointmentRequestDto
{
    public Guid PatientId { get; init; }
    public Guid StaffId { get; init; }
    public Guid ServiceId { get; init; }
    public DateTime AppointmentDate { get; init; }
    public TimeSpan AppointmentTime { get; init; }
    public string? Notes { get; init; }
    public bool IsFollowUp { get; init; }
    public Guid? ParentId { get; init; }
}