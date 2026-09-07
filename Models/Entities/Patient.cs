using Microsoft.Extensions.Configuration.UserSecrets;

namespace ClinicSystem.Models.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? EmergencyContact { get; set; }
        public string? InsuranceInfo { get; set; }
        public string? MedicalHistory { get; set; }
        public bool IsActive { get; set; } = true;

        //navigation properties
        public User User { get; set; } = null!;
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public ICollection<Medication> Medications { get; set; } = new List<Medication>();
        public ICollection<Testimonial> Testimonials { get; set; } = new List<Testimonial>();
    



    





    }
}
