namespace ClinicSystem.Models.Entities
{
    public sealed class Staff
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Specialization { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string Bio { get; set; } = string.Empty;

        //navigation properties
        public User User { get; set; } = null!;
        public ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();



    }
}
