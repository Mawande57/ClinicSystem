namespace ClinicSystem.DTOs.Qualifications.Requests;

public record CreateQualificationRequestDto
{
    public Guid StaffId { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime? ExpirationDate { get; init; }
    public string Issuer { get; init; } = string.Empty;
}