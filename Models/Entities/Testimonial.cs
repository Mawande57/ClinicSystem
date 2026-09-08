namespace ClinicSystem.Models.Entities
{
    public sealed class Testimonial
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public int Rating { get; set; } = 0;
        public string Comment { get; set; } = string.Empty;
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
        public bool IsFeatured { get; set; } = false;
        //navigation properties
        public Patient Patient { get; set; } = null!;
    }


}
