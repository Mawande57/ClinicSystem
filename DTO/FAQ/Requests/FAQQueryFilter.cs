using ClinicSystem.DTOs.Common;

namespace ClinicSystem.DTOs.FAQ.Requests;

public class FAQQueryFilter : QueryFilter
{
    public string? Search { get; set; }
    public string? Category { get; set; }
}