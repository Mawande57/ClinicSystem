namespace ClinicSystem.DTOs.Staff.Requests;

public record UpdateStaffRequestDto
{
    public string? Specialization { get; init; }
    public string? Bio { get; init; }
    public bool? IsActive { get; init; }
}