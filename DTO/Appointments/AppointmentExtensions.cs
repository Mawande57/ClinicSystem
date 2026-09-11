using Microsoft.EntityFrameworkCore;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.DTOs.Appointments;

public static class AppointmentExtensions
{
    public static IQueryable<Appointment> ApplySearch(this IQueryable<Appointment> query, string? search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return query;

        return query.Where(a =>
            EF.Functions.ILike(a.Patient.User.FirstName, $"%{search}%") ||
            EF.Functions.ILike(a.Patient.User.LastName, $"%{search}%") ||
            EF.Functions.ILike(a.Staff.User.FirstName, $"%{search}%") ||
            EF.Functions.ILike(a.Staff.User.LastName, $"%{search}%") ||
            EF.Functions.ILike(a.Service.Name, $"%{search}%")
        );
    }
}