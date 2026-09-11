namespace ClinicSystem.DTOs.HealthTips.Requests;

public record UpdateHealthTipRequestDto
{
    public string? Title { get; init; }
    public string? Content { get; init; }
    public bool? IsActive { get; init; }
}