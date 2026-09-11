namespace ClinicSystem.DTOs.MedicalRecords.Responses;

public record MedicalRecordResponseDto
{
    public Guid Id { get; init; }
    public Guid PatientId { get; init; }
    public string PatientName { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string? FilePath { get; init; }
    public DateTime RecordDate { get; init; }
    public DateTime CreatedAt { get; init; }
}