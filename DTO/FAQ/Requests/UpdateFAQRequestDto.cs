namespace ClinicSystem.DTOs.FAQ.Requests;

public record UpdateFAQRequestDto
{
    public string? Question { get; init; }
    public string? Answer { get; init; }
    public string? Category { get; init; }
    public int? DisplayOrder { get; init; }
}