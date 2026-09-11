using ClinicSystem.DTOs.Common;

namespace ClinicSystem.DTOs.HealthTips.Requests;

public class HealthTipQueryFilter : QueryFilter
{
    public string? Search { get; set; }
    public bool? IsActive { get; set; }
}