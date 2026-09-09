using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.Data.Configurations
{
    public sealed class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services", "clinic");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(s => s.Description)
                .HasColumnName("description")
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(s => s.Duration)
                .HasColumnName("duration")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.Price)
                .HasColumnName("price")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(s => s.Category)
                .HasColumnName("category")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.IsActive)
                .HasColumnName("is_active")
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasIndex(s => s.Name)
                .HasDatabaseName("IX_Services_Name");

            builder.HasIndex(s => s.Category)
                .HasDatabaseName("IX_Services_Category");

            builder.HasIndex(s => s.IsActive)
                .HasDatabaseName("IX_Services_IsActive");

            builder.HasIndex(s => s.Price)
                .HasDatabaseName("IX_Services_Price");

            builder.HasIndex(s => new { s.Category, s.IsActive })
                .HasDatabaseName("IX_Services_Category_Active");

            builder.HasIndex(s => new { s.Name, s.Category })
                .HasDatabaseName("IX_Services_Name_Category");

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Services_Price_NonNegative",
                "\"price\" >= 0"
            ));

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Services_Name_NotEmpty",
                "LENGTH(TRIM(\"name\")) > 0"
            ));
        }
    }
}