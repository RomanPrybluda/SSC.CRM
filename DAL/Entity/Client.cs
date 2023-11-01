namespace DAL.Entity
{
    public class Client : BaseEntity
    {
        public Guid ClientId { get; set; }

        public string? CompanyName { get; set; }

        public string? Address { get; set; }

        public string? ContactEmail { get; set; }

        public string? ContactPhone { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<ContactPerson> ContactPersons { get; set; } = new List<ContactPerson>();

        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    }
}