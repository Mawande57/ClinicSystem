using System.Xml;

namespace ClinicSystem.Models.Entities
{
    public sealed class Appointment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
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
        public Patient patient { get; set; } = null!;
        public Staff staff { get; set; } = null!;
        public Service service { get; set; } = null!;
    }







    }
}
