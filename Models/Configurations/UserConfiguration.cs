using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "clinic");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("email")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(u => u.PasswordHash)
                .HasColumnName("password_hash")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(u => u.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.PhoneNumber)
                .HasColumnName("phone_number")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(u => u.Role)
                .HasColumnName("role")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(u => u.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(u => u.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired(false);

            // 🔥 SOFT DELETE PROPERTIES
            builder.Property(u => u.IsDeleted)
                .HasColumnName("is_deleted")
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(u => u.DeletedAt)
                .HasColumnName("deleted_at")
                .IsRequired(false);

            // 🔥 INDEX FOR SOFT DELETE - Important for performance!
            builder.HasIndex(u => u.IsDeleted)
                .HasDatabaseName("IX_Users_IsDeleted");

            builder.HasIndex(u => new { u.IsDeleted, u.Email })
                .HasDatabaseName("IX_Users_IsDeleted_Email");

            builder.HasIndex(u => u.Email)
                .HasDatabaseName("IX_Users_Email")
                .IsUnique();

            builder.HasIndex(u => u.Role)
                .HasDatabaseName("IX_Users_Role");

            builder.HasIndex(u => new { u.FirstName, u.LastName })
                .HasDatabaseName("IX_Users_Name");

            builder.HasIndex(u => u.CreatedAt)
                .HasDatabaseName("IX_Users_CreatedAt");

            builder.HasOne(u => u.Patient)
                .WithOne(p => p.User)
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasOne(u => u.Staff)
                .WithOne(s => s.User)
                .HasForeignKey<Staff>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Users_Email_NotEmpty",
                "LENGTH(TRIM(\"email\")) > 0"
            ));

         
            builder.HasQueryFilter(u => !u.IsDeleted);
        }
    }
}