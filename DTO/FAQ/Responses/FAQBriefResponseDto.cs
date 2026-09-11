namespace ClinicSystem.DTOs.FAQ.Responses;

public record FAQBriefResponseDto
{
    public Guid Id { get; init; }
    public string Question { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
}