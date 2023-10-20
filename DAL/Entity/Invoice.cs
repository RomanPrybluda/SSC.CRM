using DAL.Enum;

namespace DAL.Entity
{
    public class Invoice : BaseEntity
    {
        public Guid InvoiceId { get; set; }

        public string? InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal Amount { get; set; }

        public InvoiceStatus InvoiceStatus { get; set; }

        public Guid ContractId { get; set; }

        public Contract Contract { get; set; }
    }
}