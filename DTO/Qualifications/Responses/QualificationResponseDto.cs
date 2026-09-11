namespace ClinicSystem.DTOs.Qualifications.Responses;

public record QualificationResponseDto
{
    public Guid Id { get; init; }
    public Guid StaffId { get; init; }
    public string StaffName { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime? ExpirationDate { get; init; }
    public string Issuer { get; init; } = string.Empty;
    public bool IsExpired => ExpirationDate.HasValue && ExpirationDate.Value <= DateTime.UtcNow;
}