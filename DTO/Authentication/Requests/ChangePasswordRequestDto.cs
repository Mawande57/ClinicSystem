namespace ClinicSystem.DTOs.Authentication.Requests;

public record ChangePasswordRequestDto
{
    public string CurrentPassword { get; init; } = string.Empty;
    public string NewPassword { get; init; } = string.Empty;
    public string ConfirmNewPassword { get; init; } = string.Empty;
}