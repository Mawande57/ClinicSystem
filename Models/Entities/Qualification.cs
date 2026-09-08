namespace ClinicSystem.Models.Entities
{
    public sealed class Qualification
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? ExpirationDate { get; set; }
        public string Issuer { get; set; } = string.Empty;

        //navigation properties
        public Staff Staff { get; set; } = null!;

    }
}
