namespace ClinicSystem.DTOs.Medications.Requests;

public record CreateMedicationRequestDto
{
    public Guid PatientId { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Dosage { get; init; } = string.Empty;
    public string Frequency { get; init; } = string.Empty;
    public string? Purpose { get; init; }
    public string Instructions { get; init; } = string.Empty;
    public string? PrescribingDoctor { get; init; }
    public DateTime StartDate { get; init; }
}