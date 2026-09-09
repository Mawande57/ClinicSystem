using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.Data.Configurations
{
    public sealed class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients", "clinic");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(p => p.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(p => p.DateOfBirth)
                .HasColumnName("date_of_birth")
                .IsRequired(false);

            builder.Property(p => p.Gender)
                .HasColumnName("gender")
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(p => p.Address)
                .HasColumnName("address")
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(p => p.EmergencyContact)
                .HasColumnName("emergency_contact")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(p => p.InsuranceInfo)
                .HasColumnName("insurance_info")
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(p => p.MedicalHistory)
                .HasColumnName("medical_history")
                .HasColumnType("text")
                .IsRequired(false);

            builder.Property(p => p.IsActive)
                .HasColumnName("is_active")
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasIndex(p => p.UserId)
                .HasDatabaseName("IX_Patients_UserId")
                .IsUnique();

            builder.HasIndex(p => p.Gender)
                .HasDatabaseName("IX_Patients_Gender");

            builder.HasIndex(p => p.IsActive)
                .HasDatabaseName("IX_Patients_IsActive");

            builder.HasOne(p => p.User)
                .WithOne(u => u.Patient)
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}