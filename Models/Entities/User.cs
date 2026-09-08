namespace ClinicSystem.Models.Entities
{
    public  sealed class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FirstName { get; set;} = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }   = string.Empty;
        public UserRole Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
        //soft delete
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        //navigation properties
        public Patient? Patient { get; set; } 
        public Staff? Staff { get; set; }


    }
}
