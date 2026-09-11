namespace ClinicSystem.DTOs.Blog.Responses;

public record BlogPostResponseDto
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Content { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public string? ImagePath { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime PublishedAt { get; init; }
}