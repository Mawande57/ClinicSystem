namespace ClinicSystem.DTOs.FAQ.Responses;

public record FAQResponseDto
{
    public Guid Id { get; init; }
    public string Question { get; init; } = string.Empty;
    public string Answer { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public int DisplayOrder { get; init; }
}