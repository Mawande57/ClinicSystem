using Microsoft.EntityFrameworkCore;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.DTOs.MedicalRecords;

public static class MedicalRecordExtensions
{
    public static IQueryable<MedicalRecord> ApplySearch(this IQueryable<MedicalRecord> query, string? search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return query;

        return query.Where(m =>
            EF.Functions.ILike(m.Description, $"%{search}%") ||
            EF.Functions.ILike(m.Patient.User.FirstName, $"%{search}%") ||
            EF.Functions.ILike(m.Patient.User.LastName, $"%{search}%")
        );
    }
}