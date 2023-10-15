using DAL.Enum;

namespace DAL.Entity
{
    public class Contract : BaseEntity
    {
        public Guid ContractId { get; set; }

        public string? ContractNumber { get; set; }

        public string? Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string? Description { get; set; }

        public ContractStatus ContractStatus { get; set; }

        public Guid ClientId { get; set; }

        public Client Client { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}