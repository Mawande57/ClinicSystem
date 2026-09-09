namespace ClinicSystem.Models.Entities
{
    public class WoundDetail
    {
        public Guid Id { get; set; }
        public Guid AppointMentId { get; set; }

       
        public DateTime? DateOdOnset { get; set; }
        public string? CuaseOfWound { get; set; }
        public string? PreviousTreatement { get; set; }
        public string? WoundLocation { get; set; }
        public string? ProgressNotes { get; set; }
        public int? Painevel { get; set; }
        public string? PainDescription { get; set; }
        public string? ExudateAmount { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //navigation properties
        public Appointment Appointment { get; set; } = null!;
      //The patient was not ADDED to follow DRY and aviod reduncancy will user Theninclude()
    
    }
}
