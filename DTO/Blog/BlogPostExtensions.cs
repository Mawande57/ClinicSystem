using Microsoft.EntityFrameworkCore;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.DTOs.Blog;

public static class BlogPostExtensions
{
    public static IQueryable<BlogPost> ApplySearch(this IQueryable<BlogPost> query, string? search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return query;

        return query.Where(b =>
            EF.Functions.ILike(b.Title, $"%{search}%") ||
            EF.Functions.ILike(b.Content, $"%{search}%") ||
            EF.Functions.ILike(b.Category, $"%{search}%")
        );
    }
}