using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.Data.Configurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("Staff", "clinic");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()")
                .IsRequired();

            builder.Property(s => s.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(s => s.Specialization)
                .HasColumnName("specialization")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(s => s.IsActive)
                .HasColumnName("is_active")
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(s => s.Bio)
                .HasColumnName("bio")
                .HasColumnType("text")
                .IsRequired();

            builder.HasIndex(s => s.UserId)
                .HasDatabaseName("IX_Staff_UserId")
                .IsUnique();

            builder.HasIndex(s => s.Specialization)
                .HasDatabaseName("IX_Staff_Specialization");

            builder.HasIndex(s => s.IsActive)
                .HasDatabaseName("IX_Staff_IsActive");

            builder.HasIndex(s => new { s.Specialization, s.IsActive })
                .HasDatabaseName("IX_Staff_Specialization_Active");

            builder.HasOne(s => s.User)
                .WithOne(u => u.Staff)
                .HasForeignKey<Staff>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}