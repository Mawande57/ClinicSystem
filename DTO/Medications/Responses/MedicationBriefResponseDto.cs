namespace ClinicSystem.DTOs.Medications.Responses;

public record MedicationBriefResponseDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Dosage { get; init; } = string.Empty;
    public string Frequency { get; init; } = string.Empty;
    public bool IsActive { get; init; }
}