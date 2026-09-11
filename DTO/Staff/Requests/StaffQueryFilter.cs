using ClinicSystem.DTOs.Common;

namespace ClinicSystem.DTOs.Staff.Requests;

public class StaffQueryFilter : QueryFilter
{
    public string? Search { get; set; }
    public string? Specialization { get; set; }
    public bool? IsActive { get; set; }
}