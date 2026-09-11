namespace ClinicSystem.DTOs.Blog.Responses;

public record BlogPostBriefResponseDto
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public DateTime PublishedAt { get; init; }
    public string? ImagePath { get; init; }
}