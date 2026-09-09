using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.Data.Configurations
{
    public sealed class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.ToTable("Testimonials", "clinic");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(t => t.PatientId)
                .HasColumnName("patient_id")
                .IsRequired();

            builder.Property(t => t.Rating)
                .HasColumnName("rating")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(t => t.Comment)
                .HasColumnName("comment")
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(t => t.ReviewDate)
                .HasColumnName("review_date")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(t => t.IsFeatured)
                .HasColumnName("is_featured")
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasIndex(t => t.PatientId)
                .HasDatabaseName("IX_Testimonials_PatientId");

            builder.HasIndex(t => t.Rating)
                .HasDatabaseName("IX_Testimonials_Rating");

            builder.HasIndex(t => t.IsFeatured)
                .HasDatabaseName("IX_Testimonials_IsFeatured");

            builder.HasIndex(t => t.ReviewDate)
                .HasDatabaseName("IX_Testimonials_ReviewDate");

            builder.HasIndex(t => new { t.IsFeatured, t.ReviewDate })
                .HasDatabaseName("IX_Testimonials_Featured_Date");

            builder.HasIndex(t => new { t.PatientId, t.ReviewDate })
                .HasDatabaseName("IX_Testimonials_Patient_Date");

            builder.HasOne(t => t.Patient)
                .WithMany(p => p.Testimonials)
                .HasForeignKey(t => t.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Testimonials_Rating_Range",
                "\"rating\" BETWEEN 1 AND 5"
            ));

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Testimonials_Comment_NotEmpty",
                "LENGTH(TRIM(\"comment\")) > 0"
            ));
        }
    }
}