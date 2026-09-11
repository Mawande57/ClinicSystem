using Microsoft.EntityFrameworkCore;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.DTOs.Patients;

public static class PatientExtensions
{
    public static IQueryable<Patient> ApplySearch(this IQueryable<Patient> query, string? search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return query;

        return query.Where(p =>
            EF.Functions.ILike(p.User.FirstName, $"%{search}%") ||
            EF.Functions.ILike(p.User.LastName, $"%{search}%") ||
            EF.Functions.ILike(p.User.Email, $"%{search}%") ||
            EF.Functions.ILike(p.User.PhoneNumber, $"%{search}%")
        );
    }
}