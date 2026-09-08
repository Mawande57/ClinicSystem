using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.Data.Configurations
{
    public class QualificationConfiguration : IEntityTypeConfiguration<Qualification>
    {
        public void Configure(EntityTypeBuilder<Qualification> builder)
        {
            builder.ToTable("Qualifications", "clinic");

            builder.HasKey(q => q.Id);

            builder.Property(q => q.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(q => q.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(q => q.Description)
                .HasColumnName("description")
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(q => q.ExpirationDate)
                .HasColumnName("expiration_date")
                .IsRequired(false);

            builder.Property(q => q.Issuer)
                .HasColumnName("issuer")
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(q => q.Name)
                .HasDatabaseName("IX_Qualifications_Name");

            builder.HasIndex(q => q.Issuer)
                .HasDatabaseName("IX_Qualifications_Issuer");

            builder.HasIndex(q => q.ExpirationDate)
                .HasDatabaseName("IX_Qualifications_ExpirationDate");

            builder.HasIndex(q => new { q.Name, q.Issuer })
                .HasDatabaseName("IX_Qualifications_Name_Issuer");

          
             builder.Property(q => q.StaffId)
                 .HasColumnName("staff_id")
                 .IsRequired();

             
             builder.HasOne(q => q.Staff)
                 .WithMany(s => s.Qualifications)
                 .HasForeignKey(q => q.StaffId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();
        }
    }
}