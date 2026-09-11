using Microsoft.EntityFrameworkCore;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.DTOs.HealthTips;

public static class HealthTipExtensions
{
    public static IQueryable<Models.Entities.HealthTips> ApplySearch(this IQueryable<Models.Entities.HealthTips> query, string? search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return query;

        return query.Where(h =>
            EF.Functions.ILike(h.Title, $"%{search}%") ||
            EF.Functions.ILike(h.Content, $"%{search}%")
        );
    }
}