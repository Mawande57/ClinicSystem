namespace ClinicSystem.DTOs.Qualifications.Requests;

public record UpdateQualificationRequestDto
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public DateTime? ExpirationDate { get; init; }
    public string? Issuer { get; init; }
}