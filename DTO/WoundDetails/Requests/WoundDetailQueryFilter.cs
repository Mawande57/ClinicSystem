using ClinicSystem.DTOs.Common;

namespace ClinicSystem.DTOs.WoundDetails.Requests;

public class WoundDetailQueryFilter : QueryFilter
{
    public string? Search { get; set; }
    public Guid? AppointmentId { get; set; }
    public Guid? PatientId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}