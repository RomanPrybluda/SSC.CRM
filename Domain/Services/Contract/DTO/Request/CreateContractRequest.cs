namespace Domain.Services.ContractService.DTO
{
    public class CreateContractRequest
    {
        public string? ContractNumber { get; set; }

        public string? Title { get; set; }

        public decimal TotalAmount { get; set; }

        public string? Description { get; set; }

        public Guid ClientId { get; set; }
    }
}