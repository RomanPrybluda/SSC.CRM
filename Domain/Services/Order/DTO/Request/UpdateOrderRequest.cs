using DAL.Entity;
using DAL.Enum;

namespace Domain.Services.ServicesOrder.DTO
{
    public class UpdateOrderRequest : CreateOrderRequest
    {
        public Guid OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public Guid ContractId { get; set; }

        public ICollection<Document>? Documents { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public bool AllDocsAreReady { get; set; }

        public bool AllDocsAreApproved { get; set; }

        public bool CheckersAreAssigned { get; set; }

        public bool DevelopersAreAssigned { get; set; }

        public bool ContractIsCompleted { get; set; }

        public bool InvoiceIsIssued { get; set; }

        public bool Paid { get; set; }
    }
}