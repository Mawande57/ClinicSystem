namespace ClinicSystem.DTOs.Medications.Requests;

public record UpdateMedicationRequestDto
{
    public string? Name { get; init; }
    public string? Dosage { get; init; }
    public string? Frequency { get; init; }
    public string? Purpose { get; init; }
    public string? Instructions { get; init; }
    public string? PrescribingDoctor { get; init; }
    public DateTime? StartDate { get; init; }
    public bool? IsActive { get; init; }
}