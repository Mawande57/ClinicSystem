using Microsoft.EntityFrameworkCore;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.DTOs.FAQ;

public static class FAQExtensions
{
    public static IQueryable<Models.Entities.FAQ> ApplySearch(this IQueryable<Models.Entities.FAQ> query, string? search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return query;

        return query.Where(f =>
            EF.Functions.ILike(f.Question, $"%{search}%") ||
            EF.Functions.ILike(f.Answer, $"%{search}%") ||
            EF.Functions.ILike(f.Category, $"%{search}%")
        );
    }
}