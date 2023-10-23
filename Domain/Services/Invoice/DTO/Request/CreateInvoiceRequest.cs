using DAL.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Services.InvoiceServices.DTO
{
    public class CreateInvoiceRequest
    {
        [Required]
        public string? InvoiceNumber { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public InvoiceStatus InvoiceStatus { get; set; } = InvoiceStatus.Pending;

        [Required]
        public Guid ContractId { get; set; }

    }
}