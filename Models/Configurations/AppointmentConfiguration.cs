using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicSystem.Models.Entities;

namespace ClinicSystem.Models.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appoointments" ,"clinic");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("id")
                .HasDefaultValue("gen_random_uuid()");
            builder.Property(a => a.PatientId)
                .HasColumnName("patient_id")
                .IsRequired();

            builder.Property(a => a.ServiceId)
                .HasColumnName("service_id")
                .IsRequired();

            builder.Property(a => a.StaffId)
                .HasColumnName("staff_id")
                .IsRequired();

            builder.Property(a => a.AppointmentDate)
                .HasColumnName("appointment_date")
                .IsRequired()
                .HasColumnType("timestamp without time zone");

            builder.Property(a => a.AppointmentTime)
                .HasColumnName("appointment_time")
                .IsRequired();

            builder.Property(a => a.Status)
                .HasColumnName("status")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired()
                .HasDefaultValue(AppointmentStatus.Pending);

            builder.Property(a => a.Notes)
                .HasColumnName("notes")
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(a => a.IsFollowUp)
                .HasColumnName("is_follow_up")
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(a => a.ParentId)
                .HasColumnName("parent_id")
                .IsRequired(false);

            builder.Property(a => a.WoundDetailsAdded)
                .HasColumnName("wound_details_added")
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasIndex(a => a.PatientId)
                .HasDatabaseName("IX_Appointments_PatientId");

           
            builder.HasIndex(a => a.StaffId)
                .HasDatabaseName("IX_Appointments_StaffId");

            
            builder.HasIndex(a => a.AppointmentDate)
                .HasDatabaseName("IX_Appointments_AppointmentDate");

            
            builder.HasIndex(a => new { a.PatientId, a.AppointmentDate })
                .HasDatabaseName("IX_Appointments_User_Date");

            builder.HasIndex(a => a.Status)
                .HasDatabaseName("IX_Appointments_Status");

            //RELATIONSHIPS
            builder.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.ParentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(a => a.Service)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ServiceId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(a => a.Staff)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.StaffId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
             
            builder.HasOne(a => a.ParentAppointment)
                .WithMany(p => p.FollowUpAppointments)
                .HasForeignKey(a => a.ParentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

        }
    }
}
