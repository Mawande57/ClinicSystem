using ClinicSystem.DTOs.Common;

namespace ClinicSystem.DTOs.Blog.Requests;

public class BlogPostQueryFilter : QueryFilter
{
    public string? Search { get; set; }
    public string? Category { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}