namespace ClinicSystem.DTOs.WoundDetails.Responses;

public record WoundDetailResponseDto
{
    public Guid Id { get; init; }
    public Guid AppointmentId { get; init; }
    public DateTime? DateOfOnset { get; init; }
    public string? CauseOfWound { get; init; }
    public string? PreviousTreatment { get; init; }
    public string? WoundLocation { get; init; }
    public string? ProgressNotes { get; init; }
    public int? PainLevel { get; init; }
    public string? PainDescription { get; init; }
    public string? ExudateAmount { get; init; }
    public string? ImagePath { get; init; }
    public DateTime CreatedAt { get; init; }
    public Guid PatientId { get; init; }
    public string PatientName { get; init; } = string.Empty;
}