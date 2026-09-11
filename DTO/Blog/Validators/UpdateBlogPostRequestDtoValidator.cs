using FluentValidation;
using ClinicSystem.DTOs.Blog.Requests;

namespace ClinicSystem.DTOs.Blog.Validators;

public class UpdateBlogPostRequestDtoValidator : AbstractValidator<UpdateBlogPostRequestDto>
{
    public UpdateBlogPostRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Title)
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters")
            .When(x => x.Title != null);

        RuleFor(x => x.Content)
            .MinimumLength(100).WithMessage("Content must be at least 100 characters")
            .When(x => x.Content != null);

        RuleFor(x => x.Category)
            .MaximumLength(100).WithMessage("Category cannot exceed 100 characters")
            .When(x => x.Category != null);

        RuleFor(x => x.ImagePath)
            .MaximumLength(500).WithMessage("Image path cannot exceed 500 characters")
            .When(x => x.ImagePath != null);
    }
}