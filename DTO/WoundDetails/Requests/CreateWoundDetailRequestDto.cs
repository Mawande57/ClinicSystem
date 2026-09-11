namespace ClinicSystem.DTO.WoundDetails.Requests;

public record CreateWoundDetailRequestDto
{
    public Guid AppointmentId { get; init; }
    public DateTime? DateOfOnset { get; init; }
    public string? CauseOfWound { get; init; }
    public string? PreviousTreatment { get; init; }
    public string? WoundLocation { get; init; }
    public string? ProgressNotes { get; init; }
    public int? PainLevel { get; init; }
    public string? PainDescription { get; init; }
    public string? ExudateAmount { get; init; }
}