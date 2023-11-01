using DAL.Enum;

namespace DAL.Entity
{
    public class Order : BaseEntity
    {
        public Guid OrderId { get; set; }

        public string? OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public string? WorkOrderDescription { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public Guid ContractId { get; set; }

        public Contract? Contract { get; set; }

        public ICollection<Document> Documents { get; set; } = new List<Document>();

        public bool AllDocsAreReady { get; set; }

        public bool AllDocsAreApproved { get; set; }

        public bool CheckersAreAssigned { get; set; }

        public bool DevelopersAreAssigned { get; set; }

        public bool ContractIsCompleted { get; set; }

        public bool InvoiceIsIssued { get; set; }

        public bool Paid { get; set; }
    }
}