namespace ClinicSystem.DTOs.FAQ.Requests;

public record CreateFAQRequestDto
{
    public string Question { get; init; } = string.Empty;
    public string Answer { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public int DisplayOrder { get; init; }
}