namespace ClinicSystem.DTOs.MedicalRecords.Requests;

public record CreateMedicalRecordRequestDto
{
    public Guid PatientId { get; init; }
    public string Description { get; init; } = string.Empty;
    public string? FilePath { get; init; }
    public DateTime RecordDate { get; init; }
}