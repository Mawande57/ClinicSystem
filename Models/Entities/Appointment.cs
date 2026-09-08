using System.Xml;

namespace ClinicSystem.Models.Entities
{
    public sealed class Appointment
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid ServiceId { get; set; }
        public Guid StaffId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsFollowUp { get; set; } = false;
        public Guid? ParentId { get; set; }
        public bool WoundDetailsAdded { get; set; } = false;

        //navigation properties
        public Patient Patient { get; set; } = null!;
        public Staff Staff { get; set; } = null!;
        public Service Service { get; set; } = null!;
        public WoundDetail? WoundDetails { get; set; }

        //THESE ARE FOR THE FOLLOW-UP APPOINTMENTS
        public Appointment? ParentAppointment { get; set; }
        public ICollection<Appointment> FollowUpAppointments { get; set; } = new List<Appointment>();





    }
}
