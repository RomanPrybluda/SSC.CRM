namespace Domain.Services.ContractService.DTO
{
    public class CreateContractResponse : CreateContractRequest
    {
        public Guid ContractId { get; set; }
    }
}
