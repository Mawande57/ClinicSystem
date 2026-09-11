namespace ClinicSystem.DTOs.Blog.Requests;

public record CreateBlogPostRequestDto
{
    public string Title { get; init; } = string.Empty;
    public string Content { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public string? ImagePath { get; init; }
    public DateTime PublishedAt { get; init; }
}