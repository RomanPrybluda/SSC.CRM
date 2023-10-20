using System.ComponentModel.DataAnnotations;

namespace Domain.Services.ContractService.DTO
{
    public class CreateContractRequest
    {
        [Required]
        public string? ContractNumber { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public Guid ClientId { get; set; }
    }
}