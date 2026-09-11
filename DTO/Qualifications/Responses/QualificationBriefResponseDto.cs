namespace ClinicSystem.DTOs.Qualifications.Responses;

public record QualificationBriefResponseDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Issuer { get; init; } = string.Empty;
    public DateTime? ExpirationDate { get; init; }
}