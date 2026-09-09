using ClinicSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ClinicSystem.Data.Configurations
{
    public sealed class HealthTipsConfiguration : IEntityTypeConfiguration<HealthTips>
    {
        public void Configure(EntityTypeBuilder<HealthTips> builder)
        {
            builder.ToTable("HealthTips", "clinic");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(h => h.Title)
                .HasColumnName("title")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(h => h.Content)
                .HasColumnName("content")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(h => h.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(h => h.IsActive)
                .HasColumnName("is_active")
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasIndex(h => h.Title)
                .HasDatabaseName("IX_HealthTips_Title");

            builder.HasIndex(h => h.IsActive)
                .HasDatabaseName("IX_HealthTips_IsActive");

            builder.HasIndex(h => h.CreatedAt)
                .HasDatabaseName("IX_HealthTips_CreatedAt");
               

            builder.HasIndex(h => new { h.IsActive, h.CreatedAt })
                .HasDatabaseName("IX_HealthTips_Active_CreatedAt");

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_HealthTips_Title_NotEmpty",
                "LENGTH(TRIM(\"title\")) > 0"
            ));
        }
    }
}