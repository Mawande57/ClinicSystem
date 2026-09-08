using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.Data.Configurations
{
    public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.ToTable("MedicalRecords", "clinic");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(m => m.PatientId)
                .HasColumnName("patient_id")
                .IsRequired();

            builder.Property(m => m.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(m => m.FilePath)
                .HasColumnName("file_path")
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(m => m.RecordDate)
                .HasColumnName("record_date")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasIndex(m => m.PatientId)
                .HasDatabaseName("IX_MedicalRecords_PatientId");

            builder.HasIndex(m => m.RecordDate)
                .HasDatabaseName("IX_MedicalRecords_RecordDate");

            builder.HasIndex(m => new { m.PatientId, m.RecordDate })
                .HasDatabaseName("IX_MedicalRecords_Patient_Date");

            builder.HasOne(m => m.Patient)
                .WithMany(p => p.MedicalRecords)
                .HasForeignKey(m => m.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}