namespace ClinicSystem.Models.Entities
{
    public class FAQ
    {
        public Guid Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int DisplayOrder { get; set; } = 0;
    }
}
