using ClinicSystem.DTOs.Common;

namespace ClinicSystem.DTOs.Qualifications.Requests;

public class QualificationQueryFilter : QueryFilter
{
    public string? Search { get; set; }
    public Guid? StaffId { get; set; }
    public bool? IsExpired { get; set; }
}