using ClinicSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ClinicSystem.Data.Configurations
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            // ============================================================
            // 1. TABLE NAME
            // ============================================================
            builder.ToTable("BlogPosts", "clinic");

            // ============================================================
            // 2. PRIMARY KEY
            // ============================================================
            builder.HasKey(b => b.Id);

            // ============================================================
            // 3. PROPERTY CONFIGURATIONS
            // ============================================================

            // Id - Primary key with PostgreSQL GUID generation
            builder.Property(b => b.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            // Title - Required, with max length for performance
            builder.Property(b => b.Title)
                .HasColumnName("title")
                .HasMaxLength(200)  // Blog titles shouldn't be too long
                .IsRequired();

            // Content - Required, can be large (blog content)
            builder.Property(b => b.Content)
                .HasColumnName("content")
                .HasColumnType("text")  // Unlimited text for blog posts
                .IsRequired();

            // CreatedAt - Required, set by database on insert
            builder.Property(b => b.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Category - Required, with max length
            builder.Property(b => b.Category)
                .HasColumnName("category")
                .HasMaxLength(100)
                .IsRequired();

            // ImagePath - Optional (string? in model if you want)
            builder.Property(b => b.ImagePath)
                .HasColumnName("image_path")
                .HasMaxLength(500)  // Paths can be long
                .IsRequired(false);  // Image is optional

            // PublishedAt - Required, default to current date/time
            builder.Property(b => b.PublishedAt)
                .HasColumnName("published_at")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // ============================================================
            // 4. 🔥 CONCURRENCY TOKEN (Optimistic Concurrency)
            // ============================================================

            // Option 1: Using PostgreSQL's xmin system column (RECOMMENDED)
            builder.Property(b => b.Version)
                .HasColumnName("xmin")  // PostgreSQL system column
                .HasColumnType("xid")       // PostgreSQL transaction ID type
                .IsConcurrencyToken()   // This is the magic!
                .ValueGeneratedOnAddOrUpdate();  // Auto-managed by PostgreSQL

            builder.HasIndex(b => b.Title)
                .HasDatabaseName("IX_BlogPosts_Title");

            builder.HasIndex(b => b.Category)
                .HasDatabaseName("IX_BlogPosts_Category");

            builder.HasIndex(b => b.PublishedAt)
                .HasDatabaseName("IX_BlogPosts_PublishedAt")
               


            builder.HasIndex(b => new { b.Category, b.PublishedAt })
                .HasDatabaseName("IX_BlogPosts_Category_PublishedAt");

 
            builder.HasIndex(b => b.Title)
                .HasDatabaseName("IX_BlogPosts_Title_FTS")
                .HasMethod("gin")  // GIN index for full-text search
                .HasOperators(new[] { "gin_trgm_ops" });  // Trigram search

            builder.HasIndex(b => b.Content)
                .HasDatabaseName("IX_BlogPosts_Content_FTS")
                .HasMethod("gin")
                .HasOperators(new[] { "gin_trgm_ops" });


            builder.ToTable(t => t.HasCheckConstraint(
                "CK_BlogPost_PublishedAfterCreated",
                "\"published_at\" >= \"created_at\""
            ));

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_BlogPost_Title_NotEmpty",
                "LENGTH(TRIM(\"title\")) > 0"
            ));
        }
    }
}