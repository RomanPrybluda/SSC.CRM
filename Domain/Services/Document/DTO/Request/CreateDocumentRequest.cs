using DAL.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Services.DocumentService.DTO
{
    public class CreateDocumentRequest
    {
        [Required]
        public string? DocumenNumber { get; set; }

        [Required]
        public string? DocumenName { get; set; }

        [Required]
        public string? Description { get; set; }

        public string? ShipName { get; set; }

        public int ShipImoNumber { get; set; }

        public AvailabilityRequiredDocs AvailabilityRequiredDocs { get; set; }

        public string? Developer { get; set; }
    }
}
