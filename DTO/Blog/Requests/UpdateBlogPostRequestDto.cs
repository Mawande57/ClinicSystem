namespace ClinicSystem.DTOs.Blog.Requests;

public record UpdateBlogPostRequestDto
{
    public string? Title { get; init; }
    public string? Content { get; init; }
    public string? Category { get; init; }
    public string? ImagePath { get; init; }
    public DateTime? PublishedAt { get; init; }
}