using ClinicSystem.DTOs.Common;

namespace ClinicSystem.DTOs.Appointments.Requests;

public class AppointmentQueryFilter : QueryFilter
{
    public string? Search { get; set; }
    public Guid? PatientId { get; set; }
    public Guid? StaffId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public AppointmentStatus? Status { get; set; }
    public bool? IsFollowUp { get; set; }
}