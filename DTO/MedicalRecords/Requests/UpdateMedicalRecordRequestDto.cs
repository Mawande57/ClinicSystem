namespace ClinicSystem.DTOs.MedicalRecords.Requests;

public record UpdateMedicalRecordRequestDto
{
    public string? Description { get; init; }
    public string? FilePath { get; init; }
    public DateTime? RecordDate { get; init; }
}