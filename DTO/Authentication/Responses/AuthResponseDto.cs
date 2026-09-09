namespace ClinicSystem.DTOs.Authentication.Responses;

public record AuthResponseDto
{
    public string Token { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
    public DateTime ExpiresAt { get; init; }
    public UserProfileResponseDto User { get; init; } = null!;
}