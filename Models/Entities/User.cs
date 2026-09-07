namespace ClinicSystem.Models.Entities
{
    public  class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FirstName { get; set;} = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }   = string.Empty;
        public UseRole Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; } 

        public Patient? Patient { get; set; } 
        public Staff? Staff { get; set; }


    }
}
