namespace ClinicSystem.DTOs.Medications.Responses;

public record MedicationResponseDto
{
    public Guid Id { get; init; }
    public Guid PatientId { get; init; }
    public string PatientName { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string? ImagePath { get; init; }
    public string Dosage { get; init; } = string.Empty;
    public string Frequency { get; init; } = string.Empty;
    public string? Purpose { get; init; }
    public string Instructions { get; init; } = string.Empty;
    public string? PrescribingDoctor { get; init; }
    public DateTime StartDate { get; init; }
    public bool IsActive { get; init; }
    public DateTime CreatedAt { get; init; }
}