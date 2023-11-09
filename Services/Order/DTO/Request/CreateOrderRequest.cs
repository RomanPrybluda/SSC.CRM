using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class CreateOrderRequest
    {
        [Required]
        public string? OrderNumber { get; set; }

        [Required]
        public Guid ContractId { get; set; }

        [Required]
        public string? WorkOrderDescription { get; set; }
    }
}