namespace UserRecord.Api.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
