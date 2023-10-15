using DAL.Enum;

namespace DAL.Entity
{
    public class Document : BaseEntity
    {
        public Guid DocumentId { get; set; }

        public string? DocumenNumber { get; set; }

        public string? DocumenName { get; set; }

        public string? Description { get; set; }

        public string? ShipName { get; set; }

        public int ShipImoNumber { get; set; }

        public AvailabilityRequiredDocs AvailabilityRequiredDocs { get; set; }

        public DocumentStatus DocumentStatus { get; set; }

        public string? Developer { get; set; }

        public string? Checker { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime SentDate { get; set; }

        public Guid ShipId { get; set; }

        public Ship Ship { get; set; }
    }
}