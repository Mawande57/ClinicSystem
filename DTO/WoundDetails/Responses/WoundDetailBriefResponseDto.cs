namespace ClinicSystem.DTOs.WoundDetails.Responses;

public record WoundDetailBriefResponseDto
{
    public Guid Id { get; init; }
    public string WoundLocation { get; init; } = string.Empty;
    public int? PainLevel { get; init; }
    public DateTime? DateOfOnset { get; init; }
}