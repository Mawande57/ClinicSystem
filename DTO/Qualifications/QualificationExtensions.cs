using Microsoft.EntityFrameworkCore;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.DTOs.Qualifications;

public static class QualificationExtensions
{
    public static IQueryable<Qualification> ApplySearch(this IQueryable<Qualification> query, string? search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return query;

        return query.Where(q =>
            EF.Functions.ILike(q.Name, $"%{search}%") ||
            EF.Functions.ILike(q.Issuer, $"%{search}%") ||
            EF.Functions.ILike(q.Description, $"%{search}%")
        );
    }
}