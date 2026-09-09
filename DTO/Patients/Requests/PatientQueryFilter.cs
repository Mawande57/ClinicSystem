using ClinicSystem.DTOs.Common;

namespace ClinicSystem.DTOs.Patients.Requests;

public class PatientQueryFilter : QueryFilter
{
    public string? Search { get; set; }
    public string? Gender { get; set; }
    public bool? IsActive { get; set; }
}