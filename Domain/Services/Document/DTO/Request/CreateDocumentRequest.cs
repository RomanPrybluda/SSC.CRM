using DAL.Enum;

namespace Domain.Services.DocumentService.DTO
{
    public class CreateDocumentRequest
    {
        public string? DocumenNumber { get; set; }

        public string? DocumenName { get; set; }

        public string? Description { get; set; }

        public string? ShipName { get; set; }

        public int ShipImoNumber { get; set; }

        public AvailabilityRequiredDocs AvailabilityRequiredDocs { get; set; }

        public string? Developer { get; set; }
    }
}
