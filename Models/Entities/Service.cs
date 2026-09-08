namespace ClinicSystem.Models.Entities
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0.0m;
        public string Category { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        //navigation properties
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();


    }
}
