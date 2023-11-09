using DAL.Enum;

namespace Services
{
    public class UpdateContractRequest : CreateContractRequest
    {
        public DateTime EndDate { get; set; }

        public ContractStatus ContractStatus { get; set; } = ContractStatus.Unsigned;
    }
}