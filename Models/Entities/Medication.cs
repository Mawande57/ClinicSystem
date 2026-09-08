namespace ClinicSystem.Models.Entities
{
    public sealed class Medication
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public string Dosage { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public string? Purpose { get; set; }
        public string Instructions { get; set; } = string.Empty;

        public string? PrescribingDoctor { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        //navigation properties
        public Patient Patient { get; set; } = null!;//well here im ot sure if the patient should be mandatory cuz medications exists but for now i will make it mandatory




    }
}
