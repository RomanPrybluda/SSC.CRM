namespace DAL.Entity
{
    public class ContactPerson : BaseEntity
    {
        public Guid ContactPersonId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Position { get; set; }

        public string? Notes { get; set; }

        public Guid ClientId { get; set; }

        public Client? Client { get; set; }
    }
}