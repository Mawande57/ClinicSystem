namespace ClinicSystem.DTO.Staff.Requests;

public record CreateStaffRequestDto
{
    public Guid UserId { get; init; }
    public string Specialization { get; init; } = string.Empty;
    public string Bio { get; init; } = string.Empty;
}