namespace ClinicSystem.DTOs.Staff.Responses;

public record StaffResponseDto
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
    public string Specialization { get; init; } = string.Empty;
    public string Bio { get; init; } = string.Empty;
    public bool IsActive { get; init; }
    public int TotalAppointments { get; init; }
    public int TotalQualifications { get; init; }
}