namespace ClinicSystem.DTOs.Staff.Responses;

public record StaffBriefResponseDto
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string Specialization { get; init; } = string.Empty;
    public bool IsActive { get; init; }
}