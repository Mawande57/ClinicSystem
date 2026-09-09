namespace ClinicSystem.DTOs.Patients.Requests;

public record UpdatePatientRequestDto
{
    public DateTime? DateOfBirth { get; init; }
    public string? Gender { get; init; }
    public string? Address { get; init; }
    public string? EmergencyContact { get; init; }
    public string? InsuranceInfo { get; init; }
    public string? MedicalHistory { get; init; }
    public bool? IsActive { get; init; }
}