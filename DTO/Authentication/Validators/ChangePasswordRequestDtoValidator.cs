using FluentValidation;
using ClinicSystem.DTOs.Authentication.Requests;

namespace ClinicSystem.DTOs.Authentication.Validators;

public class ChangePasswordRequestDtoValidator : AbstractValidator<ChangePasswordRequestDto>
{
    public ChangePasswordRequestDtoValidator()
    {
        CascadeMode = CascadeMode.Stop;

        RuleFor(x => x.CurrentPassword)
            .NotEmpty().WithMessage("Current password is required");

        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("New password is required")
            .MinimumLength(8).WithMessage("New password must be at least 8 characters")
            .MaximumLength(100).WithMessage("New password cannot exceed 100 characters")
            .Matches(@"[A-Z]").WithMessage("New password must contain at least one uppercase letter")
            .Matches(@"[a-z]").WithMessage("New password must contain at least one lowercase letter")
            .Matches(@"[0-9]").WithMessage("New password must contain at least one number")
            .Matches(@"[^a-zA-Z0-9]").WithMessage("New password must contain at least one special character")
            .NotEqual(x => x.CurrentPassword).WithMessage("New password must be different from current password");

        RuleFor(x => x.ConfirmNewPassword)
            .NotEmpty().WithMessage("Please confirm your new password")
            .Equal(x => x.NewPassword).WithMessage("Passwords do not match");
    }
}