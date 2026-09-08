namespace ClinicSystem.Models.Entities
{
    public sealed class MedicalRecord
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? FilePath { get; set; }
        public DateTime RecordDate { get; set; }

        //navigation properties
        public Patient Patient { get; set; } = null!;

    }
}
