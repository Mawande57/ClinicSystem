using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.Data.Configurations
{
    public sealed class MedicationConfiguration : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.ToTable("Medications", "clinic");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(m => m.PatientId)
                .HasColumnName("patient_id")
                .IsRequired();

            builder.Property(m => m.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(m => m.ImagePath)
                .HasColumnName("image_path")
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(m => m.Dosage)
                .HasColumnName("dosage")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Frequency)
                .HasColumnName("frequency")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Purpose)
                .HasColumnName("purpose")
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(m => m.Instructions)
                .HasColumnName("instructions")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(m => m.PrescribingDoctor)
                .HasColumnName("prescribing_doctor")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(m => m.StartDate)
                .HasColumnName("start_date")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(m => m.IsActive)
                .HasColumnName("is_active")
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasIndex(m => m.PatientId)
                .HasDatabaseName("IX_Medications_PatientId");

            builder.HasIndex(m => m.Name)
                .HasDatabaseName("IX_Medications_Name");

            builder.HasIndex(m => m.IsActive)
                .HasDatabaseName("IX_Medications_IsActive");

            builder.HasIndex(m => new { m.PatientId, m.IsActive })
                .HasDatabaseName("IX_Medications_Patient_Active");

            builder.HasIndex(m => new { m.PatientId, m.StartDate })
                .HasDatabaseName("IX_Medications_Patient_StartDate");

            builder.HasOne(m => m.Patient)
                .WithMany(p => p.Medications)
                .HasForeignKey(m => m.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Medication_Name_NotEmpty",
                "LENGTH(TRIM(\"name\")) > 0"
            ));
        }
    }
}