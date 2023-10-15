using DAL.Enum;

namespace Domain.Services.ContractService.DTO
{
    public class UpdateContractRequest : CreateContractRequest
    {
        public DateTime EndDate { get; set; }

        public ContractStatus ContractStatus { get; set; }
    }
}