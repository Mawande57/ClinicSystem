using ClinicSystem.DTOs.Common;

namespace ClinicSystem.DTOs.Medications.Requests;

public class MedicationQueryFilter : QueryFilter
{
    public string? Search { get; set; }
    public Guid? PatientId { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}