using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.Data.Configurations
{
    public sealed class FAQConfiguration : IEntityTypeConfiguration<FAQ>
    {
        public void Configure(EntityTypeBuilder<FAQ> builder)
        {
  
            builder.ToTable("FAQs", "clinic");

         
            builder.HasKey(f => f.Id);


            // Id - Primary key with PostgreSQL GUID generation
            builder.Property(f => f.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            // Question - Required, with reasonable length
            builder.Property(f => f.Question)
                .HasColumnName("question")
                .HasMaxLength(500)  // Questions shouldn't be too long
                .IsRequired();

            // Answer - Required, can be longer (FAQ answers)
            builder.Property(f => f.Answer)
                .HasColumnName("answer")
                .HasColumnType("text")  // Unlimited text for answers
                .IsRequired();

            // Category - Required, with max length
            builder.Property(f => f.Category)
                .HasColumnName("category")
                .HasMaxLength(100)
                .IsRequired();

            // DisplayOrder - Required, with default value
            builder.Property(f => f.DisplayOrder)
                .HasColumnName("display_order")
                .IsRequired()
                .HasDefaultValue(0);  // Default to 0 if not specified

        
            // Index 1: For searching FAQs by question (common)
            builder.HasIndex(f => f.Question)
                .HasDatabaseName("IX_FAQs_Question");

            // Index 2: For filtering FAQs by category (common)
            builder.HasIndex(f => f.Category)
                .HasDatabaseName("IX_FAQs_Category");

            // Index 3: For ordering FAQs by display order
            builder.HasIndex(f => f.DisplayOrder)
                .HasDatabaseName("IX_FAQs_DisplayOrder");

            // Index 4: Composite index for category + display order
            // This is the MOST COMMON query: "Show FAQs by category in order"
            builder.HasIndex(f => new { f.Category, f.DisplayOrder })
                .HasDatabaseName("IX_FAQs_Category_DisplayOrder");

            // Ensure DisplayOrder is not negative
            builder.ToTable(t => t.HasCheckConstraint(
                "CK_FAQs_DisplayOrder_NonNegative",
                "\"display_order\" >= 0"
            ));

            // Ensure Question is not empty string or whitespace
            builder.ToTable(t => t.HasCheckConstraint(
                "CK_FAQs_Question_NotEmpty",
                "LENGTH(TRIM(\"question\")) > 0"
            ));
        }
    }
}