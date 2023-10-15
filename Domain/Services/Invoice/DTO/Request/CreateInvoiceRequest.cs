using DAL.Enum;

namespace Domain.Services.InvoiceServices.DTO
{
    public class CreateInvoiceRequest
    {
        public string? InvoiceNumber { get; set; }

        public decimal TotalAmount { get; set; }

        public InvoiceStatus InvoiceStatus { get; set; }

        public Guid ClientId { get; set; }

        public Guid ContactPersonId { get; set; }

        public Guid OrderId { get; set; }
    }
}