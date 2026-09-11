using FluentValidation;
using ClinicSystem.DTOs.Blog.Requests;

namespace ClinicSystem.DTOs.Blog.Validators;

public class CreateBlogPostRequestDtoValidator : AbstractValidator<CreateBlogPostRequestDto>
{
    public CreateBlogPostRequestDtoValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required")
            .MinimumLength(100).WithMessage("Content must be at least 100 characters");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required")
            .MaximumLength(100).WithMessage("Category cannot exceed 100 characters");

        RuleFor(x => x.ImagePath)
            .MaximumLength(500).WithMessage("Image path cannot exceed 500 characters")
            .When(x => x.ImagePath != null);

        RuleFor(x => x.PublishedAt)
            .NotEmpty().WithMessage("Published date is required");
    }
}