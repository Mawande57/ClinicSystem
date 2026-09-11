using Microsoft.EntityFrameworkCore;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.DTOs.Staff;

public static class StaffExtensions
{
    public static IQueryable<ClinicSystem.Models.Entities.Staff> ApplySearch(this IQueryable<ClinicSystem.Models.Entities.Staff> query, string? search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return query;

        return query.Where(s =>
            EF.Functions.ILike(s.User.FirstName, $"%{search}%") ||
            EF.Functions.ILike(s.User.LastName, $"%{search}%") ||
            EF.Functions.ILike(s.User.Email, $"%{search}%") ||
            EF.Functions.ILike(s.Specialization, $"%{search}%")
        );
    }
}