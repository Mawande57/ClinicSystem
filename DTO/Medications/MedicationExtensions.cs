using Microsoft.EntityFrameworkCore;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.DTOs.Medications;

public static class MedicationExtensions
{
    public static IQueryable<Medication> ApplySearch(this IQueryable<Medication> query, string? search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return query;

        return query.Where(m =>
            EF.Functions.ILike(m.Name, $"%{search}%") ||
            EF.Functions.ILike(m.Purpose ?? string.Empty, $"%{search}%") ||
            EF.Functions.ILike(m.PrescribingDoctor ?? string.Empty, $"%{search}%")
        );
    }
}