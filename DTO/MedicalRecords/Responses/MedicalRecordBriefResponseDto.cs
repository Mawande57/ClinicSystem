namespace ClinicSystem.DTOs.MedicalRecords.Responses;

public record MedicalRecordBriefResponseDto
{
    public Guid Id { get; init; }
    public string Description { get; init; } = string.Empty;
    public DateTime RecordDate { get; init; }
}