using DAL.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Services.InvoiceServices.DTO
{
    public class CreateInvoiceRequest
    {
        [Required]
        public string? InvoiceNumber { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public InvoiceStatus InvoiceStatus { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public Guid ContactPersonId { get; set; }

        [Required]
        public Guid OrderId { get; set; }
    }
}