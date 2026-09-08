namespace ClinicSystem.Models.Entities
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Category { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;

        public uint Version { get; set; }




    }

    

}
