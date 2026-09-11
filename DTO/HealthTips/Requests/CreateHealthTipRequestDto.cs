namespace ClinicSystem.DTOs.HealthTips.Requests;

public record CreateHealthTipRequestDto
{
    public string Title { get; init; } = string.Empty;
    public string Content { get; init; } = string.Empty;
    public bool IsActive { get; init; } = true;
}