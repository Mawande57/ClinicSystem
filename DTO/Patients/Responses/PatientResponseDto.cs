namespace ClinicSystem.DTOs.Patients.Responses;

public record PatientResponseDto
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
    public DateTime? DateOfBirth { get; init; }
    public string? Gender { get; init; }
    public string? Address { get; init; }
    public string? EmergencyContact { get; init; }
    public string? InsuranceInfo { get; init; }
    public string? MedicalHistory { get; init; }
    public bool IsActive { get; init; }
    public DateTime CreatedAt { get; init; }
    public int TotalAppointments { get; init; }
    public int TotalMedications { get; init; }
}