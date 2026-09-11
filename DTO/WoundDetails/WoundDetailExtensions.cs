using Microsoft.EntityFrameworkCore;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.DTOs.WoundDetails;

public static class WoundDetailExtensions
{
    public static IQueryable<WoundDetail> ApplySearch(this IQueryable<WoundDetail> query, string? search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return query;

        return query.Where(w =>
            EF.Functions.ILike(w.WoundLocation ?? string.Empty, $"%{search}%") ||
            EF.Functions.ILike(w.PainDescription ?? string.Empty, $"%{search}%") ||
            EF.Functions.ILike(w.ProgressNotes ?? string.Empty, $"%{search}%")
        );
    }
}